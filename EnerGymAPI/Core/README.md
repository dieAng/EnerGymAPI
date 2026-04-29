# Capa Core (Núcleo / Abstracciones)

La capa `Core` es fundamental para mantener una arquitectura limpia y desacoplada mediante el principio de **Inversión de Dependencias (Dependency Inversion)**.

## ¿Qué contiene?

Principalmente contiene **Interfaces** (contratos). 

Por ejemplo, aquí definimos `IUsuarioService`, que lista todos los métodos que un servicio de usuarios *debe* tener (ej. `GetUsuarioByIdAsync`, `CreateUsuarioAsync`), pero **no incluye el código de cómo se hacen esas cosas**.

## ¿Por qué es importante?

*   **Desacoplamiento:** Los controladores (`Controllers`) solo conocen las interfaces del `Core`, no conocen las implementaciones reales que están en `Application`.
*   **Testabilidad:** Al depender de interfaces, es muy fácil crear "Mocks" (simulaciones) de estos servicios para hacer pruebas unitarias de los controladores sin necesidad de conectar una base de datos real.
*   **Inyección de Dependencias:** En el archivo `Program.cs`, enlazamos estas interfaces con sus implementaciones reales (ej. `builder.Services.AddScoped<IUsuarioService, UsuarioService>();`). Así, cuando un controlador pide un `IUsuarioService`, el sistema automáticamente le entrega un `UsuarioService`.

La capa `Core` es la más abstracta de todas y no debería depender de frameworks externos complejos.