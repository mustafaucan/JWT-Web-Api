using Proje.JWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.Business.Interfaces
{
    public interface IJwtService 
    {
        string GenerateJwtToken(AppUser appUser, List<AppRole> appRoles);
    }
}
