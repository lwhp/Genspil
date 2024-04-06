using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil
{
    internal class Boardgame(string name, string genre, int minPlayers, int maxPlayers, Condition conditions, float price, string boardgameID)
    {
        public string Name { get; set; } = name;
        public string Genre { get; set; } = genre;
        public int MinPlayers { get; set; } = minPlayers;
        public int MaxPlayers { get; set; } = maxPlayers;
        public Condition Conditions { get; set; } = conditions;
        public float Price { get; set; } = price;
        public string BoardgameID { get; set; } = boardgameID;


    }
    public enum Condition 
    {
        New,
        Used,
        Damaged
    }
}
