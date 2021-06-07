using System.Collections.Generic;
using DeckSorter.Core.Entities;

namespace DeckSorter.Core.Interfaces
{
    public interface IDeck
    {
        string Name { get; }
        
        Queue<Card> Cards { get; }

        void ShuffleCards(IShuffleAlgorithm shuffleAlgorithm);
    }
}