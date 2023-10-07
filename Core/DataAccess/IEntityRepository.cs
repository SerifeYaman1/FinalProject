using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint - generic kısıt demektir.
    //class-referans tip olabilir demektir.
    // ya IEntity olabilir ya da IEntitiyi implemente eden bir nesne olabilir.
    //new() : new'lenebilir olmalı(IEntity newlenemez oldupu için o da yazılamaz sadece veritabanı nesneleriyle çalışabilen bir repository oldu.--STANDART OLUŞTURMA )
    public interface IEntityRepository<T> where T : class, IEntity, new() // Çalışılan tip neyse o gelir. Generic Yapılar. Bunun sebebi sürekli aynı yapıyı kullanırız.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // belli ürünleri getirmesi için filtre verilir.
        T Get(Expression<Func<T, bool>> filter); //Bir sistemde bir şeyin detayına inmek için 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategory(int categoryId); //Ürünleri category'ye göre filtrele. (İhtiyaç kalmadı->T Get geldi )
    }
}
