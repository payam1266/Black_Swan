﻿using Black_Swan_Domain.common;
using System.Collections.Generic;

namespace Black_Swan_Domain
{
    public class ProductCategory:BaseDomainEntity
    {
        public string name { get; set; }
        public ICollection<Product>? products { get; set; }
    }
}
