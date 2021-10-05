using Proje.JWT.DataAccess.Interfaces;
using Proje.JWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EFAppRoleRepository : EFGenericRepository<AppRole>, IAppRoleDal 
    {
    }
}
