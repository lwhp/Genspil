using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil
{
    internal class Employee
    {
        public Employee(string name, string position, string employeeID)
        {
            Name = name;
            Position = position;
            EmployeeID = employeeID;
        }
        //Public Employee er en constructor der tager name, email og employeeID som parametre og opretter et Employee objekt.
        public string Name { get; set; }
        public string Position { get; set; }
        public string EmployeeID { get; set; }

        public void RegisterInquiry(Inquiry inquiry)
        {
            inquiry.Customer.Inquiries.Add(inquiry);
        }
        //RegisterInquiry metoden er en metode der tager et inquiry objekt som parameter og tilføjer det til customerens liste af inquiries.

        public void AddGame(Boardgame boardgame)
        { 
            //AddGame metode
        }

        public void updateGame(Boardgame boardgame)
        {
            //updateGame metode
        }

        public void deleteGame(Boardgame boardgame)
        {
            //deleteGame metode
        }
    }
}
