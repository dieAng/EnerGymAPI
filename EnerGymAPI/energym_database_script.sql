CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE "Ejercicios" (
    "Id" uuid NOT NULL,
    "Nombre" text NOT NULL,
    "GrupoMuscular" text,
    "Equipo" text,
    "Descripcion" text,
    "ImagenUrl" text,
    "VideoUrl" text,
    CONSTRAINT "PK_Ejercicios" PRIMARY KEY ("Id")
);

CREATE TABLE "Ingredientes" (
    "Id" uuid NOT NULL,
    "Nombre" text NOT NULL,
    "Calorias" real,
    "Proteinas" real,
    "Carbohidratos" real,
    "Grasas" real,
    CONSTRAINT "PK_Ingredientes" PRIMARY KEY ("Id")
);

CREATE TABLE "Usuarios" (
    "Id" uuid NOT NULL,
    "Nombre" text NOT NULL,
    "Email" text NOT NULL,
    "PasswordHash" text NOT NULL,
    "Edad" integer,
    "Peso" real,
    "Altura" real,
    "Objetivo" text,
    "FotoUrl" text,
    "Rol" text NOT NULL,
    CONSTRAINT "PK_Usuarios" PRIMARY KEY ("Id")
);

CREATE TABLE "Mensajes" (
    "Id" uuid NOT NULL,
    "EmisorId" uuid NOT NULL,
    "ReceptorId" uuid NOT NULL,
    "Contenido" text NOT NULL,
    "Fecha" bigint NOT NULL,
    CONSTRAINT "PK_Mensajes" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Mensajes_Usuarios_EmisorId" FOREIGN KEY ("EmisorId") REFERENCES "Usuarios" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Mensajes_Usuarios_ReceptorId" FOREIGN KEY ("ReceptorId") REFERENCES "Usuarios" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "Posts" (
    "Id" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "Contenido" text,
    "ImagenUrl" text,
    "EnergiaGenerada" double precision NOT NULL,
    "Fecha" bigint NOT NULL,
    CONSTRAINT "PK_Posts" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Posts_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Recetas" (
    "Id" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "Nombre" text NOT NULL,
    "TiempoPreparacion" integer,
    "Alergenos" text,
    "ImagenUrl" text,
    "Descripcion" text,
    "EsPredisenada" boolean NOT NULL,
    CONSTRAINT "PK_Recetas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Recetas_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Rutinas" (
    "Id" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "Nombre" text NOT NULL,
    "Descripcion" text,
    "Nivel" text,
    "Objetivo" text,
    "EsPredisenada" boolean NOT NULL,
    CONSTRAINT "PK_Rutinas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Rutinas_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Comentarios" (
    "Id" uuid NOT NULL,
    "PostId" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "Contenido" text NOT NULL,
    "Fecha" bigint NOT NULL,
    CONSTRAINT "PK_Comentarios" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Comentarios_Posts_PostId" FOREIGN KEY ("PostId") REFERENCES "Posts" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Comentarios_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE
);

CREATE TABLE "LikePosts" (
    "PostId" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    CONSTRAINT "PK_LikePosts" PRIMARY KEY ("PostId", "UsuarioId"),
    CONSTRAINT "FK_LikePosts_Posts_PostId" FOREIGN KEY ("PostId") REFERENCES "Posts" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_LikePosts_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "RutinaEjercicios" (
    "RutinaId" uuid NOT NULL,
    "EjercicioId" uuid NOT NULL,
    "Series" integer NOT NULL,
    "Repeticiones" integer NOT NULL,
    "PesoObjetivo" real,
    "DescansoSeg" integer,
    "Orden" integer NOT NULL,
    CONSTRAINT "PK_RutinaEjercicios" PRIMARY KEY ("RutinaId", "EjercicioId"),
    CONSTRAINT "FK_RutinaEjercicios_Ejercicios_EjercicioId" FOREIGN KEY ("EjercicioId") REFERENCES "Ejercicios" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_RutinaEjercicios_Rutinas_RutinaId" FOREIGN KEY ("RutinaId") REFERENCES "Rutinas" ("Id") ON DELETE CASCADE
);

CREATE TABLE "SesionesEntrenamiento" (
    "Id" uuid NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "RutinaId" uuid,
    "Fecha" bigint NOT NULL,
    "DuracionSegundos" integer,
    "EnergiaGeneradaWh" integer,
    "CaloriasQuemadas" integer,
    CONSTRAINT "PK_SesionesEntrenamiento" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SesionesEntrenamiento_Rutinas_RutinaId" FOREIGN KEY ("RutinaId") REFERENCES "Rutinas" ("Id"),
    CONSTRAINT "FK_SesionesEntrenamiento_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE
);

CREATE TABLE "SeriesRealizadas" (
    "Id" uuid NOT NULL,
    "SesionEntrenamientoId" uuid NOT NULL,
    "EjercicioId" uuid NOT NULL,
    "Repeticiones" integer NOT NULL,
    "Peso" real NOT NULL,
    CONSTRAINT "PK_SeriesRealizadas" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SeriesRealizadas_Ejercicios_EjercicioId" FOREIGN KEY ("EjercicioId") REFERENCES "Ejercicios" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_SeriesRealizadas_SesionesEntrenamiento_SesionEntrenamientoId" FOREIGN KEY ("SesionEntrenamientoId") REFERENCES "SesionesEntrenamiento" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Comentarios_PostId" ON "Comentarios" ("PostId");

CREATE INDEX "IX_Comentarios_UsuarioId" ON "Comentarios" ("UsuarioId");

CREATE INDEX "IX_LikePosts_UsuarioId" ON "LikePosts" ("UsuarioId");

CREATE INDEX "IX_Mensajes_EmisorId" ON "Mensajes" ("EmisorId");

CREATE INDEX "IX_Mensajes_ReceptorId" ON "Mensajes" ("ReceptorId");

CREATE INDEX "IX_Posts_UsuarioId" ON "Posts" ("UsuarioId");

CREATE INDEX "IX_Recetas_UsuarioId" ON "Recetas" ("UsuarioId");

CREATE INDEX "IX_RutinaEjercicios_EjercicioId" ON "RutinaEjercicios" ("EjercicioId");

CREATE INDEX "IX_Rutinas_UsuarioId" ON "Rutinas" ("UsuarioId");

CREATE INDEX "IX_SeriesRealizadas_EjercicioId" ON "SeriesRealizadas" ("EjercicioId");

CREATE INDEX "IX_SeriesRealizadas_SesionEntrenamientoId" ON "SeriesRealizadas" ("SesionEntrenamientoId");

CREATE INDEX "IX_SesionesEntrenamiento_RutinaId" ON "SesionesEntrenamiento" ("RutinaId");

CREATE INDEX "IX_SesionesEntrenamiento_UsuarioId" ON "SesionesEntrenamiento" ("UsuarioId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260423223043_InitialCreate', '10.0.3');

COMMIT;

START TRANSACTION;
CREATE TABLE "RefreshTokens" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Token" text NOT NULL,
    "UsuarioId" uuid NOT NULL,
    "ExpiryDate" timestamp with time zone NOT NULL,
    "IsUsed" boolean NOT NULL,
    "IsRevoked" boolean NOT NULL,
    "AddedDate" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_RefreshTokens" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_RefreshTokens_Usuarios_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "Usuarios" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_RefreshTokens_UsuarioId" ON "RefreshTokens" ("UsuarioId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260423234940_AddRefreshToken', '10.0.3');

COMMIT;

START TRANSACTION;
ALTER TABLE "RefreshTokens" DROP COLUMN "AddedDate";

ALTER TABLE "RefreshTokens" DROP CONSTRAINT "PK_RefreshTokens";

ALTER TABLE "RefreshTokens" DROP COLUMN "Id";

ALTER TABLE "RefreshTokens" ADD "Id" uuid NOT NULL DEFAULT (gen_random_uuid());

ALTER TABLE "RefreshTokens" ADD CONSTRAINT "PK_RefreshTokens" PRIMARY KEY ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260428224649_ActualizacionModelos', '10.0.3');

COMMIT;

