using System;
using System.Collections.Generic;
using System.Linq;
using DeckSorter.Core.Enums;
using DeckSorter.Core.Interfaces;

namespace DeckSorter.Core.Entities
{
    public class Deck : IDeck
    {
        public string Name { get; }
        
        public Queue<Card> Cards { get; }

        public Deck(string name)
        {
            Name = name;

            var ranks = Enum.GetValues(typeof(CardRank)).Cast<CardRank>();
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
            Cards = new Queue<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Cards.Enqueue(new Card(rank, suit));
                }
            }
        }

        public void ShuffleCards(IShuffleAlgorithm shuffleAlgorithm)
        {
            shuffleAlgorithm.Shuffle(Cards);
        } 
    }
}