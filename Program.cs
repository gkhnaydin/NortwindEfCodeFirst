using NortwindEfCodeFirst.Contexts;
using NortwindEfCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NortwindEfCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AllCustomer();
            //AddCustomer();
            //AddCustomerOrder();
            //DeleteOrder();
            //UpdateCustomer();
            AllCustomerQueryable();
            Console.ReadLine();
        }

        static void UpdateCustomer()
        {
            using (var context = new NorthwindContext())
            {
                var customer = context.Customers.Find("Gokhan");
                if (!object.ReferenceEquals(customer, null))
                {
                    customer.Country = "Turkey";
                    context.SaveChanges();
                }
            }
        }
        static void DeleteOrder()
        {
            using (var context = new NorthwindContext())
            {
                var order = context.Orders.Find(3);
                if(!object.ReferenceEquals(order, null))
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }
        static void AddCustomerOrder()
        {
            using (var context = new NorthwindContext())
            {
                var customer = context.Customers.Find("Gokhan");
                
                Order order = new Order()
                {
                    CustomerID = "Gokhan",
                    OrderDate = DateTime.Now,
                    ShipCity = "Giresun",
                    ShipCountry = "TURKIYE"
                };

                //context.Orders.Add(order);
                customer.Orders.Add(order);
                context.SaveChanges();

                var orders = context.Orders.ToList();
                foreach (var item in orders)
                {
                    Console.WriteLine($"{item.OrderId}-{item.OrderDate}-{item.CustomerID}");
                }
            }
        }
        static void AddCustomer()
        {
            using (var context = new NorthwindContext())
            {
                Customer customer = new Customer()
                {
                    CustomerID = "Gokhan",
                    CompanyName = "Ordinatrum",
                    City = "Trabzon",
                    ContactName = "Hamitcan",
                    Country = "TURKIYE"
                };
                context.Customers.Add(customer);
                context.SaveChanges();

                var lastCustomer = context.Customers.ToList().Last();
                Console.WriteLine($"{lastCustomer.CustomerID}-{lastCustomer.ContactName}");
            }
        }
        static void AllCustomer()
        {
            using (var context = new NorthwindContext())
            {
                var customers = context.Customers.ToList();
                foreach (var item in customers)
                {
                    Console.WriteLine($"{item.CustomerID}-{item.ContactName}");
                }
            }
        }
        static void AllCustomerQueryable()
        {
            using (var context = new NorthwindContext())
            {
                IQueryable<Customer> customers = from customer in context.Customers
                                                 select customer;

                foreach (var item in customers)
                {
                    Console.WriteLine($"{item.CustomerID}-{item.ContactName}");
                }
            }
        }
    }
}
