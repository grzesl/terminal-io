using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using netelectron.Data;
using MudBlazor.Services;
using ElectronNET.API;
using ElectronNET.API.Entities;


var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseElectron(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
builder.Services.AddElectron();
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



if (false)
{
    app.Run();
}
else
{
    await app.StartAsync();
    // Open the Electron-Window here
    await Electron.WindowManager.CreateWindowAsync();

    app.WaitForShutdown();
}