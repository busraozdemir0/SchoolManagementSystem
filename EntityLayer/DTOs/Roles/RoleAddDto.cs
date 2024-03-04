using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Roles
{
    public class RoleAddDto
    {
        public string Name { get; set; }
        public Guid ConcurrencyStamp { get; set; }
    }
}
