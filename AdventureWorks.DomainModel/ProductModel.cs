namespace AdventureWorks.DomainModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductModel
    {
        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<ProductModelProductDescription> ProductModelProductDescription { get; set; }
    }
}
