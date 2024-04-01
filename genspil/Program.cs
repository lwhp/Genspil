using System.Runtime.CompilerServices;

namespace genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventorySystem inventorySystem = new InventorySystem();
            while (true)
            {
             
            Console.WriteLine("Genspil Inventory System");
            Console.WriteLine("1. Add game");
            Console.WriteLine("2. Update game");
            Console.WriteLine("3. Delete game");
            Console.WriteLine("4. Search game");
            Console.WriteLine("5. Register inquiry");
            Console.WriteLine("6. Update Inquiry");
            Console.WriteLine("7. Print inventory list");
            Console.WriteLine("8. Print customer inquiries");
            Console.WriteLine("9. Exit");
            Console.WriteLine("Choose an option: ");
            string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        inventorySystem.AddGame();
                        Console.WriteLine("press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        inventorySystem.UpdateGame();
                        Console.WriteLine("press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        inventorySystem.DeleteGame();
                        Console.WriteLine("press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        inventorySystem.SearchGame();
                        Console.WriteLine("press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        inventorySystem.RegisterInquiry();
                        Console.WriteLine("press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        inventorySystem.UpdateInquiry();
                        Console.WriteLine("press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":
                        inventorySystem.PrintInventoryList();
                        Console.WriteLine("press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "8":
                        inventorySystem.PrintInquiries();
                        Console.WriteLine("press any key to go back to main menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "9":
                       Console.WriteLine("Are you sure you want to exit? (y/n)");
                        string exit = Console.ReadLine();
                        if (exit == "y")
                        {
                            Environment.Exit(0);
                            return;
                        }
                        else
                        {
                            Console.Clear();
                        }
                        break;

                }
            }


        }
    }
}
