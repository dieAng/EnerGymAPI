# Capa Domain (Dominio)

La capa de Dominio es el corazón de la aplicación EnerGym. Aquí se definen las **Entidades de Negocio** (Modelos) que representan los conceptos fundamentales del sistema.

## Contenido

Esta carpeta contiene clases de C# que modelan la realidad del negocio, tales como:
*   `Usuario`
*   `Rutina` y `Ejercicio`
*   `Post`, `Comentario` y `LikePost` (para la red social)
*   `Receta` e `Ingrediente` (para nutrición)
*   `RefreshToken` (para la gestión de sesiones seguras)

## Características principales

1.  **Independencia Total:** La capa `Domain` no tiene referencias ni dependencias hacia ninguna otra capa del proyecto (`Application`, `Infrastructure`, etc.). Tampoco depende de frameworks externos. Es código C# puro (POCOs - Plain Old CLR Objects).
2.  **Mapeo a Base de Datos:** Entity Framework Core (que vive en la capa de `Infrastructure`) utiliza estas entidades para generar la estructura de las tablas en PostgreSQL. Cada propiedad de estas clases generalmente se convierte en una columna en la base de datos, y las referencias cruzadas (ej. `public Usuario Usuario { get; set; }`) se convierten en relaciones de llaves foráneas (Foreign Keys).