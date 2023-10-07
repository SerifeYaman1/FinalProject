using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    //Category ile dış dünyaya neyi servis etmek istiyorsak onu yazıyoruz.
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);


    }
}
