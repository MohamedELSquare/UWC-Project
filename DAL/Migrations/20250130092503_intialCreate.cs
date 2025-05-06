using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class intialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RealTime");

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "RealTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Epc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rssi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags",
                schema: "RealTime");
        }
    }
}
