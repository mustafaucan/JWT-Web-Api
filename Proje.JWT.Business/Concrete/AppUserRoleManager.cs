using Proje.JWT.Business.Interfaces;
using Proje.JWT.DataAccess.Interfaces;
using Proje.JWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.Business.Concrete
{
    public class AppUserRoleManager : GenericManager<AppUserRole>,IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal):base(genericDal)
        {
             
        }
    }
}
