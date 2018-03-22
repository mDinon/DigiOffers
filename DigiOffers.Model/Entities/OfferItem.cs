using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiOffers.Model.Entities
{
	public class OfferItem : EntityBase
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string UnitOfMeasurement { get; set; }
		[Required]
		public decimal Quantity { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		[ForeignKey("OfferSection")]
		public int OfferSectionID { get; set; }

		public virtual OfferSection OfferSection { get; set; }
	}
}
