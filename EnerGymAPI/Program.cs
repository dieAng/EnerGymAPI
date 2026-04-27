using EnerGymAPI.Application.Services;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Inyectar Servicios
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IRutinaService, RutinaService>();
builder.Services.AddScoped<IEjercicioService, EjercicioService>();
builder.Services.AddScoped<ISesionEntrenamientoService, SesionEntrenamientoService>();
builder.Services.AddScoped<IRecetaService, RecetaService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IMensajeService, MensajeService>();
builder.Services.AddScoped<IIngredienteService, IngredienteService>();
builder.Services.AddScoped<IRutinaEjercicioService, RutinaEjercicioService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configurar el DbContext
builder.Services.AddDbContext<EnerGymDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("EnerGymDb")));

// Configuración de JWT
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // RequireHttpsMetadata será 'true' en producción y 'false' en desarrollo
        options.RequireHttpsMetadata = !builder.Environment.IsDevelopment(); 
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
        };
    });

// Agregar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        if (builder.Environment.IsDevelopment())
        {
            // En desarrollo permitimos todo (Ej. Postman, Emuladores locales)
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
        else
        {
            // En producción, restringimos a los dominios autorizados
            var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); // Opcional, necesario si usas cookies/tokens en headers específicos
        }
    });
});

var app = builder.Build();

// MVP: Ejecutar migraciones automáticamente al arrancar la aplicación
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<EnerGymDbContext>();
        if (context.Database.IsRelational())
        {
            context.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al ejecutar las migraciones de la base de datos.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    // En producción es recomendable usar HSTS
    app.UseHsts();
}

// Aplicar política CORS configurada
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

// El orden aquí es importante: Primero Authentication, luego Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();