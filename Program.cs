using System;
using System.Linq;
using System.Collections.Generic;

namespace PT_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new MyDbContext();

            if (args[0].ToLower() == "show")
            {
                if (args[1].ToLower() == "books")
                {
                    var books = db.Books
                        .Include("Publisher")
                        .Include("Author");

                    foreach (var e in books)
                    {
                        Console.WriteLine(e);
                    }
                }

                else if (args[1].ToLower() == "authors")
                {
                    var authors = db.Authors;

                    foreach (var e in authors)
                    {
                        Console.WriteLine(e.Id + " " + e);
                    }
                }

                else if (args[1].ToLower() == "publishers")
                {
                    var publishers = db.Publishers;

                    foreach (var e in publishers)
                    {
                        Console.WriteLine(e.Id + " " + e);
                    }
                }

                else
                    Console.WriteLine("Unrecognized request.");
            }

            else if (args[0].ToLower() == "add")
            {
                if (args[1].ToLower() == "book")
                {
                    if (args.Length < 7)
                        Console.WriteLine("Unrecognized request.");
                    else
                    {
                        List<Author> authors = db.Authors.ToList<Author>();
                        Author author = authors
                                .Where(at => at.FirstName == args[2] && at.LastName == args[3])
                                .FirstOrDefault();
                        if (author is null)
                        {
                            author = new Author(args[2], args[3]);
                            db.Authors.Add(author);
                        }

                        List<Publisher> publishers = db.Publishers.ToList<Publisher>();
                        Publisher publisher = publishers
                                .Where(at => at.Name == args[6])
                                .FirstOrDefault();
                        if (publisher is null)
                        {
                            publisher = new Publisher(args[6]);
                            db.Publishers.Add(publisher);
                        }
                        Book tmp = new Book(author, args[4], Int32.Parse(args[5]), publisher);
                        db.Books.Add(tmp);
                        db.SaveChanges();
                        Console.WriteLine($"Record inserted.");
                    }
                }

                else if (args[1].ToLower() == "author")
                {
                    if (args.Length < 4)
                        Console.WriteLine("Unrecognized request.");
                    else
                    {
                        Author tmp = new Author(args[2], args[3]);
                        db.Authors.Add(tmp);
                        db.SaveChanges();
                        Console.WriteLine("Record inserted.");
                    }
                }

                else if (args[1].ToLower() == "publisher")
                {
                    if(args.Length < 3)
                        Console.WriteLine("Unrecognized request.");
                    else
                    {
                        Publisher tmp = new Publisher(args[2]);
                        db.Publishers.Add(tmp);
                        db.SaveChanges();
                        Console.WriteLine("Record inserted.");
                    }
                }

                else
                    Console.WriteLine("Unrecognized request.");

            }

            if (args[0].ToLower() == "remove")
            {
                if (args.Length < 3)
                    Console.WriteLine("Unrecognized request.");

                if (args[1].ToLower() == "book")
                {
                    List<Book> books = db.Books.ToList<Book>();
                    Book book = books
                             .Where(at => at.Id == Int32.Parse(args[2]))
                             .FirstOrDefault();

                    if (book is not null)
                    {
                        db.Books.Remove(book);
                        db.SaveChanges();
                        Console.WriteLine("Record Removed.");
                    }
                    else
                        Console.WriteLine("Given record doesn't exist.");
                }

                else if (args[1].ToLower() == "author")
                {
                    List<Author> authors = db.Authors.ToList<Author>();
                    Author author = authors
                            .Where(at => at.Id == Int32.Parse(args[2]))
                            .FirstOrDefault();

                    if (author is not null)
                    {
                        db.Authors.Remove(author);
                        db.SaveChanges();
                        Console.WriteLine("Record Removed.");
                    }
                    else
                        Console.WriteLine("Given record doesn't exist.");
                }

                else if (args[1].ToLower() == "publisher")
                {
                    List<Publisher> publishers = db.Publishers.ToList<Publisher>();
                    Publisher publisher = publishers
                            .Where(at => at.Id == Int32.Parse(args[2]))
                            .FirstOrDefault();

                    if (publisher is not null)
                    {
                        db.Publishers.Remove(publisher);
                        db.SaveChanges();
                        Console.WriteLine("Record Removed.");
                    }
                    else
                        Console.WriteLine("Given record doesn't exist.");
                }

                else
                    Console.WriteLine("Unrecognized request.");
            }

        }
    }
}
