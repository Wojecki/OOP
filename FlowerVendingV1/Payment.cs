using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVendingV1
{

    internal abstract class Payment : VendingMachine
    {
        public abstract bool ProcessPayment(); // Zmienione, aby zwracało bool

        public static bool ChoosePayment()
        {
            Console.Clear();
            Console.WriteLine("Wybierz metodę płatności:");
            Console.WriteLine("Płatność kartą - 1, Płatność Blik - 2");
            int optPay = 0;
            int i = 0;

            while (true) //walidacja czy wybrana forma płatności jest dostępna 1 lub 2
            {
                optPay = Convert.ToInt32(Console.ReadLine());

                if (optPay != 1 && optPay != 2)
                {
                    if (i == 2) //powrót do menu głównego po 3 niepoprawnych wyborach
                    {
                        Console.WriteLine("Przekroczono limit wyboru operacji!");
                        Thread.Sleep(3000);
                        return false; //zwracamy false jeśli użytkownik wielokrotnie wybiera błędną opcję
                    }
                    Console.WriteLine("Brak opcji płatności o takim numerze!\nSpróbuj ponownie:");
                    i++;
                }
                else break;
            }

            switch (optPay) //wybór opcji płatności
            {
                case 1:
                    CreditCard paymentMethodCreditCard = new CreditCard(); //przejście do klasy z płatnością CreditCard
                    return paymentMethodCreditCard.ProcessPayment(); //zwróć wynik przetwarzania płatności
                case 2:
                    Blik paymentMethodBlik = new Blik(); //przejście do klasy z płatnością Blik
                    return paymentMethodBlik.ProcessPayment(); //zwróć wynik przetwarzania płatności
                default: return false;
            }
        }
    }

}
