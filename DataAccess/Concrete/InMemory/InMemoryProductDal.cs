using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // global değişken - veritabanı
        public InMemoryProductDal()
        {
            //Oracle, Sql Server, Postgres, MongoDb'den geliyormuş gibi liste oluşturduk.
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Glass", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Camera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Phone", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Keyboard", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Mouse", UnitPrice=85, UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
        public void Delete(Product product)
        { 
            // LINQ Language Integrated Query
            //Lambda p=>
            Product productToDelete = productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //SingleOrDefault Tek bir elememanı bulmaya yarar.

            //foreach (var p in _products) 
            //{ 
            //    if (product.ProductId==p.ProductId) 
            //    {  
            //        productToDelete = p;
            //    }                          
            //}

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll() // veritabanındaki datayı business'a vermemiz gerekir.
        {
            return _products; // business ürün listesini istediği için.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //Where koşulu içindeki koşula uyan tüm elemanları yeni bir listeye atar ve onu döndürür.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul demektir.
            Product productToUpdate = productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //SingleOrDefault Tek bir elememanı bulmaya yarar.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;   
            productToUpdate.UnitPrice = product.UnitPrice;  
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
