using System.Runtime.CompilerServices;
using System.Xml.Linq;
using genspil.inventory;
using genspil.Enums;

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
            Condition condition = (Condition)Enum.Parse(typeof(Condition), Utilities.SelectEnumString("condition"));

            Console.Clear();

            Console.Write("\nEnter price: ");

            float price = Utilities.GetFloatFromInput();

            Console.Write("\nEnter boardgame ID: ");
            string boardgameID = Console.ReadLine() ?? "";

            InventorySystem.AddGame(name, genre, minPlayers, maxPlayers, condition, price, boardgameID);
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
                if (!InventorySystem.DoesGameExsist(boardID))
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
                    Console.Write("Enter new genre: ");
                    InventorySystem.ChangeGame(boardID, null, null, Console.ReadLine() ?? "");
                    break;
                case "4":
                    Console.Write("Enter new game name: ");
                    InventorySystem.ChangeGame(boardID, null, null, null, Console.ReadLine() ?? "");
                    break;
                case "5":
                    Console.Write("Enter new condition: ");
                    InventorySystem.ChangeGame(boardID, null, null, null, null, (Condition)Enum.Parse(typeof(Condition), Utilities.SelectEnumString("condition")));
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
                    InventorySystem.RegisterInquiry();
                    break;
                case "6":
                    InventorySystem.UpdateInquiry();
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
