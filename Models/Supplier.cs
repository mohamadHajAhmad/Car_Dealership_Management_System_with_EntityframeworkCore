using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Supplier
    {
        public Supplier()
        {
            Parts = new List<Part>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Part> Parts { get; set; }
    }
}
