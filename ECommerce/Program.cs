using ECommerce.Data;
using ECommerce.Entities;
using ECommerce.Service;

namespace ECommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {



            ECommerceService eCommerce = new ECommerceService();
            eCommerce.Run();


        }
    }



}


