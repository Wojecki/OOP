using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlowerVendingV1
{
    internal class CsvMapProd : VendingMachine
    {
        [Name("Id")]    //map kolumny Id na id
        public int Id { get; set; }
        [Name("Name")]  //map kolumny Name na name
        public string Name { get; set; }
        [Name("Quantity")]  //map kolumny Quantity na quantity
        public int Quantity { get; set; }
        [Name("Price")] //map kolumny Price na price
        public float Price { get; set; }
        public string DrawProductRow()
        {
            return $"{Id,-5}{Name,-25}{Quantity,-10}{Price,-10:F2}";
        }
    }
}
