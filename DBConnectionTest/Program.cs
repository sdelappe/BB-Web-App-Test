// I added all of these using statements
using DBConnectionTest.Data;
using DBContext = DBConnectionTest.Data.AppDBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// I wrote this connection statement
builder.Services.AddDbContext<DBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DemoDbContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// I wrote this line to avoid errors having to do with incompatible dates between .NET and Postgres
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// I wrote this code, not sure why lol
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DBContext>();
    // Note: if you're having trouble with EF, database schema, etc.,
    // uncomment the line below to re-create the database upon each run.
    // context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    DBInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// I changed the controller to Books instead of Home
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
