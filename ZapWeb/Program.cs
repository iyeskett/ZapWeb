using Microsoft.EntityFrameworkCore;
using ZapWeb.Data;
using ZapWeb.Hubs;
using ZapWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ZapWebContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ZapWebContext") ?? throw new InvalidOperationException("Connection string 'ZapWebContext' not found.")));

// SignalR
builder.Services.AddSignalR();

// Db
builder.Services.AddScoped<UsuarioService>();

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

// RPC
app.MapHub<ZapWebHub>("/ZapWebHub");

app.Run();