using ApplicationData;
using DataOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class SaleOperation : IOperation<Sale>
    {
        public static void Add(int total , int carId , int customerId)
        {
            using(var context = new ApplicationDbcontext())
            {
                var Sale = new Sale()
                {
                    Totla =  total , 
                    CardId = carId ,
                    CustomerId = customerId ,

                };
                context.Add(Sale);
               
            }
        }

        public static Sale GetById(int id)
        {
            using var context = new ApplicationDbcontext();
            var Sale = context.Sales.Find(id);
            if (Sale == null)
            {
                return new Sale();
            }
            return Sale;
        }

        public static void RemoveById(int id)
        {
            using var context = new ApplicationDbcontext();
            var Sale = context.Sales.Find(id);
            if (Sale != null)
            {
                context.Sales.Remove(Sale);
                context.SaveChanges();
            }
        }

        public static void PrintAll()
        {
            using var context = new ApplicationDbcontext();
            foreach (var Sale in context.Sales.ToList())
            {
                Console.WriteLine(Sale);
            }

        }

        public static List<Sale> GetAll()
        {
            using var context = new ApplicationDbcontext();
            return context.Sales.ToList();
        }
        public static void Edite(int OldId, int total, int carId, int customerId)
        {
            using var context = new ApplicationDbcontext();
            var Sale = context.Sales.Find(OldId);
            if (Sale != null)
            {
                Sale.Totla = total;
                Sale.CardId = carId;
                Sale.CustomerId = customerId;
                context.SaveChanges();
            }
        }



        public void AddObj(Sale obj)
        {
            using var context = new ApplicationDbcontext();
            context.Sales.Add(obj);
            context.SaveChanges();

        }

        public void RemoveObj(Sale obj)
        {
            using var context = new ApplicationDbcontext();
            context.Sales.Remove(obj);
        }

        public Sale GetObj(int id)
        {
            using var context = new ApplicationDbcontext();
            var Sale = context.Sales.Find(id);
            if (Sale == null)
                return new Sale();

            return Sale;
        }

        public void EditObj(Sale oldObj, Sale newObj)
        {
            using var context = new ApplicationDbcontext();
            var Sale = context.Sales.Where(C => C.Equals(oldObj));
            if (Sale != null)
            {
                Sale = (IQueryable<Sale>)newObj;
                context.SaveChanges();
            }
        }
    }
}
