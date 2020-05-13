using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("------------------<[ Book Database Menu ]>------------------");
            Console.WriteLine("");
            Console.WriteLine("1 - Get a book from the registry database");
            Console.WriteLine("2 - Upload a new book to the registry database");
            Console.WriteLine("");
            Console.WriteLine("------------------<[ Book Database Menu ]>------------------");
            
            var option = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (option)
            {
                case 1:
                    GetOption();
                    break;
                case 2:
                    CreateOption();
                    break;
                default:
                    Console.WriteLine("Are you dumb?");
                    break;
                
            }
        }
        public static void GetOption() 
        {
            BookRepository bookRepository = new BookRepository();

            Console.WriteLine("------------------<[ Book Searcher ]>------------------");
            Console.WriteLine("What is the id of the book you wish to see?");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();

            var book = bookRepository.Get(id);
            
            Console.WriteLine("--------------------------<[ Book Searcher ]>--------------------------");
            Console.WriteLine("If the information below is correct write 'yes' and 'no' correspondingly");
            Console.WriteLine("");
            Console.WriteLine("The searched books name is: " + book.Name);
            Console.WriteLine("The searched books release date is: " + book.ReleaseDate);
            Console.WriteLine("The searched books number of pages is: " + book.NumberOfPages);
            Console.WriteLine("The searched books author is: " + book.Author);
            Console.WriteLine("");
            Console.WriteLine("--------------------------<[ Book Searcher ]>--------------------------");
        }

        public static void CreateOption()
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
            Console.WriteLine("--------------------------<[ Book Completion ]>--------------------------");
            Console.WriteLine("If the information below is correct write 'yes' and 'no' correspondingly");
            Console.WriteLine("");
            Console.WriteLine("The entered books name is: " + book.Name);
            Console.WriteLine("The entered books release date is: " + book.ReleaseDate);
            Console.WriteLine("The entered books number of pages is: " + book.NumberOfPages);
            Console.WriteLine("The entered books author is: " + book.Author);
            Console.WriteLine("");
            Console.WriteLine("--------------------------<[ Book Completion ]>--------------------------");

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