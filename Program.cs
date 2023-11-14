using Microsoft.EntityFrameworkCore;
using IIF_upload.data;
using IIF_upload.components;
using FluentAssertions.Common;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<TBCViewComponent>();

builder.Services.AddDbContext<LoadBatchfromDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionStrings")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
