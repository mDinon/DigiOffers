using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigiOffers.Model.Entities
{
	public class Client : EntityBase
	{
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		[Required]
		public string Sex { get; set; }

		public virtual ICollection<Offer> Offers { get; set; }
	}
}
