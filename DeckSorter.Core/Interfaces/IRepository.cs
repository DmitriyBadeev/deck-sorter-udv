using System.Collections.Generic;

namespace DeckSorter.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string name);
        void Create(string item);
        void Update(TEntity item);
        void Delete(string name);
    }
}