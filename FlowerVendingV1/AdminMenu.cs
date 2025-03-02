using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVendingV1
{
    internal class AdminMenu : VendingMachine
    {
        public void ShowAdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu Administracji");
                Console.WriteLine("1. Otwórz kwiatomat");
                Console.WriteLine("2. Dodaj kwiaty");
                Console.WriteLine("3. Odejmij kwiaty");
                Console.WriteLine("4. Wyloguj");
                Console.WriteLine("Wybierz operację: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        OpenVendingMachine(); //otwarcie automatu aby towarować
                        break;
                    case 2:
                        AddFlowers(); //dodawanie kwiatów - ręczna aktualizacja stanów magazynowych
                        break;
                    case 3:
                        RemoveFlowers(); //odejmowanie kwiatów
                        break;
                    case 4:
                        return; //wyjście do głównego menu
                    default:
                        Console.WriteLine("Niepoprawny wybór, spróbuj ponownie");
                        Thread.Sleep(3000);
                        break;
                }
            }
        }
        private void OpenVendingMachine()
        {
            Console.Clear();
            Console.WriteLine("Otwieranie kwiatomatu");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Otwarto kwiatomat");
            Thread.Sleep(3000);
        }

        private void AddFlowers()
        {
            Console.Clear();
            List<CsvMapProd> products = Flower.LoadData();
            Flower.DrawTable();

            Console.WriteLine("Podaj ID kwiatu do dodania");
            int idFlower = Convert.ToInt32(Console.ReadLine());

            if (idFlower == 0 || idFlower > 10)
            {
                Console.WriteLine("Podano niepoprawne ID kwiatu!");
                Thread.Sleep(3000);
                return;
            }

            CsvMapProd flower = null;
            foreach (var item in products)
            {
                if (item.Id == idFlower)
                {
                    flower = item;
                    break;
                }
            }

            if (flower == null)
            {
                Console.WriteLine("Nie znaleziono kwiatu o takim ID.");
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine("Podaj dodawaną ilość: ");
            int flowerQuantity = Convert.ToInt32(Console.ReadLine());

            if (flowerQuantity <= 0 || flowerQuantity > 15)
            {
                Console.WriteLine("Podana ilość nie może być dodana!");
                Thread.Sleep(3000);
                return;
            }

            if (flower.Quantity + flowerQuantity > 15)
            {
                Console.WriteLine("Łączna ilość kwiatów nie może przekroczyć 15!");
                Thread.Sleep(3000);
                return;
            }

            flower.Quantity += flowerQuantity;
            Flower.SaveData(products);
            Console.WriteLine($"Dodano {flowerQuantity} szt. {flower.Name}");
            Thread.Sleep(3000);
        }

        private void RemoveFlowers()
        {
            Console.Clear();
            List<CsvMapProd> products = Flower.LoadData();
            Flower.DrawTable();

            Console.WriteLine("Podaj ID kwiatu do odjęcia");
            int idFlower = Convert.ToInt32(Console.ReadLine());

            if (idFlower == 0 || idFlower > 10)
            {
                Console.WriteLine("Podano niepoprawne ID kwiatu!");
                Thread.Sleep(3000);
                return;
            }

            CsvMapProd flower = null;
            foreach (var item in products)
            {
                if (item.Id == idFlower)
                {
                    flower = item;
                    break;
                }
            }

            if (flower == null)
            {
                Console.WriteLine("Nie znaleziono kwiatu o takim ID.");
                Thread.Sleep(2000);
                return;
            }

            if (flower.Quantity == 0)
            {
                Console.WriteLine("Brak dostępnych kwiatów! Nie można odjąć.");
                Thread.Sleep(3000);
                return;
            }

            Console.WriteLine("Podaj ilość do odjęcia: ");
            int flowerQuantity = Convert.ToInt32(Console.ReadLine());

            if (flowerQuantity <= 0 || flowerQuantity > flower.Quantity)
            {
                Console.WriteLine("Podana ilość jest niepoprawna lub przekracza dostępną liczbę!");
                Thread.Sleep(3000);
                return;
            }

            flower.Quantity -= flowerQuantity;
            Flower.SaveData(products);
            Console.WriteLine($"Odjęto {flowerQuantity} szt. {flower.Name}");
            Thread.Sleep(3000);
        }
    }
}
