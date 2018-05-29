using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Eshop.Core.Models;

namespace Eshop.DataAccess.InMemory
{
    public class ProductRepository
    {
        //Create an Object cashe for memory
        ObjectCache cashe = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cashe["products"] as List<Product>;

            //If product is null create new list
            if(products == null)
            {
                products = new List<Product>();
            }
        }

        //Commit products to cash
        public void Commit()
        {
            cashe["products"] = products;
        }

        //Insert new product
        public void Insert(Product p)
        {
            products.Add(p);
        }

        //Update a product
        public void Update(Product product)
        {
            //Get an Id of product
            Product productToUpDate = products.Find(p => p.Id == product.Id);

            //If product isn't null
            if(productToUpDate != null)
            {
                productToUpDate = product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        //Find a product
        public Product Find(string Id)
        {
            //Get an Id of product
            Product product = products.Find(p => p.Id == Id);

            //If product isn't null
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        //Delete a product
        public void Delete(string Id)
        {
            //Get an Id of product
            Product productToDelete = products.Find(p => p.Id == Id);

            //If product isn't null
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }
}
