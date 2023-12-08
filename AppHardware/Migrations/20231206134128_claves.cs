using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHardware.Migrations
{
    public partial class claves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //renombro columnas de Productos
            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Productos",
                newName: "CatId");
            
            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Productos",
                newName: "MarcaNombre");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Productos",
                newName: "ModeloNombre");

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            //agrego columna ProductoId
            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Registros",
                nullable: true);

            //agrego y saco columnas en Registros
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Registros",
                nullable: true); 

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Registros");

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
            migrationBuilder.RenameColumn(
                name: "CatId",
                table: "Productos",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "MarcaNombre",
                table: "Productos",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "ModeloNombre",
                table: "Productos",
                newName: "Modelo");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Registros");

            migrationBuilder.AddColumn<string>(
                   name: "Nombre",
                   table: "Registros",
                   nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Registros",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Registros");

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
