using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil
{
    internal class Boardgame
    {
        public Boardgame(string name, string genre, int minPlayers, int maxPlayers, condition conditions, float price, string boardgameID)
        {
            Name = name;
            Genre = genre;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            Conditions = conditions;
            Price = price;
            BoardgameID = boardgameID;
            
        }

        public string Name { get; set; }
        public string Genre { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public condition Conditions { get; set; }
        public float Price { get; set; }
        public string BoardgameID { get; set; }
        
       
    }public enum condition 
    {
        New,
        Used,
        Damaged
    }
}
