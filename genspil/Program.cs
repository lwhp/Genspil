using System.Runtime.CompilerServices;
using genspil.inventory;

namespace genspil
{
    internal class Program
    {
        static void AddGame()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Enter genre: ");
            string genre = Console.ReadLine() ?? "";

            Console.WriteLine("Enter min players: ");
            int minPlayers = Utilities.GetNumberFromInput();

            Console.WriteLine("Enter max players: ");
            int maxPlayers = Utilities.GetNumberFromInput();
            
            Console.WriteLine("Enter condition (New, Used, Damaged): ");

            if (!Enum.TryParse(Console.ReadLine() ?? "", true, out Condition condition))
            {
                Console.WriteLine("Invalid condition. Setting to 'New' as default.");
                condition = Condition.New;
            }

            Console.WriteLine("Enter price: ");

            float price = Utilities.GetFloatFromInput();

            Console.WriteLine("Enter boardgame ID: ");
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

            string option = Console.ReadLine() ?? "";

                switch (option)
                {
                    case "1":
                        AddGame();
                        break;
                    case "2":
                        InventorySystem.UpdateGame();
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
