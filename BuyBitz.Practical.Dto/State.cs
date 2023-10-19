using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyBitz.Practical.Dto
{
	public class State
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = String.Empty;
		public int CountryId { get; set; }
	}
}
