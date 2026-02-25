using WhiteListChecker.Core.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IWhiteListApiClient, WhiteListApiClient>(client =>
{
	var config = builder.Configuration.GetSection("WhiteListApi");
	client.BaseAddress = new Uri(config["BaseUrl"]);
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowBlazorDev", policy =>
	{
		policy.WithOrigins("https://localhost:7093") // set Blazor app origin (adjust port)
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
