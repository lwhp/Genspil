using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil.inventory
{
    internal class Customer
    {
        public Customer(string name, string email, string customerID)
        {
            Name = name;
            Email = email;
            CustomerID = customerID;
            Inquiries = new List<Inquiry>();
        }
        //Public Customer er en constructor der tager name, email og customerID som parametre og opretter et Customer objekt.
        public string Name { get; set; }
        public string Email { get; set; }
        public string CustomerID { get; set; }
        public List<Inquiry> Inquiries { get; set; }

    }
}
