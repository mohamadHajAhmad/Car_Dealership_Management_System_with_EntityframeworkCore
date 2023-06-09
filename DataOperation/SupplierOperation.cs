using ApplicationData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperation
{
    public class SupplierOperation : IOperation<Supplier>
    {

        public static void Add( string name, string address , List<Part> parts)
        {
            using var context = new ApplicationDbcontext();
            var Supplier = new Supplier()
            {
                Name = name,
                Address = address,
                Parts = parts
            };
        }


        public static Supplier GetById(int id)
        {
            using var context = new ApplicationDbcontext();
            var Supplier = context.Suppliers.Find(id);
            if (Supplier == null)
            {
                return new Supplier();
            }
            return Supplier;
        }

        public static void RemoveById(int id)
        {
            using var context = new ApplicationDbcontext();
            var Supplier = context.Suppliers.Find(id);
            if (Supplier != null)
            {
                context.Suppliers.Remove(Supplier);
            }
        }

        public static void PrintAll()
        {
            using var context = new ApplicationDbcontext();
            foreach (var Supplier in context.Suppliers.ToList())
            {
                Console.WriteLine(Supplier);
            }

        }

        public static List<Supplier> GetAll()
        {
            using var context = new ApplicationDbcontext();
            return context.Suppliers.ToList();
        }
        public static void Edite(int id, string name, int age, string address)
        {
            using var context = new ApplicationDbcontext();
            var Supplier = context.Suppliers.Find(id);
            if (Supplier != null)
            {
                Supplier.Name = name;
                Supplier.Address = address;
                context.SaveChanges();
            }
        }


        public void AddObj(Supplier obj)
        {
            using var context = new ApplicationDbcontext();
            context.Suppliers.Add(obj);
            context.SaveChanges();

        }

        public void RemoveObj(Supplier obj)
        {
            using var context = new ApplicationDbcontext();
            context.Suppliers.Remove(obj);
        }

        public Supplier GetObj(int id)
        {
            using var context = new ApplicationDbcontext();
            var Supplier = context.Suppliers.Find(id);
            if (Supplier == null)
                return new Supplier();

            return Supplier;
        }

        public void EditObj(Supplier oldObj, Supplier newObj)
        {
            using var context = new ApplicationDbcontext();
            var Supplier = context.Suppliers.Where(C => C.Equals(oldObj));
            if (Supplier != null)
            {
                Supplier = (IQueryable<Supplier>)newObj;
                context.SaveChanges();
            }
        }
    }
}
