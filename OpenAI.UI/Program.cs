using Microsoft.EntityFrameworkCore;
using OpenAI.Business.IoC;
using OpenAI.DataAccess.Concretes;
using OpenAI.DataAccess.IoC;
using OpenAI.GPT3.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OAContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddOpenAIService(s =>
    s.ApiKey = builder.Configuration.GetValue<string>("OpenAI:ApiKey")
);



builder.Services.AddDataAccessServices();
builder.Services.AddBusinessServices();

builder.Services.AddHttpClient();


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
