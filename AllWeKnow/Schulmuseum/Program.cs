using DatabaseLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Schulmuseum.Authentication;
using Schulmuseum.Data;
using Schulmuseum.Services;
using Syncfusion.Blazor;


var builder = WebApplication.CreateBuilder(args);
var connectionstring = builder.Configuration.GetConnectionString("dev") ??
                       throw new NullReferenceException("No Connection string");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient();
builder.Services.AddSyncfusionBlazor();

// Database
builder.Services.AddSingleton<DataAccess>();

builder.Services.AddDbContextFactory<Database>((DbContextOptionsBuilder options) => options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));

// Services
builder.Services.AddTransient<UserService>();

// Users
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<UserAccountService>();

builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 100 * 1024 * 1024;
});

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



