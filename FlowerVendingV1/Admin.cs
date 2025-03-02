using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVendingV1
{
    internal class Admin : User
    {
        public static void Login()
        {
            User user = new User();

            Console.Write("Podaj nazwę użytkownika: ");
            string username = Console.ReadLine();

            Console.Write("Podaj hasło: ");
            string password = Console.ReadLine();

            bool isAuthenticated = user.Authenticate(username, password);

            if (isAuthenticated)
            {
                Console.WriteLine("Zalogowano pomyślnie.");
                Thread.Sleep(3000);
                AdminMenu adminmenu = new AdminMenu();
                adminmenu.ShowAdminMenu(); //menu przeznaczone dla administratora
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Błąd logowania. Sprawdź nazwę użytkownika i hasło.");
                Thread.Sleep(5000);
            }
        }
    }
}
