using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Address : BaseEntity<int>
    {
        public Address()
        {
            
        }
        public Address(string addressInfo, string eMail, string supportEmail, string phoneNumber, string mapLocation)
        {
            AddressInfo = addressInfo;
            EMail = eMail;
            SupportEMail = supportEmail;
            PhoneNumber = phoneNumber;
            MapLocation = mapLocation;
        }
        public string AddressInfo { get; set; }
        public string EMail { get; set; }
        public string SupportEMail { get; set; }
        public string PhoneNumber { get; set; }
        public string MapLocation { get; set; }
    }
}
