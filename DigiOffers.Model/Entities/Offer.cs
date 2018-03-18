using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiOffers.Model.Entities
{
	public class Offer : EntityBase
	{
		[Required]
		[ForeignKey("Client")]
		public int ClientID { get; set; }
		public DateTime DeliveryDate { get; set; }

		public virtual Client Client { get; set; }
		public virtual ICollection<OfferSection> OfferSections { get; set; }
		public virtual ICollection<OfferNote> OfferNotes { get; set; }
	}
}
