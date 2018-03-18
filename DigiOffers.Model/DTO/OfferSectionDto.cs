using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiOffers.Model.DTO
{
	public class OfferSectionDto
	{
		public int ID { get; set; }
		public bool Active { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int OfferID { get; set; }
		public List<OfferItemDto> OfferItems { get; set; }
	}
}
