using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class Customer
    {
        public Customer(int customerID, string name, string address, double salary)
        {
            CustomerID = customerID;
            Name = name;
            Address = address;
            Salary = salary;
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
    }
    interface ICustomerManager
    {
        bool AddCustomer(Customer cr);
        bool DeleteCustomer(int id);
        bool UpdateCustomer(int id);
        bool ViewAllCustomer();
    }
    class CustomerManager : ICustomerManager
    {
        HashSet<Customer> customers = new HashSet<Customer>();
        public bool AddCustomer(Customer cr)
        {
            return customers.Add(cr);
        }

        public bool DeleteCustomer(int id)
        {
            foreach (Customer cr in customers)
            {
                if (cr.CustomerID == id)
                {
                    customers.Remove(cr);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateCustomer(int id)
        {
            foreach (Customer cr in customers)
            {
                if (cr.CustomerID == id)
                {
                    Console.Write("Enter the New Name: ");
                    string newname = Console.ReadLine();
                    Console.Write("Enter the New Address: ");
                    string newaddress = Console.ReadLine();
                    Console.Write("Enter the New Salary: ");
                    double newsalary = double.Parse(Console.ReadLine());
                    cr.Name = newname;
                    cr.Address = newaddress;
                    cr.Salary = newsalary;
                    return true;
                }
            }
            return false;
        }
        public bool ViewAllCustomer()
        {
            foreach (var cr in customers)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"ID: {cr.CustomerID}");
                Console.WriteLine($"Name: {cr.Name}");
                Console.WriteLine($"Address: {cr.Address}");
                Console.WriteLine($"Author: {cr.Salary}");
                Console.WriteLine("-------------------------------");
            }
            return true;
        }
    }

    class CustomerManagerDemo
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer(13, "Aneena Fernandez", "Trivadrum", 33000);
            Customer c2 = new Customer(14, "Anagha Suresh", "Kannur", 25000);
            Customer c3 = new Customer(30, "Athira Murali", "Thrissur", 30000);
            Customer c4 = new Customer(40, "Binitta Micheal", "Trivandrum", 25000);
            CustomerManager mgr = new CustomerManager();
            mgr.AddCustomer(c1);
            mgr.AddCustomer(c2);
            mgr.AddCustomer(c3);
            mgr.AddCustomer(c4);

            mgr.ViewAllCustomer();
            mgr.DeleteCustomer(14);
            mgr.ViewAllCustomer();
        }

    }
}
