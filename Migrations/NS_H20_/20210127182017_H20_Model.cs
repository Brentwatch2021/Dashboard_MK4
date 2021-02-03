using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.NS_H20_
{
    public partial class H20_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "H20_Datasets",
                columns: table => new
                {
                    NS_H20_ID = table.Column<Guid>(nullable: false),
                    Litres_In_Stock = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_H20_Datasets", x => x.NS_H20_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "H20_Datasets");
        }
    }
}
