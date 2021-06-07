using DeckSorter.Core.Enums;

namespace DeckSorter.Core.Interfaces
{
    public interface ICard 
    {
        CardRank Rank { get; }

        CardSuit Suit { get; }
    }
}