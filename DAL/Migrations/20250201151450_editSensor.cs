using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class editSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Flag",
                schema: "RealTime",
                table: "Sensors",
                newName: "Direction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Direction",
                schema: "RealTime",
                table: "Sensors",
                newName: "Flag");
        }
    }
}
