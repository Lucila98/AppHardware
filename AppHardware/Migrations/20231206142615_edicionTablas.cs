using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHardware.Migrations
{
    public partial class edicionTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Productos",
                newName: "ProductoDescripcion");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // TODO: Missing down coding

        }
    }
}
