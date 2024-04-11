using genspil.inventory;
using genspil.Enums;
using genspil.Database;

namespace genspil
{
    internal class Program
    {
        static void AddGame()
        {
            Console.Clear();
            Console.Write("Enter name: ");
            string name = Console.ReadLine() ?? "";

            Console.Clear();

            Console.WriteLine("\nSelect Genre");
            string genre = Utilities.SelectEnumString("genre");

            Console.Write("\nEnter min players: ");
            int minPlayers = Utilities.GetNumberFromInput();

            Console.Write("\nEnter max players: ");
            int maxPlayers = Utilities.GetNumberFromInput();

            Console.Clear();

            Console.WriteLine("\nSelect Condition");
            Condition condition = Enum.Parse<Condition>(Utilities.SelectEnumString("condition"));

            Console.Clear();

            Console.Write("\nEnter price: ");

            float price = Utilities.GetFloatFromInput();

            Console.Write("\nEnter boardgame ID: ");
            string boardgameID = Console.ReadLine() ?? "";

            InventorySystem.AddGame(name, genre, minPlayers, maxPlayers, condition, price, boardgameID);
            DataHandler.SaveBoardGame(new Boardgame(name, genre, minPlayers, maxPlayers, condition, price, boardgameID));
        }
        static void AddInquiry()
        {
            Console.Clear();
            Console.WriteLine("Enter customer name: ");
            string customerName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter customer email: ");
            string customerEmail = Console.ReadLine() ?? "";
            Console.WriteLine("Enter customer ID: ");
            string customerID = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Boardgame name: ");
            string boardgameName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Inquiry ID: ");
            string inquiryID = Console.ReadLine() ?? "";
            InquiryStatus status = Enum.Parse<InquiryStatus>(Utilities.SelectEnumString("inquiry"));

            InventorySystem.RegisterInquiry(status, inquiryID, boardgameName, customerName, customerEmail, customerID, DateTime.Now, true);
        }                              

        static void UpdateInquiryStatus(string? inquiryID = null)
        {
            Console.Clear();
            
            if (inquiryID == null)
            {
                Console.WriteLine("Enter Inquiry ID: ");
                inquiryID = Console.ReadLine() ?? "";
                if (Controller.DoesInquiryExist(inquiryID))
                {
                    Console.WriteLine($"{inquiryID} does not exist");
                    return;
                }
            }
            Console.WriteLine("Change Status: ");
            InventorySystem.changeInquiry(inquiryID, Enum.Parse<InquiryStatus>(Utilities.SelectEnumString("inquiry")));
            
            
        }

        static void ConfirmExit()
        {
            Console.WriteLine("Are you sure you want to exit? (y/n)");
            string exit = Console.ReadLine() ?? "";
            if (exit == "y")
            {
                Environment.Exit(0);
            }
        }

        static void UpdateGame(string? boardID = null)
        {
            Console.Clear();

            if (boardID == null)
            {
                Console.WriteLine("Enter Board ID: ");
                boardID = Console.ReadLine() ?? "";
                if (!Controller.DoesGameExsist(boardID))
                {
                    Console.WriteLine($"{boardID} does not exist");
                    return;
                }
               
            }

            Console.WriteLine("1. Change Minimum Players \n" + 
                "2. Change Maximum Players \n" +
                "3. Change Genre \n" +
                "4. Change Name \n" + 
                "5. Change Condition");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter new number of minimum players: ");
                    InventorySystem.ChangeGame(boardID, Utilities.GetNumberFromInput());
                    break;
                case "2":
                    Console.Write("Enter new number of maximum players: ");
                    InventorySystem.ChangeGame(boardID, null, Utilities.GetNumberFromInput());
                    break;
                case "3":
                    Console.Write("Select Genre");
                    InventorySystem.ChangeGame(boardID, null, null, Utilities.SelectEnumString("genre"));
                    break;
                case "4":
                    Console.Write("Enter new game name: ");
                    InventorySystem.ChangeGame(boardID, null, null, null, Console.ReadLine() ?? "");
                    break;
                case "5":
                    Console.Write("Select Condition");
                    InventorySystem.ChangeGame(boardID, null, null, null, null, Enum.Parse<Condition>(Utilities.SelectEnumString("condition")));
                    break;
            }

            Console.Write("\nDo you wish to change more? (Y/N): ");

            if (Console.ReadLine() == "y")
            {
                UpdateGame(boardID);
            }
        }
        
       

        static void Main()
        {
            DataHandler.LoadBoardgames();
            DataHandler.LoadInquiries();
            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "Genspil Inventory System \n" + 
                    "1. Add game \n" +
                    "2. Update game \n" +
                    "3. Delete game \n" +
                    "4. Search game \n" +
                    "5. Register inquiry \n" +
                    "6. Update Inquiry \n" +
                    "7. Print inventory list \n" +
                    "8. Print customer inquiries \n" +
                    "9. Exit \n" +
                    "Choose an option: "
                );

            switch (Console.ReadLine() ?? "")
            {
                case "1":
                    AddGame();
                    break;
                case "2":
                    UpdateGame();
                    break;
                case "3":
                    InventorySystem.DeleteGame();
                    break;
                case "4":
                    InventorySystem.SearchGame();
                    break;
                case "5":
                    AddInquiry();
                    break;
                case "6":
                        UpdateInquiryStatus();
                    break;
                case "7":
                    InventorySystem.PrintInventoryList();
                    break;
                case "8":
                    InventorySystem.PrintInquiries();
                    break;
                case "9":
                    ConfirmExit();
                    break;
               }

                Console.WriteLine("press any key to go back to main menu");
                Console.ReadKey();
            }


        }
    }
}
