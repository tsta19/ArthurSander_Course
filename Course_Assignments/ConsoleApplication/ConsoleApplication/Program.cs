using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mime;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true) {
                
                Console.WriteLine("+-----------------<[ Book Database Menu ]>-----------------+");
                Console.WriteLine("|                                                          |");
                Console.WriteLine("|    1 - Get a book from the registry database             |");
                Console.WriteLine("|    2 - Create a new book to the registry database        |");
                Console.WriteLine("|    3 - Retrieve a list of the 5 previous books           |");
                Console.WriteLine("|    4 - Update a book from the registry database          |");
                Console.WriteLine("|    5 - Delete a book from the registry database          |");
                Console.WriteLine("|    6 - Exit the application                              |");
                Console.WriteLine("|                                                          |");
                Console.WriteLine("+-----------------<[ Book Database Menu ]>-----------------+");
                
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
                    case 3:
                        ListOption();
                        break;
                    case 4:
                        UpdateOption();
                        break;
                    case 5:
                        DeleteOption();
                        break;
                    case 6:
                        ExitOption();
                        break;
                    default:
                        Console.WriteLine("Are you dumb?");
                        break;
                }
            }
        }


        public static void ExitOption()
        {
            Environment.Exit(0);
        }

        public static void ListOption()
        {
            BookRepository bookRepository = new BookRepository();
            var listOfBooks = bookRepository.List();

            Console.WriteLine("--------------------------<[ Book List ]>--------------------------");
            Console.WriteLine("");
            
            foreach (var book in listOfBooks)
            {
                Console.WriteLine("ID: " + book.Id + " | name: " + book.Name);
            }

            Console.WriteLine("");
            Console.WriteLine("--------------------------<[ Book List ]>--------------------------");
            

        }

        public static void UpdateOption()
        {
            BookRepository bookRepository = new BookRepository();

            Console.WriteLine("------------------<[ Book Updater ]>------------------");
            Console.WriteLine("What is the id of the book you wish to update?");
            int id = int.Parse(Console.ReadLine());

            var book = bookRepository.Get(id);
            Console.WriteLine("--------------------------<[ Book Updater ]>--------------------------");
            Console.WriteLine("");
            Console.WriteLine("The current books name is: " + book.Name);
            Console.WriteLine("The current books release date is: " + book.ReleaseDate);
            Console.WriteLine("The current books number of pages is: " + book.NumberOfPages);
            Console.WriteLine("The current books author is: " + book.Author);
            Console.WriteLine("");

            Console.WriteLine("--------------------------<[ Book Updater ]>--------------------------");
            Console.WriteLine("Are you sure you want to update the book?");
            Console.WriteLine("Yes / No");
            Console.WriteLine("");
            Console.WriteLine("--------------------------<[ Book Updater ]>--------------------------");
            
            var wantToUpdate = Console.ReadLine().ToLowerInvariant();
            
            if (wantToUpdate == "yes") {
                
                // Name Configuration
                Console.WriteLine("--------<[ Enter Book's New Name ]>--------");
                book.Name = Console.ReadLine();
                Console.Clear();
            
                // Release Date Configuration
                Console.WriteLine("--------<[ Enter Book's New Release Date ]>--------");
                book.ReleaseDate = DateTime.Parse(Console.ReadLine());
                Console.Clear();
            
                // Number of Pages Configuration
                Console.WriteLine("--------<[ Enter Book's New Number of Pages ]>--------");
                book.NumberOfPages = int.Parse(Console.ReadLine());
                Console.Clear();
            
                // Author Configuration
                Console.WriteLine("--------<[ Enter Book's New Author ]>--------");
                book.Author = Console.ReadLine();
                Console.Clear();
                
                Console.WriteLine("Updating book....");
                bookRepository.Update(book);
                Console.WriteLine("Book updated successfully!");
                
                Console.WriteLine("--------------------------<[ Book Updater ]>--------------------------");
                Console.WriteLine("");
                Console.WriteLine("The updated books name is: " + book.Name);
                Console.WriteLine("The updated books release date is: " + book.ReleaseDate);
                Console.WriteLine("The updated books number of pages is: " + book.NumberOfPages);
                Console.WriteLine("The updated books author is: " + book.Author);
                Console.WriteLine("");
                Console.WriteLine("--------------------------<[ Book Updater ]>--------------------------");

            } else if (wantToUpdate == "no") {
                Console.Clear();
                UpdateOption();
            }
        }

        public static void DeleteOption()
        {
            BookRepository bookRepository = new BookRepository();
            
            Console.WriteLine("------------------<[ Book Deleter ]>------------------");
            Console.WriteLine("What is the id of the book you wish to delete?");
            int bookID = int.Parse(Console.ReadLine());
            Console.Clear();

            bookRepository.Delete(bookID);
            
            Console.WriteLine("------------------<[ Book Deleter ]>------------------");
            Console.WriteLine("You successfully deleted the book");
            Console.WriteLine("------------------<[ Book Deleter ]>------------------");
        }
        
        public static void GetOption() 
        {
            BookRepository bookRepository = new BookRepository();

            Console.WriteLine("------------------<[ Book Searcher ]>------------------");
            Console.WriteLine("What is the id of the book you wish to see?");
            int bookID = int.Parse(Console.ReadLine());
            Console.Clear();

            var book = bookRepository.Get(bookID);
            
            Console.WriteLine("--------------------------<[ Book Searcher ]>--------------------------");
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

            var informationIsCorrect = Console.ReadLine().ToLowerInvariant();
            
            if (informationIsCorrect == "yes") {
                Console.WriteLine("Uploading book to database....");
                bookRepository.Create(book);
                Console.WriteLine("Book uploaded successfully!");

            } else if (informationIsCorrect == "no") {
                Console.Clear();
                CreateOption();
            }
        }
    }
}