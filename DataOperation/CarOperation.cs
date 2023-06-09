using ApplicationData;
using DataOperation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class CarOperation : IOperation<Car>
    {

        public static void Add(string model , DateTime year , string gear ,int km  , List<Part> parts)
        {

            using (ApplicationDbcontext context = new())
            {
                var car = new Car()
                {
                    Model = model,
                    Year = year,
                    Gear = gear,
                    Km = km,
                    Parts = parts
                    
                };
                context.Cars.Add(car);
                context.SaveChanges();
            }


        }


        public static void Edite(int OldId , string model, DateTime year, string gear, int km)
        {
            using (ApplicationDbcontext context = new())
            {
               var Car =  context.Cars.Find(OldId);
                if (Car != null)
                {
                    Car.Year = year;
                    Car.Gear = gear;
                    Car.Model = model;
                    Car.Km = km;
                    context.SaveChanges();
                }
            }
        }
        public static List<Car> GetAll()
        {
            using (var context = new ApplicationDbcontext())
                return context.Cars.ToList();
        }

        public static void PrintAll()
        {
            using (var context = new ApplicationDbcontext())
            {
                foreach (var car in context.Cars.ToList())
                {
                    Console.WriteLine(car);
                }
            }
                
        }

        public static Car GetById(int id)
        {
            using(var context = new ApplicationDbcontext())
            {
                Car car = context.Cars.Find(id);
                if (car == null)
                {
                    return new Car();
                }
                return car; 
            }
        }

        public static void RemoveById(int id)
        {
           using(var context = new ApplicationDbcontext())
            {
                var car = context.Cars.Find(id);
                if (car != null)
                {
                    context.Cars.Remove(car);
                    context.SaveChanges();
                }
            }
        }

        public void AddObj(Car obj)
        {
            using var context = new ApplicationDbcontext();
            context.Cars.Add(obj);
            context.SaveChanges();

        }

        public void RemoveObj(Car obj)
        {
           using var context = new ApplicationDbcontext();
            context.Cars.Remove(obj);
        }

        public Car GetObj(int id)
        {
            using var context = new ApplicationDbcontext();
            var car = context.Cars.Find(id);
            if(car == null)
                return new Car();

            return car;
        }

        public void EditObj(Car oldObj , Car newObj)
        {
            using var context = new ApplicationDbcontext();
            var car = context.Cars.Where(C => C.Equals(oldObj));
            if (car != null)
            {
                car = (IQueryable<Car>) newObj;
                context.SaveChanges();
            }
        }
    }
}
