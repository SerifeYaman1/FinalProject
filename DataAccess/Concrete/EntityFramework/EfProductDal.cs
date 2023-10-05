using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisponsible pattern implementations of c#
            using (NorthwindContext context =new NorthwindContext()) //belleği hızlıca temizleme
            {
                var addedEntity=context.Entry(entity); //Referansı Yakala (Veri kaynağı ile ilişkilendir.)
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added; //O aslında eklenecek olan nesne 
                context.SaveChanges(); // Ve ekle.
            }
        }

        public void Delete(Product entity)
        {
            using(NorthwindContext context =new NorthwindContext())
            {
                var deletedEntity=context.Entry(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using(NorthwindContext ctx =new NorthwindContext())
            {
                return ctx.Set<Product>().SingleOrDefault(filter);
            }
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList(); 
            }
        }
        public void Update(Product entity)
        {
            using(NorthwindContext ctx =new NorthwindContext())
            {
                var updatedEntity=ctx.Entry(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified; //güncellenecek olan nesne 
                ctx.SaveChanges();
            }
        }
    }
}
