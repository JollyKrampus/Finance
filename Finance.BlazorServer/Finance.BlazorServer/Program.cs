using Finance.BlazorServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var financeDbConfigString = builder.Configuration.GetConnectionString("FinanceDb");
var financeDbCnnString = string.Format(financeDbConfigString,
    Environment.GetEnvironmentVariable("SqlDbPassword") ??
    throw new KeyNotFoundException("SqlDbPassword not configured in environment"));
builder.Services.AddDbContextFactory<FinanceDbContext>(options => options.UseSqlServer(financeDbCnnString));

// configure app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//apply db migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();
    db.Database.Migrate();
}

app.Run();