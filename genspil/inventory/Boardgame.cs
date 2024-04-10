using genspil.Enums;

namespace genspil.inventory
{
    public class Boardgame(string name, string genre, int minPlayers, int maxPlayers, Condition conditions, float price, string boardgameID)
    {
        public string Name { get; } = name;
        public string Genre { get; } = genre; 

        public string BoardGameId { get; } = boardgameID;

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
