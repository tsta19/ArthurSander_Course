using System;
using System.Configuration;
using ConsoleApplication1.Properties;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Books books = new Books();
            
            // Name Configuration
            Console.WriteLine("Type the name of the book:");
            books.Name = Console.ReadLine();
            Console.Clear();
            
            // Release Date Configuration
            Console.WriteLine("Type the release date of the book:");
            books.ReleaseDate = DateTime.Parse(Console.ReadLine());
            Console.Clear();
            
            // Number of Pages Configuration
            Console.WriteLine("Type the number of pages the book has:");
            books.NumberOfPages = Int16.Parse(Console.ReadLine());
            Console.Clear();
            
            // Author Configuration
            Console.WriteLine("Type the author of the book:");
            books.Author = Console.ReadLine();
            Console.Clear();
            
            // Summary
            Console.WriteLine("------------------<[ Book Completion ]>------------------");
            Console.WriteLine("The entered books name is: " + books.Name);
            Console.WriteLine("The entered books release date is: " + books.ReleaseDate);
            Console.WriteLine("The entered books number of pages is: " + books.NumberOfPages);
            Console.WriteLine("The entered books author is: " + books.Author);
            Console.WriteLine("------------------<[ Book Completion ]>------------------");
            
            Console.Read();

        }
    }
}