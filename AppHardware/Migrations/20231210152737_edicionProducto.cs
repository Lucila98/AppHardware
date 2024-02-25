using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHardware.Migrations
{
    public partial class addmigrationedicionProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
               name: "ProductoDescription",
               table: "Productos",
               newName: "ProductoDescripcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
