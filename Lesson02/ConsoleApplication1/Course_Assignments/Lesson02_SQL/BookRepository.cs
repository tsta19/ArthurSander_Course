using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ConsoleApplication1.Lesson01_Book;

namespace ConsoleApplication1.Lesson02_SQL
{
    public class BookRepository
    {
        public Book Get(int id)
        {
            
        }

        public List<Book> list(int limit = 5)
        {
        }

        public void Create(Book book)
        {
            var connection = getConnection();
            
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
            
        }
    }
}