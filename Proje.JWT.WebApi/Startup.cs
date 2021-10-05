using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Proje.JWT.Business.Containers.MicrosoftIoC;
using Proje.JWT.Business.Interfaces;
using Proje.JWT.Business.StringInfos;
using Proje.JWT.WebApi.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.JWT.WebApi
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
            services.AddDependencies();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(ValidId<>));
            // Authentication servis control�n�n �zerinde olacak.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt =>
                {
                    //localde http ile �al��t���m�z i�in bunu kapat�yoruz.
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = JwtInfo.Issuer,
                        ValidAudience = JwtInfo.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey)),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew=TimeSpan.Zero
                    };
                }
                );
            services.AddControllers().AddFluentValidation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Error");
            JwtIdentityInitializer.Seed(appUserService, appUserRoleService, appRoleService).Wait();
            app.UseRouting();
            // Jwt Config ayarlar�n� yapt�ktan sonra app ile UseAuthenticationu kullanmam�z gereknzy.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
