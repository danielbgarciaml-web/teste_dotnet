using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Veiculos.Application.Handlers;
using Veiculos.Application.Interfaces;
using Veiculos.Application.Services;
using Veiculos.Application.Validators; 
using Veiculos.Domain.Interfaces;
using Veiculos.Infra.Data;
using Veiculos.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --- Services Configuration ---
builder.Services.AddControllers();

// Ativa a validação automática do FluentValidation (Retorna HTTP 400)
builder.Services.AddFluentValidationAutoValidation();
// Registra todos os validadores que estão no mesmo Assembly do AdicionarVeiculoValidator
builder.Services.AddValidatorsFromAssemblyContaining<AdicionarVeiculoValidator>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("VeiculosDB"));

// Repositories
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Business Services
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// MediatR setup
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(VeiculoHandlers).Assembly));

// --- Security & Documentation (Swagger) ---
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Veiculos API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header. Ex: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// Configuração JWT
var jwtKey = Encoding.ASCII.GetBytes("ChaveMestraSuperSecretaDe32Caracteres!");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// --- HTTP Pipeline ---
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
    c.RoutePrefix = string.Empty; 
});

app.UseHttpsRedirection();

app.UseAuthentication(); // 1º - Identifica o usuário
app.UseAuthorization();  // 2º - Verifica as permissões

app.MapControllers();


app.Run();