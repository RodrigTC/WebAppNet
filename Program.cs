using Microsoft.Extensions.Options;
using TRABAJO_FINAL.Models;
using TRABAJO_FINAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Add(new ServiceDescriptor(typeof(ICitum),
    new CitumRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IUsuario),
    new UsuarioRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IDoctor),
    new DoctorRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IEspecialidad),
    new EspecialidadRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IHorario),
    new HorarioRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICTemporal),
    new CTemporalRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IDia),
    new DiaRepository()));

builder.Services.AddControllersWithViews();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Principal}/{action=Index}/{id?}");

app.Run();
