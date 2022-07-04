using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Interface;
using WebApplication1.mocks;
using WebApplication1.Models;
using WebApplication1.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("dbsettings.json").Build();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContent>(x => x.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAllTicket, TicketRepository>();
builder.Services.AddTransient<ITicketCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));


builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseSession();
//app.UseMvcWithDefaultRoute();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
//    endpoints.MapControllerRoute("categoryFilter", "Ticket/{action}/(category}?", new { Controller = "Ticket", action = "List" });
//});
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObject.Initial(content);
}


app.Run();