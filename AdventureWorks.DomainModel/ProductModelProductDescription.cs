namespace AdventureWorks.DomainModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductModelProductDescription
    {
        public int ProductModelID { get; set; }
        public int ProductDescriptionID { get; set; }
        public string Culture { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual ProductDescription ProductDescription { get; set; }
    }
}
