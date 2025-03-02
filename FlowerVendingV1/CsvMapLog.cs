using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVendingV1
{
    public class CsvMapLog : VendingMachine
    {
        [Name("Login")] //map kolumny Login na właściwość username
        public string username { get; set; }

        [Name("Password")]  //map kolumny Password na password
        public string password { get; set; }
    }
}
