using BlazorServerInvoice.Data;
using Invoice.Models.User;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddServerSideBlazor();


//builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
//{
//    options.Password.RequiredLength = 3;
//    options.Password.RequiredUniqueChars = 0;
//    options.Password.RequireDigit = false;
//    options.Password.RequireNonAlphanumeric = false;
//}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConStr")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>(); 
builder.Services.AddScoped<SignInManager<AppUser>>();


var app = builder.Build();
// builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
