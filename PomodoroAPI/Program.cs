using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PomodoroAPI.Data;
using PomodoroAPI.Infrastructure;
using PomodoroAPI.Infrastructure.Mapping;
using PomodoroAPI.Modules.Auth.Services;
using PomodoroAPI.Modules.Usuario.Repositories;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;
using PomodoroAPI.Modules.Categoria.Repositories;
using PomodoroAPI.Modules.Categoria.Services;
using PomodoroAPI.Modules.RegistroDeTempo.Services;
using PomodoroAPI.Modules.Usuario.Services;

var builder = WebApplication.CreateBuilder(args);

// configuração das variáveis de ambiente
EnvConfig.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

// Adicionando configurações de autenticação por JWT
builder.Services
    .AddAuthentication(authOptions =>
    {
        authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(bearerOptions =>
    {
        bearerOptions.RequireHttpsMetadata = false;
        bearerOptions.SaveToken = true;
        bearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Keys.Jwt),
        };
    });

// Adição de suporte a retornos de arrays nos JSONs
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

// configuração do swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// Configuração par utilização do Postgres
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ProjectContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
);

// Injeção de dependências dos repositórios do projeto
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IRegistroDeTempoRepository, RegistroDeTempoRepository>();
builder.Services.AddScoped<IPeriodoDeTempoRepository, PeriodoDeTempoRepository>();

// services
builder.Services.AddScoped<IAuthService, AuthServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
builder.Services.AddScoped<IRegistroDeTempoServices, RegistroDeTempoServices>();
builder.Services.AddScoped<IPeriodoDeTempoServices, PeriodoDeTempoServices>();

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();