using BuyBitz.Practical.DataAccess.Interface;
using BuyBitz.Practical.Dto;
using BuyBitz.Practical.Model.ViewModel;
using BuyBitz.Practical.Utility;
using Microsoft.EntityFrameworkCore;

namespace BuyBitz.Practical.Business
{
	public class CountryBusiness : ICountryBusiness
	{
		private readonly ICountryRepository _countryRepository;
		private readonly ICachingService _cachingService;

		public CountryBusiness(
			ICountryRepository countryRepository,
			ICachingService cachingService)
		{
			_countryRepository = countryRepository;
			_cachingService = cachingService;
		}

		#region Public Methods
		public async Task Add(Country country)
		{
			ArgumentNullException.ThrowIfNull(country, nameof(country));

			await _countryRepository.Add(country);

			await UpdateCacheAfterAdding(country);
		}

		public async Task<CountryVm> GetAll()
		{
			var cachedCountryData = _cachingService.GetCachedData<List<Country>>(Constant.CountryCacheKey);
			if (cachedCountryData != null)
			{
				return new CountryVm
				{
					Countries = TransformResponse(cachedCountryData)
				};
			}

			var countries = await _countryRepository.GetAll().Include(x => x.States).ToListAsync();

			return new CountryVm
			{
				Countries = TransformResponse(countries)
			};
		}
		#endregion

		#region Private Methods
		private async Task UpdateCacheAfterAdding(Country country)
		{
			var cachedCountryData = _cachingService.GetCachedData<List<Country>>(Constant.CountryCacheKey);
			if (cachedCountryData != null)
			{
				cachedCountryData.Add(country);

				_cachingService.UpdateCachedData(Constant.CountryCacheKey, cachedCountryData);
			}
			else
			{
				var countries = await _countryRepository.GetAll().Include(x => x.States).ToListAsync();
				_cachingService.UpdateCachedData(Constant.CountryCacheKey, countries.ToList());
			}
		}

		private List<CountryInfo> TransformResponse(IEnumerable<Country> countries)
		{
			return countries.Select(country => new CountryInfo
			{
				Country = country.Name,
				States = country.States
			}).ToList();
		}
		#endregion
	}
}
