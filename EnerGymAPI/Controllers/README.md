# Capa Controllers (Controladores)

Esta es la capa de **Presentación** (o capa de API). Aquí se definen los puntos de entrada (Endpoints) a través de los cuales las aplicaciones cliente (Front-End web, móvil, Postman) se comunican con el sistema mediante el protocolo HTTP.

## Responsabilidades de los Controladores

1.  **Recibir peticiones HTTP:** Manejan los verbos `GET`, `POST`, `PUT`, `DELETE`.
2.  **Ruteo:** Definen las URLs de la API (ej. `[Route("api/[controller]")]` genera rutas como `/api/usuario`).
3.  **Autorización:** Utilizan etiquetas como `[Authorize]` o `[AllowAnonymous]` para proteger rutas y verificar si la petición incluye un Token JWT válido. También validan roles (ej. `[Authorize(Roles = "admin")]`).
4.  **Delegar el trabajo:** Los controladores **no deben contener lógica de negocio compleja ni consultas directas a la base de datos**. Su única tarea es recibir los DTOs, pasarlos al servicio correspondiente de la capa `Application` (inyectado vía el constructor) y devolver el resultado.
5.  **Devolver Respuestas HTTP:** Retornan códigos de estado adecuados según el resultado de la operación:
    *   `200 OK` (Éxito)
    *   `201 Created` (Recurso creado exitosamente)
    *   `400 Bad Request` (Datos inválidos enviados por el cliente)
    *   `401 Unauthorized` (Falta token o es inválido)
    *   `404 Not Found` (Recurso no encontrado)

## Ejemplo de flujo
Cliente -> HTTP POST `/api/usuario` -> `UsuarioController` -> Llama a `IUsuarioService.CreateUsuarioAsync(dto)` -> Retorna `201 Created`.