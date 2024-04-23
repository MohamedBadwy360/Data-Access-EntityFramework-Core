using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        private Product()
        {
            this.Snapshot = new Snapshot();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public string Description { get; set; } = null!;
        public Snapshot Snapshot { get; set;} = null!;
    }
}
