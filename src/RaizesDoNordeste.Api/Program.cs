using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RaizesDoNordeste.Api.Filters;
using RaizesDoNordeste.Application;
using RaizesDoNordeste.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Todos os serviços antes do Build()
builder.Services.AddControllers();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services.AddHttpContextAccessor();

var signingKey = builder.Configuration.GetValue<string>("Settings:Jwt:SigningKey");

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = new TimeSpan(0),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey!))
    };
});

var app = builder.Build();

// Pipeline depois do Build()
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await MigrateDatabase();
await app.RunAsync();
return;

async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();
    await DatabaseMigration.MigrateDatabase(scope.ServiceProvider);
}

public partial class Program
{
}