using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace LiblaryExamAgeev
{
    class Library
    {
        public long Id { get; set; }
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
        public List<UserCard> Usercards { get; set; }

        public Library(long id)
        {
            Id = id;
            Books = new List<Book>();
            Users = new List<User>();
        }

        public void addUser(User newUser)
        {
            var isExist = Users.Exists(newUser.Equals);

            if (!isExist)
            {
                this.Users.Add(newUser);
            }
        }

        public void addUsercards(UserCard newUsercards)
        {
            var isExist = Users.Exists(newUsercards.Equals);

            if (!isExist)
            {
                this.Usercards.Add(newUsercards);
            }
        }

        public void addBook(Book newBook)
        {
            var isExist = Users.Exists(newBook.Equals);

            if (!isExist)
            {
                this.Books.Add(newBook);
            }
        }

        public void DeleteBook(Book book)
        {
            var isExist = Users.Exists(book.Equals);

            if (isExist)
            {
                this.Books.Remove(book);
            }
        }

        public void TakeBook(User user, Book book)
        {
            UserCard findCard = (from uc in this.Usercards
                                 where uc.UserId == user.Id
                                 select uc).First();
            findCard.addHistoryItem(book.Id, DateTime.Now);


        }

        
        public Book GetBookByTitle(string title)
        {
            return (from b in this.Books
                    where b.Title == title
                    select b).First();
        }

        public IEnumerable<Book> GetBookByGenre(string genre)
        {
            return from b in this.Books
                   where b.Genre == genre
                   select b;
        }

        public IEnumerable<Book> GetBooksByAutor(string autor)
        {
            return from b in this.Books
                   where b.Author == autor
                   select b;
        }

        public Book GetMostRaited()
        {
            return (from b in this.Books
                    where b.Rating == (from b1 in this.Books
                                       select b1.Rating).Max()
                    select b).First();
        }

        public void BooksSaveToXML()
        {
            XDocument xdoc = new XDocument();
            XElement root = new XElement("books");
            foreach (var item in Books)
            {
                XElement currentElement = new XElement("book");

                currentElement.Add(new XAttribute("Id", item.Id));
                currentElement.Add(new XAttribute("Title", item.Title));
                currentElement.Add(new XAttribute("Author", item.Author));
                currentElement.Add(new XAttribute("Genre", item.Genre));
                currentElement.Add(new XAttribute("YearPublished", item.YearPublished));
                currentElement.Add(new XAttribute("Publisher", item.Publisher));
                currentElement.Add(new XAttribute("Rating", item.Rating));

                root.Add(currentElement);
            }
            xdoc.Add(root);
            xdoc.Save("books.xml");
        }

        public void BookDeleteFromXML(Book book)
        {
            XDocument xdoc = XDocument.Load("books.xml");
            XElement root = xdoc.Element("books");
           
                foreach (XElement xe in root.Elements("book").ToList())
                {
               
                    if (xe.Attribute("Id").Value.Equals(book.Id.ToString()))
                    {
                        xe.Remove();
                    }
                }
                xdoc.Save("books.xml");
           
        }
    }
}
