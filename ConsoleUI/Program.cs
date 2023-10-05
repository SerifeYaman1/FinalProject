using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID- O: Open Closed Principle: Yapılan yazılıma yeni bir özellik eklendiğinde mevcut kodlar değiştirilmez.
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); //InMemory'nin de referansını tutar.Ve orada çalır.
            foreach (var product in productManager.GetAllUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
