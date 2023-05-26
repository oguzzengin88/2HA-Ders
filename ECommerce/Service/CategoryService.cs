using ECommerce.Data;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class CategoryService
    {

        Database _database;

        public CategoryService(Database database)
        {
            _database = database;
        }

        public void Create()
        {
            Category category = new Category();
            Console.Write("Kategori Adı: ");
            category.Name = Console.ReadLine();

            Console.Write("Kategori Açıklaması: ");
            category.Description = Console.ReadLine();

            _database.Categories.Add(category);

            _database.SaveChanges();
        }

        public void GetAll()
        {
            foreach (var category in _database.Categories)
            {
                Console.WriteLine($"{category.Id} - {category.Name} - {category.Description}");
            }
        }

        public void Delete()
        {
            GetAll();
            Console.Write("Silinecek kategorinin Id'sini girin: ");
            int id = int.Parse(Console.ReadLine());
            Category categoryToDelete = _database.Categories.FirstOrDefault(c => c.Id == id);
            _database.Categories.Remove(categoryToDelete);
            _database.SaveChanges();
        }


        public void AddFakeData()
        {
            Category category1 = new Category() { Id = 1, Name = "Elektronik", Description = "Elektronik Kategorisi" };
            Category category2 = new Category() { Id = 2, Name = "Telefon", Description = "Telefon Kategorisi" };
            Category category3 = new Category() { Id = 3, Name = "Bilgisayar", Description = "Bilgisayar Kategorisi" };

            _database.Categories.Add(category1);
            _database.Categories.Add(category2);
            _database.Categories.Add(category3);
            _database.SaveChanges();
        }
    }
}
