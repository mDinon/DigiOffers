using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiOffers.Model.Entities
{
	public class OfferSection : EntityBase
	{
		[Required]
		public string Name { get; set; }
		[Required]
		[ForeignKey("Offer")]
		public int OfferID { get; set; }

		public virtual ICollection<OfferItem> OfferItems { get; set; }
		public virtual Offer Offer { get; set; }
	}
}
