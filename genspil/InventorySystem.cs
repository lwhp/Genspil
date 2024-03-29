using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil
{
    internal class InventorySystem
    {
        public InventorySystem()
        {
            Boardgames = new List<Boardgame>(); 
            Employees = new List<Employee>();
        }
        //Public InventorySystem er en constructor der opretter et InventorySystem objekt og initialiserer listen af boardgames.
        public List<Boardgame> Boardgames { get; set; }
        public List<Employee> Employees { get; set; }
        //Boardgames er en property der kan tilgås og ændres udefra.

        public void AddGame(Boardgame boardgame)
        {
            Boardgames.Add(boardgame);
        }
        //AddGame metoden er en metode der tager et boardgame objekt som parameter og tilføjer det til listen af boardgames.

        public void UpdateGame(Boardgame boardgame)
        {
            //UpdateGame metode
        }

        public void DeleteGame(Boardgame boardgame)
        {
            //DeleteGame metode
        }

        public void SearchGame(string search)
        { 
            //SearchGame metode
        }
        
        public void RegisterInquiry(Inquiry inquiry)
        {
            inquiry.Customer.Inquiries.Add(inquiry);
        }

        public void PrintInventoryList()
        {
            foreach (Boardgame boardgame in Boardgames)
            {
                Console.WriteLine(boardgame.Name);
            }
        }
    }
}
