using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            //colorId = 3 iken DailyPrice minimum 100 lira olmalı:
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100).When(c => c.ColorId == 3).WithMessage("colorId = 3 iken DailyPrice 100 liradan düşük olamaz!");
            RuleFor(c => c.Description).Must(StartWithCar).WithMessage("Araç açıklaması 'Araç hakkında: ' ile başlamalıdır!");
        }

        private bool StartWithCar(string arg) 
        {
            //Description "Araç hakkında: " ile başlamalı
            return arg.StartsWith("Araç hakkında: ");
        }
    }
}
