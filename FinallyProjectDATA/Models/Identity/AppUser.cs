﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyProjectDATA.Models.Identity
{
		public class AppUser : IdentityUser<int>
		{
			public AppUser() : base()
			{

			}
			public AppUser(string username) : base(username)
			{

			}
			public string Name { get; set; }
			public string Surname { get; set; }
		}
	
}
