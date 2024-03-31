using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public List<Inquiry> Inquiries { get; set; } = new List<Inquiry>();


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

        public void UpdateGame()
        {
            Console.WriteLine("Enter boardgame ID: ");
            string updateID = Console.ReadLine();
            Boardgame updateGame = Boardgames.Find(x => x.BoardgameID == updateID); //Find game by ID in list of boardgames in inventorySystem object and assign to updateGame variable 
            if (updateGame == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }
            Console.WriteLine("Enter new name: ");
            updateGame.Name = Console.ReadLine();
            Console.WriteLine("Enter new genre: ");
            updateGame.Genre = Console.ReadLine();
            Console.WriteLine("Enter new min players: ");
            if (!int.TryParse(Console.ReadLine(), out int newminPlayers))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter max players:");
            if (!int.TryParse(Console.ReadLine(), out int newmaxPlayers))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("Enter new condition: ");
            Console.WriteLine("Enter new condition (New, Used, Damaged): ");
            string newConditionInput = Console.ReadLine();
            Condition newCondition;
            if (Enum.TryParse(newConditionInput, true, out newCondition))
            {
                updateGame.Conditions = newCondition;
            }
            else
            {
                Console.WriteLine("Invalid condition. Please enter a valid condition (New, Used, Damaged).");

            }
            Console.WriteLine("Enter new price: ");
            updateGame.Price = float.Parse(Console.ReadLine());
        }
        //UpdateGame metoden er en metode der tager et boardgame objekt som parameter og opdaterer det i listen af boardgames.
        public void DeleteGame()
        {
            Console.WriteLine("Enter boardgame ID: ");
            string deleteID = Console.ReadLine();
            Boardgame deleteGame = Boardgames.Find(x => x.BoardgameID == deleteID); //Find game by ID in list of boardgames in inventorySystem object and assign to deleteGame variable
            if (deleteGame == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }
            Boardgames.Remove(deleteGame);

        }

        public void SearchGame()
        { 
            Console.WriteLine("Enter search term: ");
            string search = Console.ReadLine();
            List<Boardgame> searchResults = Boardgames.FindAll(x => x.Name.Contains(search) || x.Genre.Contains(search) || x.BoardgameID.Contains(search));
            if (searchResults.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }
            foreach (Boardgame boardgame in searchResults)
            {
                Console.WriteLine($"Name: {boardgame.Name}");
                Console.WriteLine($"Genre: {boardgame.Genre}");
                Console.WriteLine($"Players: {boardgame.MinPlayers} - {boardgame.MaxPlayers}");
                Console.WriteLine($"Condition: {boardgame.Conditions}");
                Console.WriteLine($"Price: {boardgame.Price}");
                Console.WriteLine($"Boardgame ID: {boardgame.BoardgameID}");
                Console.WriteLine("______________________________");
            }

        }
        //SearchGame metoden er en metode der tager et boardgame objekt som parameter og søger efter det i listen af boardgames.
        public void RegisterInquiry()
        {
            Console.WriteLine("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter customer email: ");
            string customerEmail = Console.ReadLine();
            Console.WriteLine("Enter customer ID: ");
            string customerID = Console.ReadLine();
            Customer customer = new Customer(customerName, customerEmail, customerID);
            Inquiry newInquiry = new Inquiry(Inquiry.InquiryStatus.Open, customer, DateTime.Now);
            customer.Inquiries.Add(newInquiry);
        }
        //RegisterInquiry metoden er en metode der tager et inquiry objekt som parameter og tilføjer det til customerens liste af inquiries.
        public void UpdateInquiry()
        {
            Console.WriteLine("Enter customer ID: ");
            string customerID = Console.ReadLine();
            Customer customer = new Customer("","", customerID);
            Inquiry inquiry = customer.Inquiries.Find(x => x.Customer.CustomerID == customerID);
            if (inquiry == null)
            {
                Console.WriteLine("Inquiry not found.");
                return;
            }
            Console.WriteLine("Enter new status: ");
            Console.WriteLine("Enter new status (Open, InProgress, Closed, Resolved): ");
            string newStatusInput = Console.ReadLine();
            Inquiry.InquiryStatus newStatus;
            if (Enum.TryParse(newStatusInput, true, out newStatus))
            {
                inquiry.Status = newStatus;
            }
            else
            {
                Console.WriteLine("Invalid status. Please enter a valid status (Open, InProgress, Closed, Resolved).");
            }
        }
        public void PrintInquiries()
        {
            foreach (Inquiry inquiry in Inquiries)
            {
                Console.WriteLine($"Status: {inquiry.Status}");
                Console.WriteLine($"Creation date: {inquiry.CreationDate}");
                Console.WriteLine($"Customer: {inquiry.Customer.Name}");
                Console.WriteLine($"Boardgame: {inquiry.Boardgame.Name}");
                Console.WriteLine("______________________________");
            }
        }
        //PrintInquiries metoden er en metode der printer alle inquiries i listen af inquiries.
        public void PrintInventoryList()
        {
            int gameCount = 1;
            foreach (Boardgame boardgame in Boardgames)
            {
                Console.WriteLine("Game " + gameCount);
                Console.WriteLine($"Name: {boardgame.Name}");
                Console.WriteLine($"Genre: {boardgame.Genre}");
                Console.WriteLine($"Players: {boardgame.MinPlayers} - {boardgame.MaxPlayers}");
                Console.WriteLine($"Condition: {boardgame.Conditions}");
                Console.WriteLine($"Price: {boardgame.Price}");
                Console.WriteLine($"Boardgame ID: {boardgame.BoardgameID}");
                Console.WriteLine("______________________________");
                gameCount++;
                
            }
        }
        //PrintInventoryList metoden er en metode der printer alle boardgames i listen af boardgames.
    }
}
