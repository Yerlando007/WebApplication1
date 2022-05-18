using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Interface;
using WebApplication1.mocks;
using WebApplication1.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("dbsettings.json").Build();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContent>(x => x.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddTransient<IAllTicket, TicketRepository>();
builder.Services.AddTransient<ITicketCategory, CategoryRepository>();



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

using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObject.Initial(content);
}


app.Run();