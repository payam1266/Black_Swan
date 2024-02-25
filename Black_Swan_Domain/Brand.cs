using Black_Swan_Domain.common;
using System.Collections.Generic;

namespace Black_Swan_Domain
{
    public class Brand:BaseDomainEntity
    {
        public string name { get; set; }
        public string? description { get; set; }
        public ICollection<Product>? products { get; set; }
    }
}
