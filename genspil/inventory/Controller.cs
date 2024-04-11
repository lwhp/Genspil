namespace genspil.inventory
{
    public static class Controller
    {
        private static List<Boardgame> _BoardGames = [];
        private static List<Inquiry> _Inquiries = [];

        public static Boardgame GetBoardGame(string id) => _BoardGames.Find(boardgame => boardgame.BoardGameId == id) ?? null;

        public static Inquiry GetInquiry(string email) => _Inquiries.Find(inquiry => inquiry.Email == email) ?? null;

        public static List<Inquiry> GetAllInqueries() => _Inquiries;

        public static bool DoesGameExsist(string id)
        {
            Boardgame boardgame = GetBoardGame(id);

            return boardgame != null;
        }

        public static List<Boardgame> GetSearchedGames(string searchTerm) => (List<Boardgame>)_BoardGames.Where(boardgame =>
            boardgame.Name.Contains(searchTerm) ||
            boardgame.Genre.Contains(searchTerm) ||
            boardgame.BoardGameId.Contains(searchTerm)).ToList();

        public static List<Boardgame> GetAllBoardGames() => _BoardGames;

        public static void AddGame(Boardgame boardgame)
        {
            _BoardGames.Add(boardgame);

            Console.WriteLine("Boardgame has successfully been added!");
        }

        public static void AddInquiry(Inquiry inquiry)
        {
            _Inquiries.Add(inquiry);
        }

        public static void DeleteGame(string boardGameId)
        {
            Boardgame boardgame = GetBoardGame(boardGameId);

            bool removed = _BoardGames.Remove(boardgame);

            Console.WriteLine("Boardgame was {0} removed", removed ? "Successfully" : "NOT");
        }
    }
}
