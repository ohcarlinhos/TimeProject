using System.Text.Json.Serialization;
using App.Infrastructure.Config;
using App.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

const string customCors = "_customCors";
builder.AddCorsBuilderConfig(customCors);

// Injeção de todos os serviços.
builder.AddServicesBuilderConfig();
builder.AddCustomAuthorizationBuilderConfig();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();

builder.AddSwaggerBuilderConfig();
builder.AddDatabaseBuilderConfig();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseCors(customCors);
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<UserChallengeMiddleware>();
app.MapControllers();

app.Run();