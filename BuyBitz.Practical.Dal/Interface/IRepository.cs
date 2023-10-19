namespace BuyBitz.Practical.Dal
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();
		Task Add(T entity);
	}
}
