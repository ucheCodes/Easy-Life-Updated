using HKBlog.Controllers;
using HKBlog.Database;
using HKBlog.MailService;
using HKBlog.Models;
using HKBlog.States;
using HKBlog.UI.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<AdsControl>();
builder.Services.AddScoped<IEncryptionHelper, EncryptionHelper>();
builder.Services.AddScoped<IUserController, UserController>();
builder.Services.AddScoped<IDatabase, Database>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IStore, Store>();
builder.Services.AddScoped<IProductController, ProductController>();
builder.Services.AddScoped<IOrderController, OrderController>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IReviewController, ReviewController>();
builder.Services.AddScoped<IAccountController, AccountController>();
builder.Services.AddScoped<SignalRService>();
builder.Services.AddHttpClient();

var builder2 = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

var configuration = builder2.Build();




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

//Addding signalr dependency
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
    endpoints.MapHub<AppHub>(AppHub.HubUrl);
});

//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

app.Run();
