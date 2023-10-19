namespace BuyBitz.Practical.Model.Transient
{
	public record ApplicationSettings
	{
		public ConnectionString ConnectionStrings { get; init; } = null!;
		public TimeSpan CacheDurationInMinutes { get; init; }
	}
	
	public record ConnectionString
	{
		public string Default { get; init; } = null!;
	}
}
