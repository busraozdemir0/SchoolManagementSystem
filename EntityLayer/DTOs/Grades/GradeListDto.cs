using EntityLayer.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Grades
{
    public class GradeListDto : IEquatable<GradeListDto> // HashSet veri yapisinin tekil degerler tutabilmesi icin bu arayuz implemente ediliyor.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public bool Equals(GradeListDto? other)
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
