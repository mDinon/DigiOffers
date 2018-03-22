using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigiOffers.Model.DTO
{
	public class OfferDto
	{
		public int ID { get; set; }
		public bool Active { get; set; }
		[Display(Name = "Datum")]
		public DateTime DateCreated { get; set; }
		[Required]
		public int ClientID { get; set; }
		[Display(Name = "Ime")]
		public string ClientFirstName { get; set; }
		[Required]
		[Display(Name = "Prezime")]
		public string ClientLastName { get; set; }
		[Display(Name = "Datum")]
		public DateTime DeliveryDate { get; set; }
		[Display(Name = "Naziv")]
		public string Heading { get; set; }
		public List<OfferNoteDto> OfferNotes { get; set; }
		public List<OfferSectionDto> OfferSections { get; set; }

		[Display(Name = "Klijent")]
		public string ClientFullName
		{
			get { return $"{ClientFirstName} {ClientLastName}"; }
		}
	}
}
