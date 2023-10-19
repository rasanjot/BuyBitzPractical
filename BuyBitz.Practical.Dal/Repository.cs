using BuyBitz.Practical.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BuyBitz.Practical.Dal
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		public DbSet<T> _dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			_dbSet = _db.Set<T>();
		}

		public virtual async Task Add(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _db.SaveChangesAsync();
		}

		public virtual IQueryable<T> GetAll()
		{
			return _dbSet;
		}
	}
}
