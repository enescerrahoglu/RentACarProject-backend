using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentacarContext>,IRentalDal
    {
        

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentacarContext context = new RentacarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             join b in context.Brands
                             on car.BrandId equals b.BrandId

                             join n in context.Cars
                             on car.CarName equals n.CarName

                             join cus in context.Customers
                             on rental.CustomerId equals cus.CustomerId

                             join us in context.Users
                             on cus.UserId equals us.Id
                             
                             select new RentalDetailDto
                             {
                                 RentId=rental.RentId,
                                 FirstName=us.FirstName,
                                 LastName=us.LastName,
                                 CompanyName=cus.CompanyName,
                                 BrandName=b.BrandName,
                                 CarName = n.CarName,
                                 RentDate=rental.RentDate,
                                 ReturnDate=rental.ReturnDate
                                 
                             };
                return result.ToList();




            }           

        }
    }
}