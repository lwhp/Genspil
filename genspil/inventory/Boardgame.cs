using genspil.Enums;

namespace genspil.inventory
{
    public class Boardgame(string name, string genre, int minPlayers, int maxPlayers, Condition conditions, float price, string boardgameID)
    {
        public string BoardGameId
        {
            get { return boardgameID; }
        }

        public string Genre
        {
            get { return genre; }
        }

        public string Name
        {
            get { return name; }
        }

        public void ChangeBoardSettings(int? min = null, int? max = null, string? newGenre = null, string? newName = null, Condition? newCondition = null)
        {
            minPlayers = min ?? minPlayers;
            maxPlayers = max ?? maxPlayers;
            genre = newGenre ?? genre;
            name = newName ?? name;
            conditions = newCondition ?? conditions;
        }

        public string ToString() => $"Name: {name}\n" +
            $"Genre: {genre}\n" +
            $"Players: {minPlayers} - {maxPlayers}\n" +
            $"Condition: {conditions}\n" +
            $"Price: {price}\n" +
            $"Boardgame ID: {BoardGameId}";

        public string MakeTitle() => $"{name},{genre},{minPlayers},{maxPlayers},{conditions},{price},{boardgameID}";
    }
}
