using Basic_Banking_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Basic_Banking_System.Services
{
    public interface ICustomerService
    {
        Customer GetbyId(int Id);
        IEnumerable<Customer> GetAll();
        Customer Find(Expression<Func<Customer, bool>> expression, string[] includes = null);
        IEnumerable<Customer> FindAll(Expression<Func<Customer, bool>> expression, string[] includes = null);
        Customer Add(Customer entity);
        Customer Update(Customer entity);
        void Delete(int Id);
        int Count();
        bool Transfer(int senderId, int receiverId, double amount);
        IEnumerable<Transfer> GetTransfers();
    }
}
