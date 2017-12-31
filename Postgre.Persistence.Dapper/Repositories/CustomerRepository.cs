using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;
using Postgre.Domain.Entities;
using Postgre.Domain.Repositories;

namespace Postgre.NetCore.Dapper.Infrastructure
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_connectionString);
            }
        }

        public void Add(Customer item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO customer (name) VALUES(@Name)", item);
            }

        }

        public IEnumerable<Customer> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Customer>("SELECT * FROM customer");
            }
        }

        public Customer FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Customer>("SELECT * FROM customer WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM customer WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(Customer item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE customer SET name = @Name WHERE id = @Id", item);
            }
        }
    }
}