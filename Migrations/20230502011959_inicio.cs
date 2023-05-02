using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_P1_Raura_Cordero.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resena",
                columns: table => new
                {
                    IdResena = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resena", x => x.IdResena);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anio = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdResena = table.Column<int>(type: "int", nullable: false),
                    ResenaIdResena = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.IdPelicula);
                    table.ForeignKey(
                        name: "FK_Pelicula_Resena_ResenaIdResena",
                        column: x => x.ResenaIdResena,
                        principalTable: "Resena",
                        principalColumn: "IdResena");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Cedula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdResena = table.Column<int>(type: "int", nullable: false),
                    ResenaIdResena = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Cedula);
                    table.ForeignKey(
                        name: "FK_Usuario_Resena_ResenaIdResena",
                        column: x => x.ResenaIdResena,
                        principalTable: "Resena",
                        principalColumn: "IdResena");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_ResenaIdResena",
                table: "Pelicula",
                column: "ResenaIdResena");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ResenaIdResena",
                table: "Usuario",
                column: "ResenaIdResena");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Resena");
        }
    }
}
