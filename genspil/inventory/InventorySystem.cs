﻿using genspil.Database;
using genspil.Enums;

namespace genspil.inventory
{
    public static class InventorySystem
    {
        //AddGame metoden er en metode der tager et boardgame objekt som parameter og tilføjer det til listen af boardgames.
        public static void AddGame(string name, string genre, int minPlayers, int maxPlayers, Condition condition, float price, string boardgameID)
        {
            bool boardIdExsist = Controller.DoesGameExsist(boardgameID);

            if (boardIdExsist)
            {
                Console.WriteLine("Error! Game already exsist");
                return;
            }

            if (minPlayers > maxPlayers)
            {
                Console.WriteLine("Error! Minimum players cannot be above maximum players!");
                return;
            }

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
            DataHandler.SaveBoardGameChanges(board);
        }

        public static void ChangeInquiry(string id, InquiryStatus newStatus)
        {
            Inquiry inquiry = Controller.GetInquiry(id);
            if (inquiry == null)
            {
                Console.WriteLine("Inquiry not found...");
                return;
            }

            inquiry.UpdateInquiryStatus(newStatus);
            DataHandler.SaveInquiryChanges(inquiry);
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

            DataHandler.DeleteBoardGame(boardgameID);
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
        public static void RegisterInquiry(InquiryStatus status, string boardgameName, string customerName, string customerEmail, string customerID, string inquiryId, DateTime creationDate, bool saveInquery = false)
        {
            Inquiry inquiry = new(status, boardgameName, customerName, customerEmail, customerID, inquiryId, creationDate);
            Controller.AddInquiry(inquiry);

            if (saveInquery)
            {
                DataHandler.SaveInquiry(inquiry);
            }
        }

        public static void PrintInquiries()
        {
            List<Inquiry> inqueries = Controller.GetAllInqueries();
            foreach (Inquiry inquiry in inqueries)
            {
                if (inquiry.Status != InquiryStatus.Resolved & inquiry.Status != InquiryStatus.Closed)
                {
                    inquiry.PrintInquiry();
                }
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
