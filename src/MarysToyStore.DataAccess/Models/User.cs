﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarysToyStore.DataAccess
{
	public class User
	{
		public int Id { get; set; }

		[Required]
		public string? FirstName { get; set; }

		[Required]
		public string? LastName { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string? EmailAddress { get; set; }

		[Required]
		public string? PasswordHash { get; set; }

		[Required]
		public bool IsAdmin { get; set; }

        public List<CartItem>? CartItems { get; set; }

		[NotMapped, Display(Name = "Full Name")]
		public string FullName
		{
			get
			{
				string fullName = FirstName + " " + LastName;
				return fullName;
			}
		}
    }
}
