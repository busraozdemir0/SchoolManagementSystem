﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IRoleService
    {
        Task<List<AppRole>> TGetAllRolesAsync();
        Task<Guid> TGetByIdRoleAsync(string roleName);
    }
}
