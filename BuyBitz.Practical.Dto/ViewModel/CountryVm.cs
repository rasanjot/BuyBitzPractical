using BuyBitz.Practical.Dto;

namespace BuyBitz.Practical.Model.ViewModel
{
	public class CountryVm
	{
		public List<CountryInfo> Countries { get; set; } = new List<CountryInfo>();
	}

	public class CountryInfo
	{
		public string Country { get; set; } = String.Empty;
		public List<State> States { get; set; } = new List<State>();
	}
}
