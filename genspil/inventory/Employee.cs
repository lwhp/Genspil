using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil.inventory
{
    internal class Employee(string name, string position, string employeeID)
    {
        //Public Employee er en constructor der tager name, email og employeeID som parametre og opretter et Employee objekt.
        public string Name { get; set; } = name;
        public string Position { get; set; } = position;
        public string EmployeeID { get; set; } = employeeID;
    }
}
