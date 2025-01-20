using AoacControl.Data;
using AoacControl.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException ("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContextPool<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// DI
builder.Services.AddTransient<MarcaService, MarcaService>();
builder.Services.AddTransient<UniaoParoquialService, UniaoParoquialService>();
builder.Services.AddTransient<ParoquiaService, ParoquiaService>();
builder.Services.AddTransient<ComunidadeService, ComunidadeService>();
builder.Services.AddTransient<InstrumentoService, InstrumentoService>();
builder.Services.AddTransient<AssociadoService, AssociadoService>();


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
