﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
	public class UserDetailDto:IDto
	{
		public int UserId { get; set; }

		public int CustomerId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string CompanyName { get; set; }
    }
}
