﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
	public interface IUserDal:IEntityRepository<User>
	{
		List<OperationClaim> GetClaims(User user);

		UserDetailDto GetUserDetail(string userMail);
	}
}
