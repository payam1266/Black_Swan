using System;

namespace Black_Swan_Domain.common
{
    public abstract class BaseDomainEntity
    {

        public int id { get; set; }

        public DateTime CreatedDay { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
