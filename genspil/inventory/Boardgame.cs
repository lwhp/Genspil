using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using genspil.Enums;
using System.Threading.Tasks;

namespace genspil.inventory
{
    internal class Boardgame(string name, string genre, int minPlayers, int maxPlayers, Condition conditions, float price, string boardgameID)
    {
        public string BoardGameId { get; } = boardgameID;
        public string Name { get; } = name;
        public string Genre { get; } = genre;

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

    }
}
