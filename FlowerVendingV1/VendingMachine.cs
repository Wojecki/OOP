using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVendingV1
{
    public class VendingMachine
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Witaj w kwiatomacie!");
                Flower.DrawTable(); //rysowanie tabeli
                Console.WriteLine("Wybierz produkt aby rozpocząć transakcję:");

                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 2137)
                {
                    Console.Clear();
                    Admin.Login(); //ukryty ekran logowania i jego funkcjonalność
                }
                else if (opt == 0 || opt > 10) //automat ma statyczną ilość miejsca na produkty w tym przypadku jest to 10
                {
                    Console.WriteLine("Nie ma takiego produktu");
                    Thread.Sleep(5000);
                }
                else
                {
                    var products = Flower.LoadData();
                    var flower = products.FirstOrDefault(f => f.Id == opt); //szukamy kwiatu po ID

                    if (flower == null || flower.Quantity == 0) //sprawdzamy czy kwiat istnieje i czy jest dostępny
                    {
                        Console.WriteLine("Wybrany kwiat jest niedostępny.");
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        //przechodzimy do płatności
                        bool paymentSuccess = Payment.ChoosePayment(); //dodajemy zwrócenie wartości true/false po zakończeniu płatności

                        //po zakończeniu płatności, jeśli było udane, aktualizujemy ilość
                        if (paymentSuccess)
                        {
                            StockManager.UpdateStock(flower.Id);
                        }
                        else
                        {
                            Console.WriteLine("Płatność nie została zakończona, kwiat nie zostanie wydany.");
                        }
                    }
                }
            }
        }
    }

}
