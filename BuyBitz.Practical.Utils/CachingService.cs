using BuyBitz.Practical.Model.Transient;
using Microsoft.Extensions.Caching.Memory;

namespace BuyBitz.Practical.Utility
{
	public class CachingService : ICachingService
	{
		private readonly IMemoryCache _cache;
		private readonly ApplicationSettings _applicationSettings;

		public CachingService(IMemoryCache cache, ApplicationSettings applicationSettings)
		{
			_cache = cache;
			_applicationSettings = applicationSettings;
		}

		public T? GetCachedData<T>(string cacheKey) where T : class
		{
			return _cache.Get(cacheKey) as T;
		}

		public void UpdateCachedData<T>(string cacheKey, T data)
		{
			_cache.Set(cacheKey, data, new MemoryCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = _applicationSettings.CacheDurationInMinutes
			});
		}
	}
}
