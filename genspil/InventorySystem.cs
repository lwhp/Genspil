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
        

        public void AddGame()
        {
           Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter genre:");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter min players:");
            if (!int.TryParse(Console.ReadLine(), out int minPlayers))
            {
                Console.WriteLine("Invalid input");
                return;
            }   
            Console.WriteLine("Enter max players:");
            if (!int.TryParse(Console.ReadLine(), out int maxPlayers))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter condition:");
            Console.WriteLine("Enter condition (New, Used, Damaged): ");
            string conditionInput = Console.ReadLine();
            Condition condition;
            if (!Enum.TryParse(conditionInput, true, out condition))
            {
                Console.WriteLine("Invalid condition. Setting to 'New' as default.");
                condition = Condition.New;
            }
            Console.WriteLine("Enter price:");
            if (!float.TryParse(Console.ReadLine(), out float price))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter boardgame ID:");
            string boardgameID = Console.ReadLine();
            Boardgame boardgame = new Boardgame(name, genre, minPlayers, maxPlayers, condition, price, boardgameID);
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
