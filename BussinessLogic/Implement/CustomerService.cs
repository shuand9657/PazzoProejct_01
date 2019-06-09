using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AutoMapper;
using BussinessLogic.Interface;
using DBRepostitory.Implement;
using DBRepostitory.Models;
using DBRepostitory.ViewModel;

namespace BussinessLogic.Implement
{
    public class CustomerService : ICustomersService
    {
        protected CustomerRepository<Customers> _res;

        public CustomerService()
        {
            _res = new CustomerRepository<Customers>();
        }

        public bool Create(CustomerViewModel entity)
        {
            try
            {
                Customers customersData = Mapper.Map<Customers>(entity);
                _res.Create(customersData);
                _res.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public bool Update(CustomerViewModel entity)
        {
            try
            {
                Customers customersData = Mapper.Map<Customers>(entity);
                _res.Update(customersData);
                _res.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            
        }

        public bool Delete(CustomerViewModel entity)
        {
            try
            {
                Customers customersData = Mapper.Map<Customers>(entity);

                _res.Delete(customersData);
                _res.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public Customers Select(Expression<Func<Customers, bool>> predicate)
        {
            try
            {
                return _res.Select(predicate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IQueryable<Customers> Selects()
        {
            try
            {
                return _res.Selects();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}