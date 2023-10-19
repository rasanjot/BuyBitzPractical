using BuyBitz.Practical.Dal;
using BuyBitz.Practical.DataAccess.Interface;
using BuyBitz.Practical.Dto;

namespace BuyBitz.Practical.DataAccess
{
	public class CountryRepository : Repository<Country>, ICountryRepository
	{
		private readonly ApplicationDbContext _db;

		public CountryRepository(ApplicationDbContext db) : base(db) 
		{
			_db = db;
		}
	}
}
