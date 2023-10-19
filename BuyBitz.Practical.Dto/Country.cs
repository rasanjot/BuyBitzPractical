using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyBitz.Practical.Dto
{
	public class Country
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = String.Empty;
		public List<State> States { get; set; } = new List<State>();
	}
}
