using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_P1_Raura_Cordero.Migrations
{
    /// <inheritdoc />
    public partial class actual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Resena_ResenaIdResena",
                table: "Pelicula");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Resena_ResenaIdResena",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ResenaIdResena",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Pelicula_ResenaIdResena",
                table: "Pelicula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resena",
                table: "Resena");

            migrationBuilder.DropColumn(
                name: "IdResena",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ResenaIdResena",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdResena",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "ResenaIdResena",
                table: "Pelicula");

            migrationBuilder.RenameTable(
                name: "Resena",
                newName: "Resenas");

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "Pelicula",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "Resenas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPelicula",
                table: "Resenas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCedula",
                table: "Resenas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resenas",
                table: "Resenas",
                column: "IdResena");

            migrationBuilder.CreateIndex(
                name: "IX_Resenas_IdPelicula",
                table: "Resenas",
                column: "IdPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_Resenas_UsuarioCedula",
                table: "Resenas",
                column: "UsuarioCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_Resenas_Pelicula_IdPelicula",
                table: "Resenas",
                column: "IdPelicula",
                principalTable: "Pelicula",
                principalColumn: "IdPelicula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resenas_Usuario_UsuarioCedula",
                table: "Resenas",
                column: "UsuarioCedula",
                principalTable: "Usuario",
                principalColumn: "Cedula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resenas_Pelicula_IdPelicula",
                table: "Resenas");

            migrationBuilder.DropForeignKey(
                name: "FK_Resenas_Usuario_UsuarioCedula",
                table: "Resenas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resenas",
                table: "Resenas");

            migrationBuilder.DropIndex(
                name: "IX_Resenas_IdPelicula",
                table: "Resenas");

            migrationBuilder.DropIndex(
                name: "IX_Resenas_UsuarioCedula",
                table: "Resenas");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Resenas");

            migrationBuilder.DropColumn(
                name: "IdPelicula",
                table: "Resenas");

            migrationBuilder.DropColumn(
                name: "UsuarioCedula",
                table: "Resenas");

            migrationBuilder.RenameTable(
                name: "Resenas",
                newName: "Resena");

            migrationBuilder.AddColumn<int>(
                name: "IdResena",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResenaIdResena",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                table: "Pelicula",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdResena",
                table: "Pelicula",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResenaIdResena",
                table: "Pelicula",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resena",
                table: "Resena",
                column: "IdResena");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ResenaIdResena",
                table: "Usuario",
                column: "ResenaIdResena");

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_ResenaIdResena",
                table: "Pelicula",
                column: "ResenaIdResena");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Resena_ResenaIdResena",
                table: "Pelicula",
                column: "ResenaIdResena",
                principalTable: "Resena",
                principalColumn: "IdResena");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Resena_ResenaIdResena",
                table: "Usuario",
                column: "ResenaIdResena",
                principalTable: "Resena",
                principalColumn: "IdResena");
        }
    }
}
