using Iatec.EMS.Api.Infra.Extensions;
using Iatec.EMS.Infra;
using Iatec.EMS.IoC;
using Iatec.EMS.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Iatec.EMS.Api
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

            #region Jwt
            services.AddJwtServices(Configuration);
            #endregion

            #region Api 
            services.AddAPIServices();
            #endregion

            #region Infra
            services.AddInfra(Configuration);
            #endregion

            #region IoC
            services.AddServices();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}{1}Iatec.EMS.Api.xml", Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory), "app/"));
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Iatec EMS Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor, utilize Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMS APP"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
