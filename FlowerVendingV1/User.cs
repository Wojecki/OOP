using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace FlowerVendingV1
{
    internal class User : CsvMapLog
    {
        public bool Authenticate(string inputUsername, string inputPassword)
        {
            string filePath = "Operators.csv";

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CsvMapLog>().ToList();

                foreach (var user in records) // Iteracja po użytkownikach
                {
                    if (user.username == inputUsername && user.password == inputPassword)
                    {
                        return true; // jeśli znaleziono
                    }
                }
            }
            return false; // jeśli nie znaleziono 
        }
    }
}
