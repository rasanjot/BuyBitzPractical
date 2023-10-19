using BuyBitz.Practical.Dal;
using BuyBitz.Practical.DataAccess.Interface;
using BuyBitz.Practical.Dto;

namespace BuyBitz.Practical.DataAccess
{
	public class StateRepository : Repository<State>, IStateRepository
	{
		private readonly ApplicationDbContext _db;

		public StateRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
	}
}
