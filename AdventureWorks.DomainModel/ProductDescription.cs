namespace AdventureWorks.DomainModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductDescription
    {
        public int ProductDescriptionID { get; set; }
        public string Description { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
