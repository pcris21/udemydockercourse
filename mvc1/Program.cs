using Microsoft.EntityFrameworkCore;
using mvc1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var host = builder.Configuration["DBHOST"] ?? "localhost";
var port = builder.Configuration["DBPORT"] ?? "3306";
var password = builder.Configuration["DBPASSWORD"] ?? "numsey";

// string mySqlConnection = $"server={host};uid=root;pwd={password};"
//                          + $"port={port};database=produtosdb";

string mySqlConnection = "server=localhost;userid=root;pwd=numsey;port=3306;database=produtosdb;";
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IRepository, ProdutoRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
                              options.UseMySql(mySqlConnection,
                              ServerVersion.AutoDetect(mySqlConnection)));


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

PopulaDb.IncluiDadosDB(app);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
