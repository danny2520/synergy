using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL;

// 1. GLOBAL SETTINGS (Must come AFTER 'using' but BEFORE 'builder')
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// --- 2. CONFIGURATION: DATABASE ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// --- 3. CONFIGURATION: SERVICES ---
builder.Services.AddRazorPages();

var app = builder.Build();

// --- 4. PIPELINE ---
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