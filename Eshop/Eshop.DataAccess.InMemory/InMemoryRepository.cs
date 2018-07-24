using Eshop.Core.Contracts;
using Eshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cashe = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            //Rename the class from Models and save to className
            //we will use for deferent memory cache
            className = typeof(T).Name;
            items = cashe[className] as List<T>;

            //If items is null create new list
            if (items == null)
            {
                items = new List<T>();
            }
        }

        //Commit to cash memory
        public void Commit()
        {
            cashe[className] = items;
        }

        //
        public void Create(T t)
        {
            items.Add(t);
        }

        //
        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);

            if(tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + "Not found");
            }
        }

        //
        public T Find(string Id)
        {
            T tToFind = items.Find(i => i.Id == Id);

            if(tToFind != null)
            {
                return tToFind;
            }
            else
            {
                throw new Exception(className + "Not found");
            }
        }

        //
        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        //
        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);

            if(tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + "Not found");
            }
        }
    }
}
