using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.ViewModel
{
    public class PageViewModel<T>
    {
        public List<T> Items { get; set; }
        public string Continuation { get; set; }
        public decimal RequestCharge { get; set; }
        public long CollectionQuota { get; set; }
        public long CollectionSizeQuota { get; set; }
        public long CollectionSizeUsage { get; set; }
        public long CollectionUsage { get; set; }
    }
}
