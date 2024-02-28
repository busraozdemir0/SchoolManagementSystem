using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    // Bu kodlar birden fazla tabloda olacagi icin Core(cekirdek) katmaninda tanimlandi. 
    public abstract class BaseEntity<TId>: IBaseEntity
    {

        public virtual TId Id { get; set; } // Id bilgisi Guid, int, long gibi farkli veri tipi olabileceginden generic olarak tanimlandi.
        public virtual string? CreatedBy { get; set; } = "Undefined";
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false; 
    }
}
