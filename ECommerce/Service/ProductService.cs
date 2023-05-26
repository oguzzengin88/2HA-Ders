using ECommerce.Data;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class ProductService
    {

        #region Ödev
        /*

        Görev: Create, Update, Delete ve GetAll metotlarını bu çıktıyı verecek şekilde refactor et.


        Ürün adını girin: Asus Bilgisayar
        Ürün fiyatını girin: 25000
        Ürün stok adedini girin: 30

        Kategoriler: 
        1 - Bilgisayarlar
        2 - Telefonlar
        3 - Kulaklıklar
        Ürünün kategorisini seçin:  1

        Ürün Eklendi


        -----

        GetAll();             (product.Category.Name)
        1 - Asus Bilgisayar / Bilgisayarlar - 25000 - 30

        */
        #endregion


        Database _database;
        //Constructor Injection
        public ProductService(Database database)
        {
            _database = database;
        }

        //Dependency Injection

        public void Create()
        {
            Product product = new Product();
            Console.Write("Ürünün adını girin: ");
            product.Name = Console.ReadLine();

            Console.Write("Ürünün fiyatını girin: ");
            product.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Ürünün stok adedini girin: ");
            product.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Kategoriler");

            //var categoryList = _database.Categories.ToList();


            foreach (var category in _database.Categories)
            {
                Console.WriteLine($"{category.Id} - {category.Name}");
            }
            Console.Write("Ürünün kategorisini seçin: ");

            product.CategoryId = int.Parse(Console.ReadLine());


            _database.Products.Add(product);
            _database.SaveChanges();

        }

        public void Update()
        {
            Console.WriteLine("Ürünler");
            Console.WriteLine("--------------");
            GetAll();
            Console.Write("Güncellenecek ürünün Id'si: ");
            int id = int.Parse(Console.ReadLine());
            Product productToUpdate = _database.Products.FirstOrDefault(x => x.Id == id);

            Console.Write("Ürünün yeni adını girin: ");
            productToUpdate.Name = Console.ReadLine();

            Console.Write("Ürünün yeni fiyatını girin: ");
            productToUpdate.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Ürünün yeni stok adedini girin: ");
            productToUpdate.Stock = int.Parse(Console.ReadLine());

            _database.Products.Update(productToUpdate);
            _database.SaveChanges();
        }

        //CRUD (Create, Read, Update, Delete)

        public void Delete()
        {
            Console.WriteLine("Ürünler");
            Console.WriteLine("--------------");
            GetAll();
            Console.Write("Silinecek ürünün Id'si: ");
            int id = int.Parse(Console.ReadLine());
            Product productToDelete = _database.Products.FirstOrDefault(x => x.Id == id);

            Console.WriteLine($"Silinecek ürün: {productToDelete.Name}");
            Console.Write("Silmek istediğinize emin misiniz? (E/H): ");
            if (Console.ReadLine().ToUpper() == "E") //e E
            {

                _database.Products.Remove(productToDelete);
                _database.SaveChanges();
            }
          
        }

        //Seed ekleme
        public void AddSeedData()
        {
            _database.Products.Add(new Product() { Name="Asus Bilgisayar", CategoryId = 3, Price=20000, Stock=15 });
            _database.Products.Add(new Product() { Name="Lenovo Bilgisayar", CategoryId = 3, Price =15000, Stock=20 });
            _database.Products.Add(new Product() { Name="Apple Telefon", CategoryId = 2, Price =23000, Stock=30 });
            _database.Products.Add(new Product() { Name="Samsung Telefon", CategoryId = 2, Price =27000, Stock=25 });
            _database.Products.Add(new Product() { Name="Kulaklık", CategoryId = 1, Price =500, Stock=100 });
            _database.SaveChanges();
        }


        public void GetAll()
        {
            List<Product> liste = new List<Product>();

            liste = _database.Products.OrderBy(p=>p.Id).ToList();

            foreach (var product in liste)
            {
                Console.WriteLine($"{product.Id} - {product.Name} / {product.Category.Name} - {product.Price} - {product.Stock}");

                //1 - Asus Bilgisayar / Bilgisayarlar - 25000 - 30
                //Console.WriteLine(product.Id + "- Ürün Adı: " + product.Name + " Fiyat: " + product.Price + "(" + product.Stock + ")");
            }
        }
    }
}



