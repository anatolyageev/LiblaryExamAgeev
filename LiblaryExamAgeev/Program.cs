using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiblaryExamAgeev
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library(1);
            Book b1 = new Book(1, "Война и мир", "Лев Толстой", "Исторический роман", 1980, "Эксмо", 5);
            Book b2 = new Book(2, "Война миров", "Герберт Уэллс,", "Фантастический роман", 1980, "Эксмо", 5);
            library.addBook(b1);
            library.addBook(b2);
            library.BooksSaveToXML();
            library.addUser(new User(1, "Анатолий", "Агеев", "9876543213"));
            library.BookDeleteFromXML(b1);
            UserCard uk = new UserCard(1, 1);
            
            Console.ReadLine();
        }
    }
}
