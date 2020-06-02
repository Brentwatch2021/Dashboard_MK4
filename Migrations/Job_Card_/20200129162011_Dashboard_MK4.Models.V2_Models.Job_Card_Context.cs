using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.Job_Card_
{
    public partial class Dashboard_MK4ModelsV2_ModelsJob_Card_Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCards",
                columns: table => new
                {
                    JobCardID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    VIN = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Car = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Invoice = table.Column<string>(nullable: true),
                    REG = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mileage = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCards", x => x.JobCardID);
                });

            migrationBuilder.InsertData(
                table: "JobCards",
                columns: new[] { "JobCardID", "Car", "Date", "Email", "Invoice", "Mileage", "Name", "Notes", "Phone", "REG", "Total", "VIN" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Toyota Hilux", new DateTime(2020, 1, 29, 16, 20, 10, 421, DateTimeKind.Utc).AddTicks(929), "blah@micarcentre.com", "SC 1000", "10000000000", "MICar Centre", "Awe", "021 558 4589", "CY", "R999999999999", "DRUK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCards");
        }
    }
}
