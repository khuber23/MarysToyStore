using System.ComponentModel.DataAnnotations;
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

		[Display(Name = "Mailing Address")]
		public string? Address { get; set; }

		[Display(Name = "Apt or Suite Number")]
		public string? Address2 { get; set; }

		public string? City { get; set; }

		public string? State { get; set; }

		public string? Zip { get; set; }

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
