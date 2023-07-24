using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Part
    {
        public Part()
        {
            Cars = new List<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public List<Car> Cars { get; set; }
    }
}
