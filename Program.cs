using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using M4Movies.Data;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using M4Movies.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<M4MoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("M4MoviesContext") ?? throw new InvalidOperationException("Connection string 'M4MoviesContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var defaultCulture = new CultureInfo("en-US");

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

using (var scope = app.Services.CreateScope())
{
    var servies = scope.ServiceProvider;
    SeedData.Initilize(servies);
}

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
