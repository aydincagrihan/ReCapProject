﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspect.Autofac
{
	//yetki kontrolü yaptığımız class jwt için
	public class SecuredOperation : MethodInterception
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly string[] _roles;

		public SecuredOperation(string roles)
		{
			_roles = roles.Split(',');
			_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
		}

		protected override void OnBefore(IInvocation invocation)
		{
			var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
			foreach (var role in _roles)
				if (roleClaims.Contains(role))
					return;
			throw new Exception(Messages.AuthorizationDenied);
		}
	}
}
