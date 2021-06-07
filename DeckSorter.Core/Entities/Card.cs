using DeckSorter.Core.Enums;
using DeckSorter.Core.Interfaces;

namespace DeckSorter.Core.Entities
{
    public class Card : ICard
    {
        public CardRank Rank { get; }
        
        public CardSuit Suit { get; }

        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }
}