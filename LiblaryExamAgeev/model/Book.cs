using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiblaryExamAgeev
{
    class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int YearPublished { get; set; }
        public string Publisher { get; set; }
        public double Rating { get; set; }

        public Book(long id, string title, string author, string genre, int yearPublished, string publisher, double rating)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            YearPublished = yearPublished;
            Publisher = publisher;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"Id: {this.Id}; " +
                   $"Title: {this.Title}; " +
                   $"Author: {this.Author}; " +
                   $"Genre: {this.Genre}; " +
                   $"YearPublished: {this.YearPublished}; " +
                   $"Publisher: {this.Publisher}; " +
                   $"Rating: {this.Rating}\n";
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;
            return book != null &&
                   Id == book.Id &&
                   Title == book.Title &&
                   Author == book.Author &&
                   Genre == book.Genre &&
                   YearPublished == book.YearPublished &&
                   Publisher == book.Publisher &&
                   Rating == book.Rating;
        }

        public override int GetHashCode()
        {
            var hashCode = -1891000852;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genre);
            hashCode = hashCode * -1521134295 + YearPublished.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Publisher);
            hashCode = hashCode * -1521134295 + Rating.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Book book1, Book book2)
        {
            return EqualityComparer<Book>.Default.Equals(book1, book2);
        }

        public static bool operator !=(Book book1, Book book2)
        {
            return !(book1 == book2);
        }
    }
}
