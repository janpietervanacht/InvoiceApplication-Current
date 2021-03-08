// Zet in Project CRUD-API -> properties -> debug -> 
// Profile = WebAPIForClient (mag ook iets anders zijn)
// Launch: Project (ook niet echt spannend vermoed ik )
// Lunch browser: LEEGMAKEN (WEL belangrijk)


using DataAccess.ApplicDbContext;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace WebApiPeterOrigineel
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

            services.AddDbContext<DataAccess.ApplicDbContext.DatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            services.AddScoped<IClientRepository, ClientRepository>(); 

            services.AddApiVersioning(opties =>
            {
                // Als er geen versie is gespecificeerd, de default wordt dan genomen
                // en er wordt geen foutmelding gegeven: 
                opties.AssumeDefaultVersionWhenUnspecified = true;
                opties.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);  // Versie 1.0
                opties.ReportApiVersions = true; // rapporteer de huidige versie
            });

            services.AddVersionedApiExplorer(opties => opties.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureerSwaggerOpties>();

            services.AddSwaggerGen();
            services.AddSwaggerGen(opties =>   // opties is een Action (een snelle notatie voor een void functie
            {
                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var commentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

                //---------------------------------------------------------------
                // Voeg eerst toe via Project CRUD-API -> Properties -> Build -> 
                // XMLDocumentation file: CRUD-API.xml (zonder pad). 
                opties.IncludeXmlComments(commentsFullPath);
                //---------------------------------------------------------------

            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseSwagger(); // Indier zegt: achter de UseHttpsRedirection zetten
            app.UseSwaggerUI(opties =>  // een Action (= void functie) als parameter
            {
                foreach (var desc in provider.ApiVersionDescriptions)
                {
                    opties.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json",
                        desc.GroupName.ToUpperInvariant());
                }
                opties.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
