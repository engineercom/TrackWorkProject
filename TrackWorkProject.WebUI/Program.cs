using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TrackWorkProject.WebUI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context= services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();//db yoksa oluþtur ve migrationlarý uygula
    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

var url = "http://localhost:5000";
//tarayýcýda aç
try
{
    var psi = new ProcessStartInfo
    {
        FileName = url,
        UseShellExecute = true
    };
    Process.Start(psi);
}
catch (Exception)
{

    //Eðer tarayýcý açýlmazsa hata almaz ,uygulama yine de çalýþmaya devam eder
}
app.Run();
