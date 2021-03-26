using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public CustomerDetailDto GetCustomerByDetails(Expression<Func<Customer, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cus in context.Customers
                             join us in context.Users
                             on cus.UserId equals us.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = cus.Id,
                                 UserId = cus.UserId,
                                 CompanyName = cus.CompanyName,
                                 Email = us.Email,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName
                             };
                return result.SingleOrDefault();
            }
        }

        public List<CustomerDetailDto> GetCustomersDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cus in context.Customers
                             join us in context.Users
                             on cus.UserId equals us.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = cus.Id,
                                 UserId = cus.UserId,
                                 CompanyName = cus.CompanyName,
                                 Email = us.Email,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName
                             };
                return result.ToList();
            }
        }
    }
}
