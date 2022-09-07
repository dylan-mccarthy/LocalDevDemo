using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NightSkyApp.Data;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient("GalaxiesClient", httpClient =>
{
    httpClient.BaseAddress = new Uri(Configuration["GalaxiesAPI:BaseUrl"]);
});
builder.Services.AddHttpClient("PlanetsClient", httpClient =>
{
    httpClient.BaseAddress = new Uri(Configuration["PlanetsAPI:BaseUrl"]);
});
builder.Services.AddSingleton<GalaxyService>();
builder.Services.AddSingleton<PlanetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
