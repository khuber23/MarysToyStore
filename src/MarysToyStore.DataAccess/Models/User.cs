using System.ComponentModel.DataAnnotations;

namespace MarysToyStore.DataAccess.Models
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
	}
}
