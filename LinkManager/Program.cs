using LinkManager.Components;
using Microsoft.EntityFrameworkCore;
using LinkManager.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies; // Bu lazým!

var builder = WebApplication.CreateBuilder(args);

// Veritabaný
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// --- 1. KÝMLÝK DOÐRULAMA SERVÝSÝ ---
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "FerreAuth";
        options.LoginPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers(); // Login controller için

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// --- 2. GÜVENLÝK SIRALAMASI (ÇOK ÖNEMLÝ) ---
app.UseRouting(); // <-- Sen bunu sormuþtun, buraya ekledik.

app.UseAuthentication(); // Kimlik kontrolü
app.UseAuthorization();  // Yetki kontrolü

app.UseAntiforgery();

app.MapControllers(); // Login'in çalýþmasý için þart

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();