# Capa Application (Aplicación)

Esta capa contiene la **lógica de negocio** principal de la API de EnerGym. Actúa como el puente entre los controladores (que reciben las peticiones HTTP) y la base de datos (infraestructura).

## Contenido de este módulo

*   **Services (Servicios):** Aquí residen las clases que implementan las interfaces definidas en la capa `Core` (por ejemplo, `UsuarioService` implementa `IUsuarioService`). Estas clases contienen las reglas de negocio, validaciones complejas y coordinan el guardado o lectura de datos utilizando el DbContext.
*   **DTOs (Data Transfer Objects):** Los DTOs son clases simples que se utilizan para transferir datos entre el cliente (Front-End) y la API. 
    *   *¿Por qué usamos DTOs?* Para no exponer nuestras entidades de base de datos (`Domain`) directamente al exterior. Por ejemplo, al devolver un `Usuario`, usamos un `UsuarioResponseDto` que omite información sensible como la contraseña cifrada. También tenemos DTOs de entrada como `UsuarioCreateRequestDto`.

## Reglas de Dependencia
La capa `Application` **depende** de `Core` (para las interfaces) y de `Domain` (para conocer las entidades). 
No debe preocuparse por cómo se reciben las peticiones HTTP (eso es trabajo de `Controllers`).