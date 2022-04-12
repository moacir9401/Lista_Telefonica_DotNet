using ListaTelefonicaWeb.Models.Context; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); 

builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase(databaseName: "Contatos"));
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase(databaseName: "Enderecos"));
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase(databaseName: "Emails"));
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase(databaseName: "Telefones"));


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
    pattern: "{controller=Contato}/{action=ContatoIndex}/{id?}");

app.Run();
