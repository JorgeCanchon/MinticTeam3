using HospiEnCasa.App.Persistencia;

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
