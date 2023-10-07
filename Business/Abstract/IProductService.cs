using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService // İş katmanında kullanılacak servis operasyonları
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id); //CategoryID'e göre getir.
        List<Product> GetAllUnitPrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetails();
    }
}
