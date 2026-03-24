using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore; // <--- REQUIRED for 'UseSqlServer'
using SynergyDotCom.Data;          // <--- REQUIRED for 'ApplicationDbContext'

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURATION: DATABASE ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// --- 2. CONFIGURATION: SERVICES ---
builder.Services.AddRazorPages();

var app = builder.Build();

// --- 3. PIPELINE ---
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
