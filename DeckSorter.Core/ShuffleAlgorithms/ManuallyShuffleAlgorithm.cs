using System.Collections.Generic;
using DeckSorter.Core.Entities;
using DeckSorter.Core.Interfaces;

namespace DeckSorter.Core.ShuffleAlgorithms
{
    public class ManuallyShuffleAlgorithm : IShuffleAlgorithm
    {
        public const string Name = "Manually";

        public void Shuffle(Queue<Card> cards)
        {
            var iterationCount = 100;
            
            for (var j = 0; j < iterationCount; j++)
            {
                for (var i = 0; i < cards.Count / 2; i++)
                {
                    var card = cards.Dequeue();
                    cards.Enqueue(card);
                }

                for (var i = 0; i < cards.Count / 4; i++)
                {
                    var card = cards.Dequeue();
                    cards.Enqueue(card);
                }
            
                for (var i = 0; i < cards.Count / 8; i++)
                {
                    var card = cards.Dequeue();
                    cards.Enqueue(card);
                }
            
                for (var i = 0; i < cards.Count / 16; i++)
                {
                    var card = cards.Dequeue();
                    cards.Enqueue(card);
                }
            }
        }
    }
}