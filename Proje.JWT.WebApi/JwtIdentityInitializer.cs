using Proje.JWT.Business.Interfaces;
using Proje.JWT.Business.StringInfos;
using Proje.JWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.JWT.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService,IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            // ilgili rol varmı ? yoksa eklemesini sağlayacağız.
            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);
            if (adminRole==null)
            {
                await appRoleService.Add(new Entities.Concrete.AppRole
                {
                    Name = RoleInfo.Admin,
                });
            }
            var memberRole = await appRoleService.FindByName(RoleInfo.Member);

            if (memberRole == null)
            {
                await appRoleService.Add(new Entities.Concrete.AppRole
                {
                    Name = RoleInfo.Member,
                });
            }

            var adminUser = await appUserService.FindByUserName("buqqer");
            if (adminUser==null)
            {
                await appUserService.Add(new Entities.Concrete.AppUser
                {
                    FullName = "Necmettin KODYOĞURAN",
                    UserName = "buqqer",
                    Password = "1"
                });

                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var admin = await appUserService.FindByUserName("buqqer");

                await appUserRoleService.Add(new AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}
