using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil.Enums
{
    public enum Condition
    {
        New,
        Used,
        Damaged
    }

    public enum Genre
    {
        AbstractStrategy,
        Adventure,
        AreaControl,
        CardDrafting,
        Cooperative,
        DeckBuilding,
        DiceRolling,
        Economic,
        Family,
        Party,
        Solo,
        Warfare,
        WorkerPlacement,
    }

    public enum SubGenre
    {
        AuctionBidding,
        BluffingNegotiation,
        Deduction,
        Legacy,
        WordGame,
        DexterityGame,
        TriviaGame,
        RealtimeStrategy,
        Wargame
    }
}
