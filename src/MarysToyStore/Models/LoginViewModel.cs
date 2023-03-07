﻿using System.ComponentModel.DataAnnotations;

namespace MarysToyStore.Models
{
	public class LoginViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email Address")]
		public string? EmailAddress { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
	}
}
