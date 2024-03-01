﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Addresses
{
    public class AddressDto
    {
        public string AddressInfo { get; set; }
        public string EMail { get; set; }
        public string SupportEMail { get; set; }
        public string PhoneNumber { get; set; }
        public string MapLocation { get; set; }
    }
}
