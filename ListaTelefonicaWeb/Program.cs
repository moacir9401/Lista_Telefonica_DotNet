using ListaTelefonico.Services;
using ListaTelefonico.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IContatoServices>(new ContatoServices());
builder.Services.AddSingleton<IEnderecoServices>(new EnderecoServices());
builder.Services.AddSingleton<ITelefoneServices>(new TelefoneServices());
builder.Services.AddSingleton<IEmailServices>(new EmailServices());

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
