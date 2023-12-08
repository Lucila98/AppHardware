using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHardware.Migrations
{
    public partial class edicionUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //cambios en usuario
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isIT",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //borrar columna en registros
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Registros");

            //cambiar nullable en registro
            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Registros",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Registros",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isIT",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Registros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Registros",
                nullable: true, 
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Registros",
                nullable: true,
                oldClrType: typeof(int));

        }
    }
}
