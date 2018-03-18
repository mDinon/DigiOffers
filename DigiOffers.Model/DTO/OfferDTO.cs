using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigiOffers.Model.DTO
{
	public class OfferDto
	{
		public int ID { get; set; }
		public bool Active { get; set; }
		public DateTime DateCreated { get; set; }
		[Required]
		public int ClientID { get; set; }
		public string ClientFirstName { get; set; }
		[Required]
		public string ClientLastName { get; set; }
		public DateTime DeliveryDate { get; set; }
		public List<OfferNoteDto> OfferNotes { get; set; }
		public List<OfferSectionDto> OfferSections { get; set; }

		public string ClientFullName()
		{
			return $"{ClientFirstName} {ClientLastName}";
		}
	}
}
