using Formula1.Domain.Services;
using Formula1.Infra.Database.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    .AddScoped<ResultadosService>()
                    .AddScoped<TabelaPilotosService>()
                    .AddScoped<TabelaEquipesService>()
                    .AddScoped<GraficoCampeonatoPilotosService>()
                    .AddScoped<GraficoCampeonatoEquipesService>();

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