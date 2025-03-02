using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FlowerVendingV1
{
    internal class Flower : CsvMapProd
    {
        private static string filePath = "Flowers.csv";

        //metoda do wczytania danych z csv do listy obiektów CsvMapProd
        internal static List<CsvMapProd> LoadData()
        {
            List<CsvMapProd> products = new List<CsvMapProd>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //wczytanie danych do listy
                products = csv.GetRecords<CsvMapProd>().ToList();
            }

            return products;
        }

        //metoda do generowania i wyświetlania tabeli
        public static void DrawTable()
        {
            //wczytanie danych o kwiatach
            List<CsvMapProd> products = LoadData();

            var table = new System.Text.StringBuilder();

            //definicja nagłówka tabeli
            table.AppendLine($"{"ID",-5}{"Name",-25}{"Quantity",-10}{"Price",-10}");
            table.AppendLine(new string('-', 50));

            //dodanie produktów do tabeli
            foreach (var product in products)
            {
                table.AppendLine(product.DrawProductRow()); //wywołanie metody DrawProductRow z klasy CsvMapProd
            }

            Console.WriteLine(table.ToString()); //wyświetlenie tabeli jako string
        }

        //metoda do zapisu danych
        internal static void SaveData(List<CsvMapProd> products)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(products);
            }
        }
    }
}
