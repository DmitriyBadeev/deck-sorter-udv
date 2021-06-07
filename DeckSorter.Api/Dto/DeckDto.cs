using System;
using System.Collections.Generic;
using System.Linq;
using DeckSorter.Core.Entities;

namespace DeckSorter.Api.Dto
{
    public class DeckDto
    {
        public string Name { get; }

        public IEnumerable<CardDto> Cards { get; }

        public DeckDto(Deck deckEntity)
        {
            Name = deckEntity.Name;

            Cards = deckEntity.Cards.Select(card => 
                new CardDto
                {
                    Rank = Enum.GetName(card.Rank), 
                    Suit = Enum.GetName(card.Suit)
                });
        }
    }
}