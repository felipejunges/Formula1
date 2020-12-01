using Formula1.Domain.Services;
using Formula1.Infra.Database.SqlServer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
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
            services.AddDbContext<F1Db>(options => options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"), b => b.MigrationsAssembly("Formula1.Infra")));

            services.AddScoped<CorridasService>()
                    .AddScoped<EquipesService>()
                    .AddScoped<EquipeTemporadaService>()
                    .AddScoped<PilotosService>()
                    .AddScoped<PilotoTemporadaService>()
                    .AddScoped<PunicaoService>()
                    .AddScoped<ResultadosService>()
                    .AddScoped<TabelaPilotosService>()
                    .AddScoped<TabelaEquipesService>()
                    .AddScoped<GraficoCampeonatoPilotosService>()
                    .AddScoped<GraficoCampeonatoEquipesService>()
                    .AddScoped<UsuarioService>();

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Login";
                    options.LogoutPath = "/Login/Logout";
                });

            services.AddDataProtection()
                .SetApplicationName("Formula 1")
                .PersistKeysToFileSystem(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\Etc\Keys"))
                .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                endpoints.MapControllerRoute(
                    name: "Resultado",
                    pattern: "{controller}/{corridaId}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}