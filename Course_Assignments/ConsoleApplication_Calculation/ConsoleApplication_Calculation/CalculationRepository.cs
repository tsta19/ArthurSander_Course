using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace ConsoleApplication_Calculation
{
    public class CalculationRepository
    {
        public List<Calculation> List(int limit = 5)
        {
            var calculation = new List<Calculation>();
            string commandLine = string.Format("SELECT TOP({0}) * FROM calculations ORDER BY id DESC", limit);
            var connection = getConnection();
            var command = new SqlCommand(commandLine, connection);
            connection.Open();
            var result = command.ExecuteReader();
            while (result.Read())
            {
                calculation.Add(fillCalculation(result));
            }
            connection.Close();
            return calculation;
        }

        public void Create(Calculation calculation)
        {
            string commandLine = string.Format("INSERT INTO calculations VALUES({0},{1},{2})", calculation.FirstNumber, calculation.SecondNumber, (int)calculation.Operation);

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
                Initial Catalog=CalculationDatabase;
                Integrated Security=True;
                Connect Timeout=30;
                Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False"                
            );
        }
        
        private Calculation fillCalculation(SqlDataReader result)
        {
            var calculation = new Calculation();
            calculation.Id = (int) result.GetValue(0);
            calculation.FirstNumber = (double) result.GetValue(1);
            calculation.SecondNumber = (double) result.GetValue(2);
            calculation.Operation = (OperationEnum) result.GetValue(3);
            return calculation;
        }
    }
}