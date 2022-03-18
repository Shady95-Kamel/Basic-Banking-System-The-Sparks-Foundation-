using Basic_Banking_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Basic_Banking_System.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BasicBankDB context;

        public CustomerService(BasicBankDB context)
        {
            this.context = context;
        }
        public Customer Add(Customer entity)
        {
            var res = context.Add(entity);
            context.SaveChanges();
            return res.Entity;
        }

        public int Count()
        {
            return context.Customers.Count();
        }

        public void Delete(int Id)
        {
            var entity = GetbyId(Id);
            context.Customers.Remove(entity);
            context.SaveChanges();

        }

        public IEnumerable<Customer> FindAll(Expression<Func<Customer, bool>> expression, string[] includes = null)
        {
            var query = context.Customers;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            return query.Where(expression).ToList();
        }

        public Customer Find(Expression<Func<Customer, bool>> expression, string[] includes = null)
        {
            var query = context.Customers;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }
            return query.Find(expression);
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer GetbyId(int Id)
        {
            return context.Customers.Find(Id);
        }

        public bool Transfer(int senderId, int receiverId, double amount)
        {
            var transaction = context.Database.BeginTransaction();

            var sender = context.Customers.Find(senderId);
            var reciever = context.Customers.Find(receiverId);
            if (sender.Balance < amount)
            {
                return false;
            }
            sender.Balance -= amount;
            reciever.Balance += amount;

            context.Transfers.Add(new Transfer
            { Sender = sender, Reciever = reciever, Amount = amount, DateTime = DateTime.Now });

            transaction.Commit();
            context.SaveChanges();
            return true;
        }

        public Customer Update(Customer entity)
        {
            var res = context.Customers.Update(entity);
            context.SaveChanges();
            return res.Entity;
        }
        public IEnumerable<Transfer> GetTransfers() 
        {
             return context.Transfers.ToList();
           
        }
    }
}
