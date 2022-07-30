using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<HospiEnCasa.App.Persistencia.AppContext>();
builder.Services.AddScoped<IRepositorioPaciente, RepositorioPaciente>();
builder.Services.AddScoped<IRepositorioFamiliarDesignado, RepositorioFamiliarDesignado>();
builder.Services.AddScoped<IRepositorioMedico, RepositorioMedico>();
builder.Services.AddScoped<IRepositorioEnfermera, RepositorioEnfermera>();
builder.Services.AddScoped<IRepositorioUsuario,RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioHistoria, RepositorioHistoria>();
builder.Services.AddScoped<IRepositorioSignosVitales, RepositorioSignosVitales>();
builder.Services.AddScoped<IRepositorioSugerenciaCuidado, RepositorioSugerenciaCuidado>();

builder.Services.AddSession(options => 
{
  options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
  .AddCookie(options =>
  {
    options.LoginPath = "/Login/Login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.AccessDeniedPath = "/Login/Denied";
  });

builder.Services.AddMvc();

var app = builder.Build();

app.UseCookiePolicy();
app.UseAuthentication();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// app.UseAuthentication();

app.UseSession();

app.MapRazorPages();

app.Run();
