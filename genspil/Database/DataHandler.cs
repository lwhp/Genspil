using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using genspil.Enums;
using genspil.inventory;
using System.Xml.Linq;
using System.IO;

namespace genspil.Database
{
    public class DataHandler(string dataFileName)
    {
        public string DataFileName { get; } = dataFileName;

        public List<Boardgame> LoadBoardgames()
        {
            List<Boardgame> boardgames = new List<Boardgame>();
            using (StreamReader reader = new StreamReader(DataFileName))
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
        public Boardgame SaveBoardGame(Boardgame boardgame)
        {

            StreamWriter writer = new StreamWriter(DataFileName, true);
            {
                writer.WriteLine(boardgame.MakeTitle());
            }
            writer.Close();

            return boardgame;

        }
        public void DeleteBoardGame(string boardgameID)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(DataFileName))
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
            using (StreamWriter writer = new StreamWriter(DataFileName))
            {
                foreach (string line in lines) // Write all the lines back to the file, except the one we want to delete
                {
                    writer.WriteLine(line);
                }
            }
        }
    }    
}
