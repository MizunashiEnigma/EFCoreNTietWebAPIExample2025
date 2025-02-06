using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RAD302Week3Lab12025CL.S00237686
{
    public class CustomerRepository : ICustomer<Customer>, IDisposable
    {
        CustomerDbContext context = new CustomerDbContext();
        public CustomerRepository(CustomerDbContext context)
        {
            this.context = context;
        }
        public void Add(Customer entity)
        {
            context.Customer.Add(entity);
        }

        public void AddRange(IEnumerable<Customer> entities)
        {
            context.AddRange(entities);
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return context.Customer.Find(predicate) as IEnumerable<Customer>;
        }

        public Customer Get(int id)
        {
            return context.Customer.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customer;
        }

        public void Remove(Customer entity)
        {
            context.Customer.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            context.Customer.RemoveRange(entities);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
