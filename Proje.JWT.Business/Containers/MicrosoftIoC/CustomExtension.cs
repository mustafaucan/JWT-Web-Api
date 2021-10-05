using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Proje.JWT.Business.Concrete;
using Proje.JWT.Business.Interfaces;
using Proje.JWT.Business.ValidationRules.FluentValidation;
using Proje.JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Proje.JWT.DataAccess.Interfaces;
using Proje.JWT.Entities.Dtos.AppUserDtos;
using Proje.JWT.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.Business.Containers.MicrosoftIoC
{
  
    public static class CustomExtension  
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EFGenericRepository<>));
            services.AddScoped<IProductDal, EFProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IAppUserDal, EFAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppRoleDal, EFAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleDal, EFAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();

            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
        }
    }
}
