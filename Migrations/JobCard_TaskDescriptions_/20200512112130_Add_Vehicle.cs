using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JobCard_TaskDescriptions_
{
    public partial class Add_Vehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Vehicles_VehicleV3Vehicle_ID",
                table: "JobCards");

            migrationBuilder.AddColumn<Guid>(
                name: "Vehicle_ID",
                table: "JobCards",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicles_V3",
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
                    table.PrimaryKey("PK_Vehicles_V3", x => x.Vehicle_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_Vehicle_ID",
                table: "JobCards",
                column: "Vehicle_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Vehicles_V3_VehicleV3Vehicle_ID",
                table: "JobCards",
                column: "VehicleV3Vehicle_ID",
                principalTable: "Vehicles_V3",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Vehicles_Vehicle_ID",
                table: "JobCards",
                column: "Vehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Vehicles_V3_VehicleV3Vehicle_ID",
                table: "JobCards");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Vehicles_Vehicle_ID",
                table: "JobCards");

            migrationBuilder.DropTable(
                name: "Vehicles_V3");

            migrationBuilder.DropIndex(
                name: "IX_JobCards_Vehicle_ID",
                table: "JobCards");

            migrationBuilder.DropColumn(
                name: "Vehicle_ID",
                table: "JobCards");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Vehicles_VehicleV3Vehicle_ID",
                table: "JobCards",
                column: "VehicleV3Vehicle_ID",
                principalTable: "Vehicles",
                principalColumn: "Vehicle_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
