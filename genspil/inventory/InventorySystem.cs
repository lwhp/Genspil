using genspil.Database;
using genspil.Enums;

namespace genspil.inventory
{
    public static class InventorySystem
    {
        //AddGame metoden er en metode der tager et boardgame objekt som parameter og tilføjer det til listen af boardgames.
        internal static void AddGame(string name, string genre, int minPlayers, int maxPlayers, Condition condition, float price, string boardgameID)
        {
            
            Boardgame boardgame = new(name, genre, minPlayers, maxPlayers, condition, price, boardgameID);
            Controller.AddGame(boardgame);            
        }

        public static void ChangeGame(string id, int? min = null, int? max = null, string? genre = null, string? name = null, Condition? newCondition = null)
        {
            Boardgame board = Controller.GetBoardGame(id);

            if (board == null)
            {
                Console.WriteLine("Board not found...");
                return;
            }

            board.ChangeBoardSettings(min, max, genre, name, newCondition);
        }

        //UpdateGame metoden er en metode der tager et boardgame objekt som parameter og opdaterer det i listen af boardgames.
        public static void DeleteGame()
        {
            Console.WriteLine("Enter boardgame ID: ");
            string boardgameID = Console.ReadLine() ?? "";

            if (!Controller.DoesGameExsist(boardgameID))
            {
                Console.WriteLine("Game not found.");
                return;
            }

            DataHandler dataHandler = new DataHandler("BoardGames.txt");
            dataHandler.DeleteBoardGame(boardgameID);
            Controller.DeleteGame(boardgameID);
        }

        public static void SearchGame()
        {
            Console.WriteLine("Enter search term: ");
            List<Boardgame> searchResults = Controller.GetSearchedGames(Console.ReadLine() ?? "");

            if (searchResults.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }

            foreach (Boardgame boardgame in searchResults)
            {
                Console.WriteLine(boardgame.ToString());
                Console.WriteLine("---------------------");
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

            Inquiry newInquiry = new(InquiryStatus.Open, boardgameName, customerName, customerEmail, customerID);
            Controller.AddInquiry(newInquiry);
        }

        //RegisterInquiry metoden er en metode der tager et inquiry objekt som parameter og tilføjer det til customerens liste af inquiries.
        public static void UpdateInquiry()
        {
            Console.WriteLine("Enter customer email: ");
            Inquiry inquiry = Controller.GetInquiry(Console.ReadLine() ?? "");

            if (inquiry == null)
            {
                Console.WriteLine("Inquiry not found.");
                return;
            }


            Console.WriteLine("Update inquiry status");

            InquiryStatus newStatus = Enum.Parse<InquiryStatus>(Utilities.SelectEnumString("inquiry"));
        }

        public static void PrintInquiries()
        {
            List<Inquiry> inqueries = Controller.GetAllInqueries();
            foreach (Inquiry inquiry in inqueries)
            {
                inquiry.PrintInquiry();
            }
        }

        //PrintInquiries metoden er en metode der printer alle inquiries i listen af inquiries.
        public static void PrintInventoryList()
        {
            Console.Clear();
            int gameCount = 1;

            List<Boardgame> boardGames = Controller.GetAllBoardGames();

            foreach (Boardgame boardgame in boardGames)
            {
                Console.WriteLine($"Game: {gameCount}");
                Console.WriteLine(boardgame.ToString());
                Console.WriteLine("---------------------");
            }
        }

        //internal static void AddGame(Boardgame boardgame) => throw new NotImplementedException();


        //PrintInventoryList metoden er en metode der printer alle boardgames i listen af boardgames.
    }
}
