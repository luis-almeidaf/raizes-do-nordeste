using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using RaizesDoNordeste.Api.Filters;
using RaizesDoNordeste.Application;
using RaizesDoNordeste.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(config =>
{
    const string bearer = "Bearer";
    config.AddSecurityDefinition(bearer, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite o token JWT"
    });

    config.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference(bearer),
            new List<string>(Array.Empty<string>())
        }
    });
});

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

public partial class Program { }