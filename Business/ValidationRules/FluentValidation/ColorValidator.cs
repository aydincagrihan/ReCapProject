﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class ColorValidator:AbstractValidator<Color>
	{
		public ColorValidator()
		{
			RuleFor(c => c.ColorName).NotEmpty().MinimumLength(2);
			//RuleFor(c => c.ColorName).MinimumLength(2);
		}
	}
}
