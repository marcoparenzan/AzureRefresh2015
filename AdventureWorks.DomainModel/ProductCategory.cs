namespace AdventureWorks.DomainModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
