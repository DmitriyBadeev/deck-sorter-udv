using System.Collections.Generic;
using DeckSorter.Core.Entities;

namespace DeckSorter.Core.Interfaces
{
    public interface IShuffleAlgorithm
    { 
        void Shuffle(Queue<Card> cards);
    }
}