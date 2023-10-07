using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext ctx = new NorthwindContext())
            {
                //Ürünler ile kategorileri join etmek
                var result = from p in ctx.Products
                             join c in ctx.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto 
                             { 
                                 ProductId = p.ProductId, ProductName = p.ProductName, 
                                 CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock 
                             };
                return result.ToList(); 
            }
        }
    }
}
