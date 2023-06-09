using ApplicationData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public class PartOperation : IOperation<Part>
    {

        public static void Add(string name, int price, int quantity , Supplier supplier)
        {
            using var context = new ApplicationDbcontext();
            var part = new Part()
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Supplier = supplier
                
            };
        }


        public static Part GetById(int id)
        {
            using var context = new ApplicationDbcontext();
            var part = context.Parts.Find(id);
            if (part == null)
            {
                return new Part();
            }
            return part;
        }

        public static void RemoveById(int id)
        {
            using var context = new ApplicationDbcontext();
            var part = context.Parts.Find(id);
            if (part != null)
            {
                context.Parts.Remove(part);
                context.SaveChanges();
            }
        }

        public static void PrintAll()
        {
            using var context = new ApplicationDbcontext();
            foreach (var part in context.Parts.ToList())
            {
                Console.WriteLine(part);
            }

        }

        public static List<Part> GetAll()
        {
            using var context = new ApplicationDbcontext();
            return context.Parts.ToList();
        }
        public static void Edite(int id, string name, int price, int quantity, int supplierId)
        {
            using var context = new ApplicationDbcontext();
            var part = context.Parts.Find(id);
            if (part != null)
            {
                part.Name = name;
                part.Price = price;
                part.Quantity = quantity;
                part.SupplierId = supplierId;
                context.SaveChanges();
            }
        }



        public void AddObj(Part obj)
        {
            using var context = new ApplicationDbcontext();
            context.Parts.Add(obj);
            context.SaveChanges();

        }

        public void RemoveObj(Part obj)
        {
            using var context = new ApplicationDbcontext();
            context.Parts.Remove(obj);
        }

        public Part GetObj(int id)
        {
            using var context = new ApplicationDbcontext();
            var Part = context.Parts.Find(id);
            if (Part == null)
                return new Part();

            return Part;
        }

        public void EditObj(Part oldObj, Part newObj)
        {
            using var context = new ApplicationDbcontext();
            var Part = context.Parts.Where(C => C.Equals(oldObj));
            if (Part != null)
            {
                Part = (IQueryable<Part>) newObj;
                context.SaveChanges();
            }
        }

    }
}
