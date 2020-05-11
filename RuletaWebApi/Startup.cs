
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RuletaWebApi.Datos.Interface;
using RuletaWebApi.Datos.Servicio;
using RuletaWebApi.Negocio.Interface;
using RuletaWebApi.Negocio.Servicio;
using RuletaWebApi.Entidades.Entidades;

namespace RuletaWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var appSettings = Configuration.GetSection("AppSettings");
            var Configuracion = appSettings.Get<Configuracion>();
            services.Configure<Configuracion>(appSettings);
            
            services.AddTransient<ApuestaNegocio, ApuestaNegocioImplementacion>();
            services.AddTransient<RuletaNegocio, RuletaNegocioImplementacion>();
            services.AddTransient<ClienteNegocio, ClienteNegocioImplementacion>();
            services.AddTransient<RuletaDatos, RuletaDatosImplementacion>();
            services.AddTransient<ApuestaDatos, ApuestaDatosImplementacion>();
            services.AddTransient<ClienteDatos, ClienteDatosImplementacion>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
