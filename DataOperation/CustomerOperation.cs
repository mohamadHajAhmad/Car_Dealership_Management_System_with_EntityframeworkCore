using ApplicationData;
using Models;

namespace DataOperation
{
    public class CustomerOperation : IOperation<Customer>
    {
        public static void Add(int id , string name , int age , string address)
        {
            using var context = new ApplicationDbcontext();
            var customer = new Customer()
            {
                Id = id,
                Name = name,
                Age = age,
                Address = address
            };
        }


        public static Customer GetById(int id)
        {
            using var context = new ApplicationDbcontext();
            var customer = context.Customers.Find(id);
            if (customer == null)
            {
                return new Customer();
            }
            return customer;
        }

        public static void RemoveById(int id)
        {
            using var context = new ApplicationDbcontext();
            var customer = context.Customers.Find(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
            }
        }

        public static void PrintAll()
        {
            using var context = new ApplicationDbcontext();
            foreach (var customer in context.Customers.ToList())
            {
                Console.WriteLine(customer);
            }

        }

        public static List<Customer> GetAll()
        {
            using var context = new ApplicationDbcontext();
            return context.Customers.ToList();
        }
         public static void Edite(int id , string name , int age , string address)
        {
            using var context = new ApplicationDbcontext();
            var customer =  context.Customers.Find(id);
            if (customer != null)
            {
                customer.Name = name;
                customer.Age = age;
                customer.Address = address;
                context.SaveChanges();
            }
        }


        public void AddObj (Customer obj)
        {
            using var context = new ApplicationDbcontext();
            context.Customers.Add(obj);
            context.SaveChanges();

        }

        public void RemoveObj(Customer obj)
        {
            using var context = new ApplicationDbcontext();
            context.Customers.Remove(obj);
        }

        public Customer GetObj(int id)
        {
            using var context = new ApplicationDbcontext();
            var Customer = context.Customers.Find(id);
            if (Customer == null)
                return new Customer();

            return Customer;
        }

        public void EditObj(Customer oldObj, Customer newObj)
        {
            using var context = new ApplicationDbcontext();
            var Customer = context.Customers.Where(C => C.Equals(oldObj));
            if (Customer != null)
            {
                Customer = (IQueryable<Customer>)newObj;
                context.SaveChanges();
            }
        }

    }
}