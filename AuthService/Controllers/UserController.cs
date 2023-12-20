using LogInDTONameSpace;
using Microsoft.AspNetCore.Mvc;
using System;

namespace USerController_Namespace
{
	[ApiController]
	[Route("api/v1/authentication/")]
	public class USerController
	{
		public USerController()
		{

		}

		[HttpPost("login/")]
		public void Login([FromBody] LoginDTO login)
		{

		}
	}

}
