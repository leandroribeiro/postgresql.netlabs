using System;
using System.Collections.Generic;
using Postgre.Domain.Entities;
using Postgre.Domain.Repositories;

namespace Postgre.Persistence.NETFull70.EF62.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
