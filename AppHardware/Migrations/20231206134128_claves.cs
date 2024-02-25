using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHardware.Migrations
{
    public partial class claves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //creo indice de Registros
            migrationBuilder.CreateIndex(
                name: "IX_Registros_ProductoId",
                table: "Registros",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_UsuarioId",
                table: "Registros",
                column: "UsuarioId");
            //agrego FJ en productos y usuarios
            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Productos_ProductoId",
                table: "Registros",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Usuarios_UsuarioId",
                table: "Registros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Registros_ProductoId",
                table: "Registros");

            migrationBuilder.DropIndex(
                name: "IX_Registros_UsuarioId",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                    name: "FK_Registros_Productos_ProductoId",
                    table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Usuarios_UsuarioId",
                table: "Registros");


        }
    }
}
