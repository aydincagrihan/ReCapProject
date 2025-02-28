﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class RentalValidator : AbstractValidator<Rental>
	{
		public RentalValidator()
		{
			RuleFor(r => r.CarId).NotEmpty();
			RuleFor(r => r.CustomerId).NotEmpty();
			RuleFor(r => r.RentStartDate).NotEmpty();
		}
	}
}
