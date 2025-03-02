using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVendingV1
{
    internal class CreditCard : Payment
    {
        public override bool ProcessPayment()
        {
            Console.WriteLine("Zbliż kartę do terminala");
            int a = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (i <= 3)
            {
                if (a == 1) //symulacja pracy terminala płatniczego
                {
                    Console.WriteLine("Płatność zakończona pomyślnie.\nWydawanie produktu.");
                    Thread.Sleep(3000);
                    return true; // płatność zakończona sukcesem
                }
                else
                { //symulacja błędu
                    i++;
                    if (i == 3) //powrót po 3 próbach
                    {
                        Console.WriteLine("Przekroczono limit płatności!\nSpróbuj ponownie później.");
                        Thread.Sleep(3000);
                        break;
                    }
                    Console.WriteLine("Błąd podczas przetwarzania płatności lub brak środków na koncie.\nSpróbuj ponownie:");
                    a = Convert.ToInt32(Console.ReadLine());
                }
            }

            return false; // płatność nieudana
        }
    }

}
