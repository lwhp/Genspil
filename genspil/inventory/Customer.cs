using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil.inventory
{
    internal class Customer(string name, string email, string customerID)
    {
        //Public Customer er en constructor der tager name, email og customerID som parametre og opretter et Customer objekt.
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string CustomerID { get; set; } = customerID;
        public List<Inquiry> Inquiries { get; set; } = new List<Inquiry>();

    }
}
