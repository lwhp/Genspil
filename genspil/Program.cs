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
