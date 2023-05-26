using ECommerce.Data;
using ECommerce.Entities;
using ECommerce.Service;

namespace ECommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. Upate metodunda boş geçersek (enter'a tıklarsak) o alanı güncelleme
            //Ürünün yeni adını girin:
            // Menü diye bir metot tanımlayın (ECommerceService)
            //1 - Kategori
            //2 - Ürün
            //3 - Müşteri
            //Seçim: 2
            //1 - Ürün Ekle
            //2 - Ürün Listele
            //İşlem: 1 (productService.Create())

            //Bunu github'a yükle


            ECommerceService eCommerce = new ECommerceService();
            eCommerce.Run();


        }
    }



}


