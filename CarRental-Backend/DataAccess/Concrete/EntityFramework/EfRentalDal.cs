using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public RentalDetailDto GetRentalByDetails(Expression<Func<Rental, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from ren in context.Rentals
                             join cus in context.Customers
                             on ren.CustomerId equals cus.Id
                             join us in context.Users
                             on cus.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 RentalId = ren.Id,
                                 CarId = ren.CarId,
                                 RentTime = ren.RentDate,
                                 ReturnTime = ren.ReturnDate,
                                 CustomerId = ren.CustomerId,
                                 UserId = us.Id,
                                 CompanyName = cus.CompanyName,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Email = us.Email
                                 
                             };
                return result.SingleOrDefault();
            }
        }

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from ren in context.Rentals
                             join cus in context.Customers
                             on ren.CustomerId equals cus.Id
                             join us in context.Users
                             on cus.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 RentalId = ren.Id,
                                 CarId = ren.CarId,
                                 RentTime = ren.RentDate,
                                 ReturnTime = ren.ReturnDate,
                                 UserId = cus.UserId,
                                 CustomerId = ren.CustomerId,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Email = us.Email,
                                 CompanyName = cus.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
