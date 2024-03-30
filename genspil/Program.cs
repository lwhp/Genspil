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
            Console.WriteLine("6. Print inventory list");
            Console.WriteLine("7. Print customer inquiries");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Choose an option: ");
            string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                       inventorySystem.AddGame();

                        break;
                    case "2":
                        Console.WriteLine("Enter boardgame ID: ");
                        string updateID = Console.ReadLine();
                        Boardgame updateGame = inventorySystem.Boardgames.Find(x => x.BoardgameID == updateID); //Find game by ID in list of boardgames in inventorySystem object and assign to updateGame variable 
                        Console.WriteLine("Enter new name: ");
                        updateGame.Name = Console.ReadLine();
                        Console.WriteLine("Enter new genre: ");
                        updateGame.Genre = Console.ReadLine();
                        Console.WriteLine("Enter new min players: ");
                        updateGame.MinPlayers = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new max players: ");
                        updateGame.MaxPlayers = int.Parse(Console.ReadLine());
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
                        break;
                    case "3":
                        Console.WriteLine("Enter boardgame ID: ");
                        string deleteID = Console.ReadLine();
                        Boardgame deleteGame = inventorySystem.Boardgames.Find(x => x.BoardgameID == deleteID);
                        inventorySystem.DeleteGame(deleteGame);
                        break;
                    case "4":
                        Console.WriteLine("Enter search term: ");
                        string search = Console.ReadLine();
                        inventorySystem.SearchGame(search);
                        break;
                        //case "5":
                        //    Console.WriteLine("Enter customer name: ");
                        //    string customerName = Console.ReadLine();
                        //    Console.WriteLine("Enter customer email: ");
                        //    string customerEmail = Console.ReadLine();
                        //    Console.WriteLine("Enter customer ID: ");
                        //    string customerID = Console.ReadLine();
                        //    Customer customer = new Customer(customerName, customerEmail, customerID);
                        //    Console.WriteLine("Enter inquiry ID: ");
                        //    string inquiryID = Console.ReadLine();
                        //    Console.WriteLine("Enter inquiry description: ");
                        //    string inquiryDescription = Console.ReadLine();
                        //    Inquiry inquiry = new Inquiry(inquiryID, inquiryDescription, customer);
                        //    inventorySystem.RegisterInquiry(inquiry);
                        //    break;
                        case "6":
                        inventorySystem.PrintInventoryList();
                        Console.WriteLine("press any key to go back to main menu");
                        break;

                }
            }


        }
    }
}
