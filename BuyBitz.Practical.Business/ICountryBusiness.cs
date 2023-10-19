using BuyBitz.Practical.Dto;
using BuyBitz.Practical.Model.ViewModel;

namespace BuyBitz.Practical.Business
{
	public interface ICountryBusiness
	{
		Task Add(Country entity);
		Task<CountryVm> GetAll();	
	}
}
