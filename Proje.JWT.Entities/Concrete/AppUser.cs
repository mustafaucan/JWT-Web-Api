using Proje.JWT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }

    }
}
