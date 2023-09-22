using Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UI.Interfaces;
using UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IFilmService, FilmService>();

string? connectionString = builder.Configuration.GetConnectionString("mom-cloud-db");

if (connectionString != null)
{
    var sqlConnectionConfiguration = new SqlConfiguration(connectionString);
    builder.Services.AddSingleton(sqlConnectionConfiguration);
}
else
{
    throw new Exception("No se ha configurado la conexión a la BD");
}

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
