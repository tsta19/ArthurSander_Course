using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Book book = new Book();
            BookRepository bookRepository = new BookRepository();

            // Name Configuration
            Console.WriteLine("--------<[ Enter Book's Name ]>--------");
            book.Name = Console.ReadLine();
            Console.Clear();
            
            // Release Date Configuration
            Console.WriteLine("--------<[ Enter Book's Release Date ]>--------");
            book.ReleaseDate = DateTime.Parse(Console.ReadLine());
            Console.Clear();
            
            // Number of Pages Configuration
            Console.WriteLine("--------<[ Enter Book's Number of Pages ]>--------");
            book.NumberOfPages = int.Parse(Console.ReadLine());
            Console.Clear();
            
            // Author Configuration
            Console.WriteLine("--------<[ Enter Book's Author ]>--------");
            book.Author = Console.ReadLine();
            Console.Clear();

            // Summary
            Console.WriteLine("------------------<[ Book Completion ]>------------------");
            Console.WriteLine("");
            Console.WriteLine("The entered books name is: " + book.Name);
            Console.WriteLine("The entered books release date is: " + book.ReleaseDate);
            Console.WriteLine("The entered books number of pages is: " + book.NumberOfPages);
            Console.WriteLine("The entered books author is: " + book.Author);
            Console.WriteLine("");
            Console.WriteLine("------------------<[ Book Completion ]>------------------");

            if (Console.ReadLine() == "yes") {
                book.InformaionIsCorrect = true;

            } else if (Console.ReadLine() == "no") {
                book.InformaionIsCorrect = false;
            }

            if (book.InformaionIsCorrect) {
                Console.WriteLine("Uploading book to database....");
                bookRepository.Create(book);
                Console.WriteLine("Book uploaded successfully!");
            }
            
            Console.Read();
        }
    }
}