# Capa Infrastructure (Infraestructura)

La capa de Infraestructura es responsable de la comunicación con **agentes externos**, principalmente la Base de Datos, pero también podría incluir sistemas de archivos, envíos de correos electrónicos, pasarelas de pago o APIs de terceros.

## Contenido principal en EnerGym

1.  **Data (`EnerGymDbContext.cs`):** 
    Esta es la clase principal de Entity Framework Core. Actúa como la sesión con la base de datos PostgreSQL. Aquí se definen los `DbSet<T>` (ej. `public DbSet<Usuario> Usuarios { get; set; }`) que le indican al ORM qué entidades del `Domain` deben convertirse en tablas. También se pueden configurar reglas específicas usando el Fluent API (en el método `OnModelCreating`).

2.  **Migrations (Migraciones):**
    Cada vez que se modifica una entidad en la capa `Domain` (se añade un campo, se crea una tabla nueva), se genera un archivo de migración mediante el comando `dotnet ef migrations add`. Estos archivos (ej. `20260428..._ActualizacionModelos.cs`) contienen las instrucciones precisas para que Entity Framework traduzca los cambios de código C# a comandos SQL que actualizan el esquema de PostgreSQL.

## Reglas de Dependencia
La capa `Infrastructure` **depende** fuertemente de `Domain` (porque necesita mapear las entidades a la base de datos). 

**Nota sobre el despliegue:** En este proyecto, las migraciones se ejecutan de manera automática al arrancar la aplicación (configurado en `Program.cs`), asegurando que las bases de datos de entornos de producción (como en Azure) estén siempre sincronizadas con la versión del código.