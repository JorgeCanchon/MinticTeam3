using HospiEnCasa.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<HospiEnCasa.App.Persistencia.AppContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>().AddEntityFrameworkStores<HospiEnCasa.App.Persistencia.AppContext>();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login";
    // config.AccessDeniedPath = new PathString("AccessDenied");
});
builder.Services.AddScoped<IRepositorioPaciente, RepositorioPaciente>();
builder.Services.AddScoped<IRepositorioFamiliarDesignado, RepositorioFamiliarDesignado>();
builder.Services.AddScoped<IRepositorioMedico, RepositorioMedico>();
builder.Services.AddScoped<IRepositorioEnfermera, RepositorioEnfermera>();
builder.Services.AddScoped<IRepositorioHistoria, RepositorioHistoria>();
builder.Services.AddScoped<IRepositorioSignosVitales, RepositorioSignosVitales>();
builder.Services.AddScoped<IRepositorioSugerenciaCuidado, RepositorioSugerenciaCuidado>();

var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
