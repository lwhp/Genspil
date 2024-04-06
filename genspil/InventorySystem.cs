using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace genspil
{
    // Vi bruger en static class til vores InventorySystem da vi ikke vil have at vi skal kunne lave flere instances af den samme klasse.
    public static class InventorySystem
    {
        private static List<Boardgame> Boardgames { get; set; } = [];
        private static List<Employee> Employees { get; set; } = [];
        private static List<Inquiry> Inquiries { get; set; } = [];


        public static bool DoesGameExsist(string id)
        {
            Boardgame boardgame = GetBoardGame(id);

            return boardgame != null;
        }

        private static Boardgame GetBoardGame(string id) => Boardgames.Find(x => x.BoardgameID == id) ?? null;

        //AddGame metoden er en metode der tager et boardgame objekt som parameter og tilføjer det til listen af boardgames.
        public static void AddGame(string name, string genre, int minPlayers, int maxPlayers, Condition condition, float price, string boardgameID)
        {
            Boardgame boardgame = new(name, genre, minPlayers, maxPlayers, condition, price, boardgameID);
            Boardgames.Add(boardgame);
        }

        public static void UpdateGame()
        {
            Console.WriteLine("Enter boardgame ID: ");
            Boardgame updateGame = GetBoardGame(Console.ReadLine() ?? "");
            if (updateGame == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            Console.WriteLine("Enter new name: ");
            updateGame.Name = Console.ReadLine() ?? "";

            Console.WriteLine("Enter new genre: ");
            updateGame.Genre = Console.ReadLine() ?? "";

            Console.WriteLine("Enter new min players: ");
            int minPlayers = Utilities.GetNumberFromInput();

            Console.WriteLine("Enter max players: ");
            int maxPlayers = Utilities.GetNumberFromInput();

            Console.WriteLine("Enter new condition (New, Used, Damaged): ");
            if (Enum.TryParse(Console.ReadLine(), true, out Condition newCondition))
            {
                updateGame.Conditions = newCondition;
            }
            else
            {
                Console.WriteLine("Invalid condition. Please enter a valid condition (New, Used, Damaged).");

            }

            Console.WriteLine("Enter new price: ");
            updateGame.Price = Utilities.GetFloatFromInput();
        }
        //UpdateGame metoden er en metode der tager et boardgame objekt som parameter og opdaterer det i listen af boardgames.
        public static void DeleteGame()
        {
            Console.WriteLine("Enter boardgame ID: ");
            string deleteID = Console.ReadLine() ?? "";
            Boardgame deleteGame = GetBoardGame(deleteID);
            if (deleteGame == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }
            Boardgames.Remove(deleteGame);

        }

        public static void SearchGame()
        { 
            Console.WriteLine("Enter search term: ");
            string search = Console.ReadLine() ?? "";
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
        public static void RegisterInquiry()
        {
            Console.WriteLine("Enter customer name: ");
            string customerName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter customer email: ");
            string customerEmail = Console.ReadLine() ?? "";
            Console.WriteLine("Enter customer ID: ");
            string customerID = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Boardgame name: ");
            string boardgameName = Console.ReadLine() ?? "";
            Boardgame boardgame = new Boardgame(boardgameName, "", 0, 0, Condition.New, 0, "");
            Customer customer = new Customer(customerName, customerEmail, customerID);
            Inquiry newInquiry = new Inquiry(Inquiry.InquiryStatus.Open, customer, DateTime.Now, boardgame);
            customer.Inquiries.Add(newInquiry);
        }

        //RegisterInquiry metoden er en metode der tager et inquiry objekt som parameter og tilføjer det til customerens liste af inquiries.
        public static void UpdateInquiry()
        {
            Console.WriteLine("Enter customer ID: ");
            string customerID = Console.ReadLine() ?? "";
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

        public static void PrintInquiries()
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
        public static void PrintInventoryList()
        {
            int gameCount = 1;
            foreach (Boardgame boardgame in Boardgames)
            {
                Console.WriteLine("Game: {0} \n" +
                    "Name: {1} \n" +
                    "Genre: {2} \n" +
                    "Players: {3} - {4} \n" +
                    "Condition: {5} \n" +
                    "Price: {6} \n" +
                    "Boardgame ID: {7} \n" +
                    "--------------------------",
                    gameCount, boardgame.Name, boardgame.Genre, boardgame.MinPlayers, boardgame.MaxPlayers, boardgame.Conditions, boardgame.Price, boardgame.BoardgameID
                );
                
            }
        }

        //PrintInventoryList metoden er en metode der printer alle boardgames i listen af boardgames.
    }
}
