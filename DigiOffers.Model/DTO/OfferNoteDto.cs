using System.ComponentModel.DataAnnotations;

namespace DigiOffers.Model.DTO
{
	public class OfferNoteDto
	{
		public int ID { get; set; }
		public bool Active { get; set; }
		[Required]
		[Display(Name = "Napomena")]
		public string Note { get; set; }
		[Required]
		public int OfferID { get; set; }
	}
}
