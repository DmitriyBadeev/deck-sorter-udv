using System;
using System.Collections.Generic;
using DeckSorter.Core.Interfaces;

namespace DeckSorter.Core.Entities
{
    public class DeckRepository : IRepository<Deck>
    {
        private readonly List<Deck> _decks;
        
        public DeckRepository()
        {
            _decks = new List<Deck>();
        }
        
        public IEnumerable<Deck> GetAll()
        {
            return _decks;
        }

        public Deck Get(string name)
        {
            return _decks.Find(d => d.Name == name);
        }

        public void Create(string name)
        {
            if (Get(name) != null)
            {
                throw new Exception($"Колода с именем {name} уже существует");
            }
            
            var deck = new Deck(name);
            _decks.Add(deck);
        }

        public void Update(Deck item)
        {
            var deckIndex = _decks.FindIndex(d => d.Name == item.Name);

            if (deckIndex != -1)
            {
                _decks[deckIndex] = item;
            }
        }

        public void Delete(string name)
        {
            var deckIndex = _decks.FindIndex(d => d.Name == name);

            if (deckIndex == -1)
            {
                throw new Exception($"Колода с именем {name} не найдена");
            }

            _decks.RemoveAt(deckIndex);
        }
    }
}