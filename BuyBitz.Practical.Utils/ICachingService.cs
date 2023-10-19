namespace BuyBitz.Practical.Utility
{
	public interface ICachingService
	{
		T? GetCachedData<T>(string cacheKey) where T : class;
		void UpdateCachedData<T>(string cacheKey, T data);
	}
}
