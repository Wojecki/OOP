using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVendingV1
{
    internal class StockManager : Flower
    {
        public static void UpdateStock(int flowerId)
        {
            var products = LoadData();

            //szukanie kwiatu po id
            CsvMapProd flower = null; //utowrzenie pustej zmiennej

            foreach (var item in products) //przechodzimy przez listę produktów
            {
                if (item.Id == flowerId) //sprawdzamy czy ID pasuje
                {
                    flower = item; //przypisujemy znaleziony obiekt
                    break;
                }
            }

            if (flower != null && flower.Quantity > 0)
            {
                flower.Quantity -= 1; //zmniejszenie stanu o 1
                SaveData(products);   //zapis do CSV
                Console.WriteLine($"Stan kwiatu {flower.Name} został zaktualizowany.");
            }
            else
            {
                Console.WriteLine($"Brak dostępnych sztuk kwiatu o ID {flowerId}."); //gdy stan wynosi 0
            }
        }
    }
}
