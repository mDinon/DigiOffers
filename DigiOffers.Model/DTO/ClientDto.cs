﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiOffers.Model.DTO
{
	public class ClientDto
	{
		public int ID { get; set; }
		public bool Active { get; set; }
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		[Required]
		public string Sex { get; set; }

		public List<OfferDto> Offers { get; set; }
	}
}
