using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JobCard_TaskDescriptions_
{
    public partial class AddVehicleV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VehicleV3Vehicle_ID",
                table: "JobCards",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Vehicle_ID = table.Column<Guid>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    VIN = table.Column<string>(nullable: true),
                    REG = table.Column<string>(nullable: true),
                    Mileage = table.Column<string>(nullable: true),
                    Engine_Number = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    CC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Vehicle_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_VehicleV3Vehicle_ID",
                table: "JobCards",
                column: "VehicleV3Vehicle_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Vehicles_VehicleV3Vehicle_ID",
                table: "JobCards",
                column: "VehicleV3Vehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Vehicles_VehicleV3Vehicle_ID",
                table: "JobCards");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_JobCards_VehicleV3Vehicle_ID",
                table: "JobCards");

            migrationBuilder.DropColumn(
                name: "VehicleV3Vehicle_ID",
                table: "JobCards");
        }
    }
}
