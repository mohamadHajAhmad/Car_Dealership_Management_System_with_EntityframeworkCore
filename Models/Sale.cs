using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int Totla { get; set; }
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
    }
}
