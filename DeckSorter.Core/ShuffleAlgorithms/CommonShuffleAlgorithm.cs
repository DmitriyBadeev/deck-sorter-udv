using System;
using System.Collections.Generic;
using DeckSorter.Core.Entities;
using DeckSorter.Core.Interfaces;

namespace DeckSorter.Core.ShuffleAlgorithms
{
    public class CommonShuffleAlgorithm : IShuffleAlgorithm
    {
        public const string Name = "Common";

        public void Shuffle(Queue<Card> cards)
        {
            var random = new Random();
            
            var cardArray = cards.ToArray();
            for (var i = 0; i < cardArray.Length; i++) {
                var index = random.Next(i, cardArray.Length - 1);
                var temp = cardArray[i];
                cardArray[i] = cardArray[index];
                cardArray[index] = temp;
            }
            
            cards.Clear();
            foreach (var card in cardArray)
            {
                cards.Enqueue(card);
            }
        }
    }
}