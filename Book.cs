using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PT_Lab4
{
    class Book
    {
        [Key]
        public int Id { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Publisher Publisher { get; set; }

        public Book() { }
        public Book(Author author, string title, int year, Publisher publisher)
        {
            Author = author;
            Title = title;
            Year = year;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return $"{Id} {Title} ({Year}) - {Author} - {Publisher}";
        }
    }
}
