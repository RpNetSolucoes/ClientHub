using LibraryClienteHub.Interface;
using LibraryClienteHub.Models;
using LibraryClienteHub.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IClientsServises, ClientsServises>();
builder.Services.AddSingleton<IAddressClientServices, AddressClientService>();
builder.Services.AddSingleton<IAuthServices, AuthServices>();
builder.Services.AddSingleton<DbClientHubContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}");


app.Run();
