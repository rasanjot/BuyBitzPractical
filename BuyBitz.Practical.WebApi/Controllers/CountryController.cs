using BuyBitz.Practical.Business;
using BuyBitz.Practical.Dto;
using BuyBitz.Practical.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BuyBitz.Practical.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : Controller
	{
		private readonly ICountryBusiness _countryBusiness;

		public CountryController(ICountryBusiness countryBusiness)
		{
			_countryBusiness = countryBusiness;
		}

		[HttpPost(nameof(AddCountry))]
		public async Task AddCountry([FromBody] Country entity)
		{
			await _countryBusiness.Add(entity);
		}

		[HttpGet(nameof(GetAllCountryData))]
		public async Task<CountryVm> GetAllCountryData()
		{
			return await _countryBusiness.GetAll();
		}
	}
}
