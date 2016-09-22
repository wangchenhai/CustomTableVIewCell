using System;
using System.Collections.Generic;
using System.Linq;
namespace CustomTableCell
{
	public static class UserRepository
	{
		public static List<User> GetUsers()
		{
			var Users = new List<User>
			{
				new User
				{
					Name = "Evolve",
					Sex = "M",
				},
				new User
				{
					Name = "WWDC",
					Sex = "F",
				}
				
			};

			return Users;
		}
	}
}
