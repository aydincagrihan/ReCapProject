﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			//RuleFor(u => u.FirstName).NotEmpty();
			//RuleFor(u => u.LastName).NotEmpty();
			//RuleFor(u => u.Email).EmailAddress();
			
		}
	}
}
