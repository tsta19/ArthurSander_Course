using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApplication
{
    public class BookRepository
    {

        public void Create(Book book)
        {
            string commandLine = string.Format("INSERT INTO books VALUES('{0}', '{1}', '{2}', '{3}')", book.Name, book.ReleaseDate.ToString("dd-MM-yyyy"), book.NumberOfPages, book.Author);
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
            book.Name = (string) result.GetValue(0);
            book.ReleaseDate = (DateTime) result.GetValue(1);
            book.NumberOfPages = (int) result.GetValue(2);
            book.Author = (string) result.GetValue(3);
            return book;
        }

    }
}