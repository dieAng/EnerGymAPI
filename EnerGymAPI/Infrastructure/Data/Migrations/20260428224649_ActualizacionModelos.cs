using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EnerGymAPI.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "RefreshTokens");

            // 1. Quitar la llave primaria
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            // 2. Eliminar la columna Id entera
            migrationBuilder.DropColumn(
                name: "Id",
                table: "RefreshTokens");

            // 3. Añadir la nueva columna Id de tipo uuid
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RefreshTokens",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()"); // Si tu versión de Postgres lo soporta, o 00000000-0000-0000-0000-000000000000 en su defecto

            // 4. Volver a asignar la llave primaria a la nueva columna
            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revertir el proceso (uuid a int identity)
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RefreshTokens");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RefreshTokens",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                table: "RefreshTokens",
                column: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "RefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}