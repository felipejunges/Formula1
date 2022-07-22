using FluentValidation;
using FluentValidation.AspNetCore;
using Formula1.Domain.Interfaces.ApiServices;
using Formula1.Domain.Interfaces.Repositories;
using Formula1.Domain.Interfaces.Services;
using Formula1.Domain.Services;
using Formula1.Infra.ApiServices;
using Formula1.Infra.Database;
using Formula1.Infra.Repositories;
using Formula1.MVC.Models;
using Formula1.MVC.Models.Validators;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Formula1.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<F1Db>();

            services.AddScoped<CorridasService>()
                    .AddScoped<EquipeTemporadaService>()
                    .AddScoped<IImportacaoService, ImportacaoService>()
                    .AddScoped<PilotoTemporadaService>()
                    .AddScoped<ResultadosService>()
                    .AddScoped<TabelaPilotosService>()
                    .AddScoped<TabelaEquipesService>()
                    .AddScoped<GraficoCampeonatoPilotosService>()
                    .AddScoped<GraficoCampeonatoEquipesService>();

            services.AddScoped<IContratosRepository, ContratosRepository>()
                    .AddScoped<ICorridasRepository, CorridasRepository>()
                    .AddScoped<IEquipesRepository, EquipesRepository>()
                    .AddScoped<IEquipesTemporadaRepository, EquipesTemporadaRepository>()
                    .AddScoped<IExportacaoRepository, ExportacaoRepository>()
                    .AddScoped<IImportacaoRepository, ImportacaoRepository>()
                    .AddScoped<IPilotosRepository, PilotosRepository>()
                    .AddScoped<IPilotosTemporadaRepository, PilotosTemporadaRepository>()
                    .AddScoped<IResultadosRepository, ResultadosRepository>()
                    .AddScoped<IUsuariosRepository, UsuariosRepository>();

            services.AddHttpClient<IF1ApiService, F1ApiService>((client) =>
            {
                client.BaseAddress = new Uri("https://f1.somee.com/"); // TODO: parametrizar
            });

            services.AddTransient<IValidator<CadastroViewModel>, CadastroViewModelValidator>();

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Login";
                    options.LogoutPath = "/Login/Logout";
                });

            services.AddDataProtection()
                .SetApplicationName("Formula 1")
                .PersistKeysToFileSystem(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"/Etc/Keys"))
                .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

            services.AddMvc()
                .AddFluentValidation();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    areaName: "Admin",
                    name: "Resultado",
                    pattern: "{temporada:int=2022}/Admin/{controller}/{corridaId:int}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    areaName: "Admin",
                    name: "Admin",
                    pattern: "{temporada:int=2022}/Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{temporada:int=2022}/{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<F1Db>();
                db.Database.EnsureCreated();
            }
        }
    }
}