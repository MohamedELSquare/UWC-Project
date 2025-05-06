using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddTagDirectionWithDSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DSensorId",
                schema: "RealTime",
                table: "TagDirections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagDirections_DSensorId",
                schema: "RealTime",
                table: "TagDirections",
                column: "DSensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagDirections_Sensors_DSensorId",
                schema: "RealTime",
                table: "TagDirections",
                column: "DSensorId",
                principalSchema: "Definitions",
                principalTable: "Sensors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagDirections_Sensors_DSensorId",
                schema: "RealTime",
                table: "TagDirections");

            migrationBuilder.DropIndex(
                name: "IX_TagDirections_DSensorId",
                schema: "RealTime",
                table: "TagDirections");

            migrationBuilder.DropColumn(
                name: "DSensorId",
                schema: "RealTime",
                table: "TagDirections");
        }
    }
}
