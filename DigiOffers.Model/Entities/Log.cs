using System.ComponentModel.DataAnnotations.Schema;

namespace DigiOffers.Model.Entities
{
	[Table(name:"Log")]
	public class Log : EntityBase
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
