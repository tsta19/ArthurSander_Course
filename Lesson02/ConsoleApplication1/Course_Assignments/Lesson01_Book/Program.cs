using System;
using System.Configuration;
using System.Data.SqlClient;
using ConsoleApplication1.Lesson01_Book;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Book book = new Book();
            
            // Name Configuration
            Console.WriteLine("Type the name of the book:");
            book.Name = Console.ReadLine();
            Console.Clear();
            
            // Release Date Configuration
            Console.WriteLine("Type the release date of the book:");
            book.ReleaseDate = DateTime.Parse(Console.ReadLine());
            Console.Clear();
            
            // Number of Pages Configuration
            Console.WriteLine("Type the number of pages the book has:");
            book.NumberOfPages = Int16.Parse(Console.ReadLine());
            Console.Clear();
            
            // Author Configuration
            Console.WriteLine("Type the author of the book:");
            book.Author = Console.ReadLine();
            Console.Clear();
            
            // Summary
            Console.WriteLine("------------------<[ Book Completion ]>------------------");
            Console.WriteLine("The entered books name is: " + book.Name);
            Console.WriteLine("The entered books release date is: " + book.ReleaseDate);
            Console.WriteLine("The entered books number of pages is: " + book.NumberOfPages);
            Console.WriteLine("The entered books author is: " + book.Author);
            Console.WriteLine("------------------<[ Book Completion ]>------------------");
            
            Console.Read();
        }
    }
}