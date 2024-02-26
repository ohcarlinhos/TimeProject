using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Infrastructure;
using PomodoroAPI.Infrastructure.Config;
using PomodoroAPI.Infrastructure.Mapping;

var builder = WebApplication.CreateBuilder(args);

// configuração das variáveis de ambiente
EnvConfig.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

const string customCors = "_customCors";
CorsBuilderConfig.Apply(builder, customCors);
JwtBuilderConfig.Apply(builder);

// Adição de suporte a retornos de arrays nos JSONs
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

SwaggerBuilderConfig.Apply(builder);

// Configuração par utilização do Postgres
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ProjectContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
);

RepositoriesBuilderConfig.Apply(builder);
ServicesBuilderConfig.Apply(builder);

builder.Services.AddAutoMapper(typeof(MappingProfile));

// build da aplicação
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // erro em dev
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else app.UseExceptionHandler("/error"); // erro em produção

app.UseCors(customCors);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();