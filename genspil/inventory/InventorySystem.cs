using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using genspil.Enums;

namespace genspil.inventory
{
    // Vi bruger en static class til vores InventorySystem da vi ikke vil have at vi skal kunne lave flere instances af den samme klasse.
    public static class InventorySystem
    {
        private static List<Boardgame> _BoardGames = [];
        private static List<Inquiry> _Inquiries = [];


        public static bool DoesGameExsist(string id)
        {
            Boardgame boardgame = GetBoardGame(id);

            return boardgame != null;
        }

        private static Boardgame GetBoardGame(string id) => _BoardGames.Find(x => x.BoardGameId == id) ?? null;

        //AddGame metoden er en metode der tager et boardgame objekt som parameter og tilføjer det til listen af boardgames.
        public static void AddGame(string name, string genre, int minPlayers, int maxPlayers, Condition condition, float price, string boardgameID)
        {
            Boardgame boardgame = new(name, genre, minPlayers, maxPlayers, condition, price, boardgameID);
            _BoardGames.Add(boardgame);
        }

        public static void ChangeGame(string id, int? min = null, int? max = null, string? genre = null, string? name = null, Condition? newCondition = null)
        {
            Boardgame board = GetBoardGame(id);

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
            Boardgame deleteGame = GetBoardGame(Console.ReadLine() ?? "");
            if (deleteGame == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            _BoardGames.Remove(deleteGame);
        }

        public static void SearchGame()
        {
            Console.WriteLine("Enter search term: ");
            string search = Console.ReadLine() ?? "";
            List<Boardgame> searchResults = _BoardGames.FindAll(x => x.Name.Contains(search) || x.Genre.Contains(search) || x.BoardGameId.Contains(search));
            if (searchResults.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }

            foreach (Boardgame boardgame in searchResults)
            {
                boardgame.PrintBoardGame();
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

            _Inquiries.Add(newInquiry);
        }

        //RegisterInquiry metoden er en metode der tager et inquiry objekt som parameter og tilføjer det til customerens liste af inquiries.
        public static void UpdateInquiry()
        {
            Console.WriteLine("Enter customer email: ");
            string customerID = Console.ReadLine() ?? "";
            Inquiry inquiry = _Inquiries.Find(x => x.Email == customerID);

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
            foreach (Inquiry inquiry in _Inquiries)
            {
                inquiry.PrintInquiry();
            }
        }

        //PrintInquiries metoden er en metode der printer alle inquiries i listen af inquiries.
        public static void PrintInventoryList()
        {
            Console.Clear();
            int gameCount = 1;
            foreach (Boardgame boardgame in _BoardGames)
            {
                Console.WriteLine($"Game: {gameCount}");
                boardgame.PrintBoardGame();
            }
        }

        //PrintInventoryList metoden er en metode der printer alle boardgames i listen af boardgames.
    }
}
