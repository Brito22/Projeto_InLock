using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai.inlock.webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Filmes.webApi"

                });

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

            });

            services
                // Define a forma de autentica��o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os par�metros de valida��o do token
                .AddJwtBearer("JwtBearer", options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Valida quem est� emitindo o token
                        ValidateIssuer = true,

                        // Valida quem est� recebendo o token
                        ValidateAudience = true,

                        // Valida o tempo de expira��o do token
                        ValidateLifetime = true,

                        // Definindo a chave (frase) de seguran�a
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-inlock-tarde")),

                        // Tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Define o nome do issuer, ou seja, quem emite o token
                        ValidIssuer = "inLock.webAPI",

                        // Define o nome do audience, ou seja, quem recebe o token
                        ValidAudience = "inLock.webAPI"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "inLock.webAPI");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
