using genspil.Enums;
using genspil.inventory;

namespace genspil.Database
{
    public static class DataHandler
    {
        public static List<Boardgame> LoadBoardgames()
        {
            List<Boardgame> boardgames = [];
            using (StreamReader reader = new("BoardGames.txt"))
            {
                string line;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string name = parts[0];
                    string genre = parts[1];
                    int minPlayers = int.Parse(parts[2]);
                    int maxPlayers = int.Parse(parts[3]);
                    Condition conditions = (Condition)Enum.Parse(typeof(Condition), parts[4]);
                    float price = float.Parse(parts[5]);
                    string boardgameID = parts[6];

                    InventorySystem.AddGame(name, genre, minPlayers, maxPlayers, conditions, price, boardgameID);
                    

                }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }

            return boardgames;
        }
        public static Boardgame SaveBoardGame(Boardgame boardgame)
        {
            StreamWriter writer = new("BoardGames.txt", true);
            {
                writer.WriteLine(boardgame.MakeTitle());
            }
            writer.Close();

            return boardgame;
        }

        public static void SaveBoardGameChanges(Boardgame boardgame)
        {
            DeleteBoardGame(boardgame.BoardGameId);
            SaveBoardGame(boardgame);
        }

        public static void SaveInquiryChanges(Inquiry inquiry)
        {
            DeleteInquiry(inquiry.InquiryID);
            SaveInquiry(inquiry);
        }

        public static void DeleteInquiry(string inquiryID)
        {
            List<string> lines = [];
            using (StreamReader reader = new("Inquiries.txt"))
            {
                string line;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                while ((line = reader.ReadLine()) != null) // Read the file and display it line by line.
                {
                    string[] parts = line.Split(','); // Split the line into parts

                    if (parts[5] == inquiryID) // If the ID matches the ID we want to delete, skip this line
                    {
                        continue;
                    }
                    lines.Add(line); // Add the line to the list of lines
                }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }

            using StreamWriter writer = new("Inquiries.txt");
            foreach (string line in lines) // Write all the lines back to the file, except the one we want to delete
            {
                writer.WriteLine(line);
            }
        }

        public static void DeleteBoardGame(string boardgameID)
        {
            List<string> lines = [];
            using (StreamReader reader = new("BoardGames.txt"))
            {
                string line;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                while ((line = reader.ReadLine()) != null) // Read the file and display it line by line.
                {
                    string[] parts = line.Split(','); // Split the line into parts

                    if (parts[6] == boardgameID) // If the ID matches the ID we want to delete, skip this line
                    {
                        continue;
                    }
                    lines.Add(line); // Add the line to the list of lines
                }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }

            using StreamWriter writer = new("BoardGames.txt");
            foreach (string line in lines) // Write all the lines back to the file, except the one we want to delete
            {
                writer.WriteLine(line);
            }
        }

        public static List<Inquiry> LoadInquiries()
        {
            List<Inquiry> inquiries = [];
            using (StreamReader reader = new("Inquiries.txt"))
            {
                string line;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    InquiryStatus status = (InquiryStatus)Enum.Parse(typeof(InquiryStatus), parts[0]);
                    string inquiryID = parts[1];
                    string boardgameName = parts[2];
                    string customerName = parts[3];
                    string customerEmail = parts[4];
                    string customerID = parts[5];
                    DateTime creationDate = DateTime.Parse(parts[6]);

                    InventorySystem.RegisterInquiry(status, inquiryID, boardgameName, customerName, customerEmail, customerID, creationDate);
                } 
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            return inquiries;
        }

        public static Inquiry SaveInquiry(Inquiry inquiry)
        {
            StreamWriter writer = new("Inquiries.txt", true);
            {
                writer.WriteLine(inquiry.MakeTitle());
            }
            writer.Close();

            return inquiry;
        }
    }    
}
