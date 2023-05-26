using ECommerce.Data;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public class ECommerceService
    {


        public void Run()
        {
            Database database = new Database();
            CategoryService categoryService = new CategoryService(database);
            ProductService productService = new ProductService(database);


            categoryService.AddSeedData();
            productService.AddSeedData();
            //productService.Delete();
            productService.GetAll();
            //productService.Create();
            //productService.GetAll();
            productService.Update();
            productService.GetAll();

            //productService.GetAll();
            //productService.Create();
            //productService.GetAll();
            //productService.GetAll();

        }

        private static void CustomerDemo(Database database)
        {
            CustomerService customerService = new CustomerService(database);

            customerService.Create();
            customerService.GetAll();
            customerService.Create();
            customerService.GetAll();
            customerService.Update();
            customerService.GetAll();
        }

        private static void CategoryDemo()
        {
            Database database = new Database();
            CategoryService categoryService = new CategoryService(database);

            //categoryService.AddFakeData(database);
            categoryService.GetAll();
            Console.WriteLine("--------------------------------");
            categoryService.Create();
            Console.WriteLine("--------------------------------");
            categoryService.GetAll();
            Console.WriteLine("--------------------------------");
            categoryService.Delete();
            Console.WriteLine("--------------------------------");
            categoryService.GetAll();
        }
    }
}
