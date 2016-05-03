using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Application.Data;

namespace Application.Service.Services
{
    public class ProductService: IProductService
    {
        private ProductEntities db = new ProductEntities();
        public List<Product> GetProducts()
        {
            return db.Product.ToList();
        }

        public Product GetProduct(int id)
        {
            return db.Product.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveProduct(Product product)
        {
            try
            {
                db.Product.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProduct(int id, Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var product = db.Product.FirstOrDefault(x => x.Id == id);
                if (product == null) return false;
                db.Entry(product).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}