﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRoleDal
    {
        Task<List<AppRole>> GetAllRolesAsync();
        Task<Guid> GetByIdRoleAsync(string roleName);

    }
}
