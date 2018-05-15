using System.ComponentModel.DataAnnotations;

namespace DigiOffers.Model.DTO
{
	public class OfferItemDto
	{
		public int? ID { get; set; }
		public bool Active { get; set; }
		[Required]
		[Display(Name = "Naziv")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "JM")]
		public string UnitOfMeasurement { get; set; }
		[Required]
		[Display(Name = "Količina")]
		public decimal Quantity { get; set; }
		[Required]
		[Display(Name = "Jed. cijena")]
		public decimal Price { get; set; }
		[Required]
		public int OfferSectionID { get; set; }

		[Display(Name = "Ukupna cijena")]
		public decimal PriceTotal { get { return Quantity * Price; } }
	}
}
