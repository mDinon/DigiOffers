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
		[Display(Name = "Email")]
		public string ClientEmail { get; set; }
		[Display(Name = "Telefon")]
		public string ClientPhoneNumber { get; set; }
		[Display(Name = "Titula")]
		public string ClientTitle { get; set; }
		[Display(Name = "Datum dostave")]
		public DateTime DeliveryDate { get; set; }
		[Display(Name = "Naslov ponude")]
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
