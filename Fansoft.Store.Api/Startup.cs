using System.Collections.Generic;
using System.Text;
using Fansoft.Store.Api.Infra;
using Fansoft.Store.Api.Models;
using Fansoft.Store.IoCDI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;

namespace Fansoft.Store.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalException));
                
                // forçar a api dar um 406 qdo o accept não é aceito
                options.ReturnHttpNotAcceptable = true;
            })
                .AddXmlSerializerFormatters()
                .AddJsonOptions(options => {
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Store API", Version = "v1" });

                var security = new Dictionary<string,IEnumerable<string>>{
                    {"Bearer",new string[]{}}
                };
                options.AddSecurityRequirement(security);

                options.AddSecurityDefinition("Bearer", new ApiKeyScheme{
                    Description = "Entre com o token<br>(Não esqueça do<strong>bearer</strong>).",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                options.CustomSchemaIds(s => s.FullName);
            });

            services.AddResponseCompression();

            services.AddIoC();


            // var securitySettings = _configuration.GetSection("SecuritySettings");
            // services.Configure<SecuritySettings>(securitySettings);
            // ou:
            var securitySettings = new SecuritySettings();
            
            new ConfigureFromConfigurationOptions<SecuritySettings>(
                _configuration.GetSection("SecuritySettings")
            ).Configure(securitySettings);
            services.AddSingleton(securitySettings);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitySettings.Secret));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme =
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer( options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters{
                    //Validar Emissior
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = securitySettings.Emissor,
                    ValidAudience = securitySettings.ValidoEm
                };
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Run(async ctx => {
            //     await ctx.Response.WriteAsync("Fim");
            // });

            app.Use(async (ctx,next) => {
                // código na ida
                // var texto1 = "xpto";
                await next.Invoke();
                // volta
                if (ctx.Response.StatusCode == 404)
                {
                    //await ctx.Response.WriteAsync("Endereço inválido");
                    ctx.Request.Path = "/error404";
                    await next.Invoke();
                }
            });

            app.UseResponseCompression();

            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API");
                options.RoutePrefix = "docs";
            });

            

        }
    }
}
