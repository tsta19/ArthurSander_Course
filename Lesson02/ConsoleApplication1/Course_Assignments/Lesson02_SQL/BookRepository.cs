using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ConsoleApplication1.Lesson01_Book;

namespace ConsoleApplication1.Lesson02_SQL
{
    public class BookRepository
    {

        public void Create(Book book)
        {
            string commandLine = string.Format("INSERT INTO products VALUES('{0}', '{1}', '{2}', '{3}')", person.Name, person.Address, person.BirthDate.ToString("dd-MM-yyyy"), person.Email);
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
            var Book = new Book();
            Book
        }
    }
}