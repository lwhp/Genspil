using genspil.Enums;
using genspil.inventory;

namespace genspil.Database
{
    public static class DataHandler
    {
        public static List<Boardgame> LoadBoardgames()
        {
            List<Boardgame> boardgames = new List<Boardgame>();
            using (StreamReader reader = new StreamReader("BoardGames.txt"))
            {
                string line;
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
            }
            return boardgames;
        }
        public static Boardgame SaveBoardGame(Boardgame boardgame)
        {

            StreamWriter writer = new StreamWriter("BoardGames.txt", true);
            {
                writer.WriteLine(boardgame.MakeTitle());
            }
            writer.Close();

            return boardgame;

        }
        public static void DeleteBoardGame(string boardgameID)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader("BoardGames.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null) // Read the file and display it line by line.
                {
                    string[] parts = line.Split(','); // Split the line into parts

                    if (parts[6] == boardgameID) // If the ID matches the ID we want to delete, skip this line
                    {
                        continue;
                    }
                    lines.Add(line); // Add the line to the list of lines
                }
            }
            using (StreamWriter writer = new StreamWriter("BoardGames.txt"))
            {
                foreach (string line in lines) // Write all the lines back to the file, except the one we want to delete
                {
                    writer.WriteLine(line);
                }
            }
        }

        public static List<Inquiry> LoadInquiries()
        {
            List<Inquiry> inquiries = new List<Inquiry>();
            using (StreamReader reader = new StreamReader("Inquiries.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    InquiryStatus status = (InquiryStatus)Enum.Parse(typeof(InquiryStatus), parts[0]);
                    string boardgameName = parts[1];
                    string customerName = parts[2];
                    string customerEmail = parts[3];
                    string customerID = parts[4];
                    DateTime creationDate = DateTime.Parse(parts[5]);

                    InventorySystem.RegisterInquiry(status, boardgameName, customerName, customerEmail, customerID, creationDate);
                }
            }
            return inquiries;
        }

        public static Inquiry SaveInquiry(Inquiry inquiry)
        {
            StreamWriter writer = new StreamWriter("Inquiries.txt", true);
            {
                writer.WriteLine(inquiry.MakeTitle());
            }
            writer.Close();

            return inquiry;
        }
    }    
}
