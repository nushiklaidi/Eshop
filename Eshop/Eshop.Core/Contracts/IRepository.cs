using System.Linq;
using Eshop.Core.Models;

namespace Eshop.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Create(T t);
        void Delete(string Id);
        T Find(string Id);
        void Update(T t);
    }
}