using System.ComponentModel.DataAnnotations;

namespace DigiOffers.Model.DTO
{
	public class OfferItemDto
	{
		public int ID { get; set; }
		public bool Active { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string UnitOfMeasurement { get; set; }
		[Required]
		public decimal Quantity { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int OfferSectionID { get; set; }
	}
}
