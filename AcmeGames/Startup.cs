﻿using System.Text;
using AcmeGames.Data;
using AcmeGames.Interfaces;
using AcmeGames.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AcmeGames
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration aConfiguration)
        {
            Configuration = aConfiguration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection  aServiceCollection)
        {
            aServiceCollection.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    var signatureKey = Configuration["JWTKey"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "localhost:56653",
                        ValidAudience = "localhost:56653",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(signatureKey))
                    };
                });
            aServiceCollection.AddCors();
            aServiceCollection.AddMvc();

            aServiceCollection.AddSingleton<IDatabase, Database>();
            aServiceCollection.AddTransient<IGameService, GameService>();
            aServiceCollection.AddTransient<IUserService, UserService>();
            aServiceCollection.AddTransient<ILoginService, LoginService>();
            aServiceCollection.AddTransient<ICodeService, CodeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder aApplicationBuilder, IHostingEnvironment aHostingEnvironment){
            if (aHostingEnvironment.IsDevelopment())
            {
                aApplicationBuilder.UseDeveloperExceptionPage()
                    .UseCors(builder =>
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                    );
            }

            aApplicationBuilder.UseMvc();
        }
    }
}
