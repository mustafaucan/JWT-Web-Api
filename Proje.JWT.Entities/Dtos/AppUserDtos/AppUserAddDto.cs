﻿using Proje.JWT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.Entities.Dtos.AppUserDtos
{
    public class AppUserAddDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
