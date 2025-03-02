using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVendingV1
{
    internal class Blik : Payment
    {
        public override bool ProcessPayment()
        {
            string blikCode;
            int i = 0;

            while (i < 3)
            {
                Console.Write("Podaj kod BLIK: ");
                blikCode = Console.ReadLine();

                if (blikCode.Length == 6 && blikCode.All(char.IsDigit))
                {
                    Console.WriteLine("Przetwarzanie płatności BLIK...");
                    Thread.Sleep(3000);
                    Console.WriteLine("Płatność BLIK zakończona sukcesem!");
                    Console.WriteLine("Wydawanie Produktu...");
                    Thread.Sleep(3000);
                    return true; // płatność zakończona sukcesem
                }
                else
                {
                    i++;
                    Console.WriteLine($"Błąd: Kod BLIK musi składać się z dokładnie 6 cyfr!");
                }
            }

            Console.WriteLine("Przekroczono maksymalną liczbę prób. Płatność anulowana.");
            Thread.Sleep(3000);
            return false; // płatność nieudana
        }
    }


}
