using BuyBitz.Practical.Business;
using BuyBitz.Practical.DataAccess;
using BuyBitz.Practical.DataAccess.Interface;
using BuyBitz.Practical.Model.Transient;
using BuyBitz.Practical.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var appSettings = builder.Configuration.Get<ApplicationSettings>();
if(appSettings is null)
{
	throw new NullReferenceException(nameof(appSettings));
}
builder.Services.AddSingleton(sp => appSettings);

builder.Services.AddDbContext<ApplicationDbContext>(
	options => options.UseSqlServer(appSettings.ConnectionStrings.Default));

builder.Services.AddSingleton<ICachingService, CachingService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();