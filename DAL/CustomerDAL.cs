using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL 
    {
        CarRentalEntities context = null;
        public CustomerDAL()
        {
            context=new CarRentalEntities();
        }
        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }
        public Customer GetCustomer(int id)
        {
            return context.Customers.Find(id);
        }
        public bool AddCustomer(Customer c)
        {
            try
            {
                context.Customers.Add(c);
                context.SaveChanges();
                return true;
            }
            catch{
                return false;
            }
        }
        public bool updatecustomer(int id,Customer c)
        {
            try
            {
                Customer k = context.Customers.Find(id);
                k.Customerid = c.Customerid;
                k.CustomerName = c.CustomerName;
                k.mail = c.mail;
                k.LoyaltyPoints = c.LoyaltyPoints;
               
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deletecustomer(int id)
        {
            try
            {
                Customer k = context.Customers.Find(id);
                context.Customers.Remove(k);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public void Addloyalty(int km,int id)
        {
            Customer k = context.Customers.Find(id);
            k.LoyaltyPoints += km/50;
            context.SaveChanges();
        }
        public void minusloyalty(int id)
        {
            Customer k = context.Customers.Find(id);
            k.LoyaltyPoints=k.LoyaltyPoints-25;
            context.SaveChanges();
        }
       

    }
}
