# EnerGym API

Bienvenido al repositorio del backend de **EnerGym**, una plataforma completa para la gestión de entrenamientos, nutrición y comunidad (red social).

Esta API RESTful está construida en **.NET Core (C#)** y utiliza **PostgreSQL** como base de datos, con despliegue preparado para Azure (App Service y PostgreSQL Flexible Server).

## Tecnologías Principales
*   **Framework:** .NET (C#)
*   **Base de Datos:** PostgreSQL
*   **ORM:** Entity Framework Core (EF Core)
*   **Autenticación:** JSON Web Tokens (JWT) con soporte para Refresh Tokens.
*   **Documentación de API:** OpenAPI / Swagger.

## Arquitectura del Proyecto

El proyecto está estructurado siguiendo principios de **Clean Architecture** (Arquitectura Limpia) y separación de responsabilidades, dividido en las siguientes carpetas/módulos (cada una tiene su propio `README.md` con más detalles):

1.  **[Domain](EnerGymAPI/Domain/README.md):** El corazón del software. Contiene las entidades y modelos de datos (Ej. `Usuario`, `Rutina`, `Post`).
2.  **[Core](EnerGymAPI/Core/README.md):** Contiene los contratos e interfaces (Ej. `IUsuarioService`).
3.  **[Application](EnerGymAPI/Application/README.md):** Contiene la lógica de negocio, servicios y los DTOs (Data Transfer Objects).
4.  **[Infrastructure](EnerGymAPI/Infrastructure/README.md):** Maneja el acceso a datos (DbContext de EF Core) y las migraciones de PostgreSQL.
5.  **[Controllers](EnerGymAPI/Controllers/README.md):** La capa de presentación de la API. Expone los endpoints HTTP.

## Configuración y Arranque Local

1.  **Base de datos:** Asegúrate de tener PostgreSQL corriendo localmente o actualiza la cadena de conexión `EnerGymDb` en `appsettings.Development.json`.
2.  **Migraciones:** El proyecto está configurado para ejecutar `context.Database.Migrate()` automáticamente al arrancar. Si necesitas crear una nueva migración tras cambiar un modelo, ejecuta:
    ```bash
    dotnet ef migrations add NombreDeLaMigracion
    dotnet ef database update
    ```
3.  **Ejecución:**
    ```bash
    dotnet run
    ```
4.  **Prueba de vida:** Al navegar a la raíz `http://localhost:<puerto>/`, verás un mensaje de bienvenida confirmando que la API está viva. Los endpoints se encuentran bajo el prefijo `/api/` (ej. `/api/usuario`).

## Despliegue en Azure

Este proyecto está preparado para desplegarse en Azure App Service. Asegúrate de configurar las siguientes **Variables de Entorno** en el portal de Azure:
*   `ConnectionStrings__EnerGymDb`: Tu cadena de conexión a PostgreSQL Flexible.
*   `Jwt__Key`: Clave secreta (muy larga) para firmar los tokens.
*   `Jwt__Issuer` y `Jwt__Audience`: URLs de tu API y tu cliente Front-End.
*   `AllowedOrigins__0`: URL del Front-End para permitir CORS.
*   `ASPNETCORE_ENVIRONMENT`: `Production`.
