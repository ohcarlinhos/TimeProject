using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.Categoria.Repositories;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;
using PomodoroAPI.Modules.Usuario.Repositories;

var builder = WebApplication.CreateBuilder(args);

// TODO: verificar uma forma de remover "$id" da resposta da API.
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ProjetoContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IRegistroDeTempoRepository, RegistroDeTempoRepository>();
builder.Services.AddScoped<IPeriodoDeTempoRepository, PeriodoDeTempoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();