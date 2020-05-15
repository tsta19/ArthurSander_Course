using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApplication
{
    public class BookRepository
    {
        public Book Get(int Id)
        {
            string commandLine = string.Format("SELECT * FROM books WHERE id = {0}", Id);
            var connection = getConnection();
            var command = new SqlCommand(commandLine, connection);
            connection.Open();
            var result = command.ExecuteReader();
            result.Read();
            var book = fillBook(result);
            connection.Close();
            return book;
        }

        public List<Book> List(int limit = 5)
        {
            var books = new List<Book>();
            string commandLine = string.Format("SELECT TOP({0}) * FROM books", limit);
            var connection = getConnection();
            var command = new SqlCommand(commandLine, connection);
            connection.Open();
            var result = command.ExecuteReader();
            while (result.Read())
            {
                books.Add(fillBook(result));
            }
            connection.Close();
            return books;
        }

        public void Create(Book book)
        {
            string commandLine = string.Format("INSERT INTO books VALUES('{0}', '{1}', {2}, '{3}')", book.Name, book.ReleaseDate.ToString("dd-MM-yyyy"), book.NumberOfPages, book.Author);
            var connection = getConnection();
            var command = new SqlCommand(commandLine, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            
        }

        private SqlConnection getConnection()
        {
            return new SqlConnection(
                @"Data Source=DESKTOP-AB8TECC\SQLEXPRESS;
                Initial Catalog=AssignmentOne_Books;
                Integrated Security=True;
                Connect Timeout=30;
                Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False"                
            );
        }

        private Book fillBook(SqlDataReader result)
        {
            var book = new Book();
            book.Id = (int) result.GetValue(0);
            book.Name = (string) result.GetValue(1);
            book.ReleaseDate = (DateTime) result.GetValue(2);
            book.NumberOfPages = (int) result.GetValue(3);
            book.Author = (string) result.GetValue(4);
            return book;
        }

    }
}