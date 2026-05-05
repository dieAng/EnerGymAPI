using EnerGymAPI.Application.Services;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi;

try
{
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

    // Configuración avanzada de Swagger/OpenAPI
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "EnerGym API",
            Version = "v1",
            Description = "API para la aplicación EnerGym, un planificador de rutinas de gimnasio y alimentación.",
            Contact = new OpenApiContact
            {
                Name = "Diego Anguiano",
                Email = "dam01.2025@gmail.com,
            }
        });

        // Configurar Swagger para que entienda y use JWT
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Cabecera de autorización JWT usando el esquema Bearer. Ejemplo: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(_ => new OpenApiSecurityRequirement());
    });


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
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }
            else
            {
                var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
                policy.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
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
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Iniciando la aplicación y aplicando migraciones de base de datos...");
                context.Database.Migrate();
                logger.LogInformation("Migraciones aplicadas correctamente.");
            }
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogCritical(ex, "CRÍTICO: Ocurrió un error al ejecutar las migraciones de la base de datos.");
        }
    }

    // Configure the HTTP request pipeline.
    app.UseSwagger(c =>
    {
        // Cambiamos la ruta del archivo JSON para que no esté en la raíz
        c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        // Apuntamos el endpoint de la UI a la nueva ruta del JSON
        c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "EnerGym API v1");
        // Establecemos la ruta de la UI
        c.RoutePrefix = "api/swagger";
    });

    // Redirección para comodidad: si alguien va a /api/swagger, lo mandamos a la UI
    app.MapGet("/api/swagger", context =>
    {
        context.Response.Redirect("/api/swagger/index.html");
        return Task.CompletedTask;
    });


    if (!app.Environment.IsDevelopment())
    {
        app.UseHsts();
    }


    // Aplicar política CORS configurada
    app.UseCors("CorsPolicy");

    app.UseHttpsRedirection();

    // El orden aquí es importante: Primero Authentication, luego Authorization
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    // Endpoint de bienvenida en la raíz para comprobar que la API está viva
    app.MapGet("/", () => "¡La API de EnerGym está funcionando correctamente!");

    app.Run();
}
catch (Exception ex)
{
    // CATCH DE EMERGENCIA PARA EVITAR EL 503 Y VER EL ERROR EN PANTALLA
    var errorBuilder = WebApplication.CreateBuilder(args);
    var errorApp = errorBuilder.Build();

    errorApp.MapGet("/", () => $"ERROR FATAL DE ARRANQUE:\n{ex.Message}\n\nSTACK TRACE:\n{ex.StackTrace}");

    errorApp.Run();
}
