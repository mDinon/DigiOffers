using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiOffers.Model.Entities
{
	public class OfferNote : EntityBase
	{
		[Required]
		public string Note { get; set; }
		[Required]
		[ForeignKey("Offer")]
		public int OfferID { get; set; }

		public virtual Offer Offer { get; set; }
	}
}
