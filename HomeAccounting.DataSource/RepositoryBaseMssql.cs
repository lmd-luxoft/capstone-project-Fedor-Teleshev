using Dapper;
using HomeAccounting.DataSource.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HomeAccounting.DataSource
{
    public class RepositoryBaseMssql : IRepository
    {
        private string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=HomeAccounting;Integrated Security=true;MultipleActiveResultSets=True;";
        
        public void AddAccount(DBAccount account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = $"INSERT INTO Accounts (Tittle, CreationDate) VALUES ('{account.Tittle}','{account.CreationDate}');";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Connection.Open();
                    command.ExecuteReader();
                }
            }
        }

        public DBAccount GetAccountById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.QueryFirst<DBAccount>("SELECT * FROM Accounts WHERE id = @Id", new { Id = id });
            }
        }
    }
}
