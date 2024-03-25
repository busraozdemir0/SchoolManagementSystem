using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Users
{
    public class UserListDto : IEquatable<UserListDto>  // HashSet veri yapisinin tekil degerler tutabilmesi icin bu arayuz implemente ediliyor.
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
        public int? StudentNo { get; set; }

        public bool Equals(UserListDto? other)
        {
            if (other == null) 
                return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
