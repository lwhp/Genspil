using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using genspil.Enums;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace genspil.inventory
{
    public class Boardgame(string name, string genre, int minPlayers, int maxPlayers, Condition conditions, float price, string boardgameID)
        //har sat boardgame klassen til public for at få datahandler til at kunne tilgå den
    {
        public string Name { get; } = name;
        public string Genre { get; } = genre; 
        //public int MinPlayers { get; set; } = minPlayers;
        //public int MaxPlayers { get; set; } = maxPlayers;
        //public Condition Conditions { get; set; } = conditions;
        //public float Price { get; set; } = price;
        public string BoardGameId { get; } = boardgameID;

        public void ChangeBoardSettings(int? min = null, int? max = null, string? newGenre = null, string? newName = null, Condition? newCondition = null)
        {
            minPlayers = min ?? minPlayers;
            maxPlayers = max ?? maxPlayers;
            genre = newGenre ?? genre;
            name = newName ?? name;
            conditions = newCondition ?? conditions;
        }

        public void PrintBoardGame()
        {
            Console.WriteLine("Name: {0} \n" +
                "Genre: {1} \n" +
                "Players: {2} - {3} \n" +
                "Condition: {4} \n" +
                "Price: {5} \n" +
                "Boardgame ID: {6} \n" +
                "--------------------------",
                name, genre, minPlayers, maxPlayers, conditions, price, boardgameID);
        }

        public string MakeTitle()
        {
            return $"{name},{genre},{minPlayers},{maxPlayers},{conditions},{price},{boardgameID}";
        }


    }
}
