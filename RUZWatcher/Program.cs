using Microsoft.EntityFrameworkCore;
using Radzen;
using RUZWatcher.Components;
using RUZWatcher.Data;
using RUZWatcher.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Pridané Radzen komponenty
builder.Services.AddRadzenComponents();
// Pridaný náš http client ako servis na injectovanie
builder.Services.AddHttpClient<RUZHttpClient>();
// Pridanie kontextu SQLite databázy
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultLocalConnection")));
// Pridanie servisu pre prácu s DB
builder.Services.AddScoped<DbService>();
// Servis pre export do Excelu
builder.Services.AddScoped<ExcelExportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
