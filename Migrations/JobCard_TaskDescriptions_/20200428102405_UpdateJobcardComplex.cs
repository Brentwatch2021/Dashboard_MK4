using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JobCard_TaskDescriptions_
{
    public partial class UpdateJobcardComplex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDescriptions_JobCards_JobCardV3JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_TaskDescriptions_JobCardV3JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.DeleteData(
                table: "TaskDescriptions",
                keyColumn: "Task_Description_ID",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DropColumn(
                name: "JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.DropColumn(
                name: "JobCardV3JobCardID",
                table: "TaskDescriptions");

            migrationBuilder.AddColumn<Guid>(
                name: "JobCardIDForRef",
                table: "TaskDescriptions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientDisplayID",
                table: "JobCards",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleDisplayID",
                table: "JobCards",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client_Display_ID",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    Client_DisplayID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Display_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaskDescripsDisplayIds",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TaskName = table.Column<string>(nullable: true),
                    TaskID = table.Column<Guid>(nullable: false),
                    JobCardV3JobCardID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDescripsDisplayIds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaskDescripsDisplayIds_JobCards_JobCardV3JobCardID",
                        column: x => x.JobCardV3JobCardID,
                        principalTable: "JobCards",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Display_ID",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    VehicleName = table.Column<string>(nullable: true),
                    Vehicle_ID_Display = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Display_ID", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_ClientDisplayID",
                table: "JobCards",
                column: "ClientDisplayID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_VehicleDisplayID",
                table: "JobCards",
                column: "VehicleDisplayID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDescripsDisplayIds_JobCardV3JobCardID",
                table: "TaskDescripsDisplayIds",
                column: "JobCardV3JobCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Client_Display_ID_ClientDisplayID",
                table: "JobCards",
                column: "ClientDisplayID",
                principalTable: "Client_Display_ID",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCards_Vehicle_Display_ID_VehicleDisplayID",
                table: "JobCards",
                column: "VehicleDisplayID",
                principalTable: "Vehicle_Display_ID",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Client_Display_ID_ClientDisplayID",
                table: "JobCards");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCards_Vehicle_Display_ID_VehicleDisplayID",
                table: "JobCards");

            migrationBuilder.DropTable(
                name: "Client_Display_ID");

            migrationBuilder.DropTable(
                name: "TaskDescripsDisplayIds");

            migrationBuilder.DropTable(
                name: "Vehicle_Display_ID");

            migrationBuilder.DropIndex(
                name: "IX_JobCards_ClientDisplayID",
                table: "JobCards");

            migrationBuilder.DropIndex(
                name: "IX_JobCards_VehicleDisplayID",
                table: "JobCards");

            migrationBuilder.DropColumn(
                name: "JobCardIDForRef",
                table: "TaskDescriptions");

            migrationBuilder.DropColumn(
                name: "ClientDisplayID",
                table: "JobCards");

            migrationBuilder.DropColumn(
                name: "VehicleDisplayID",
                table: "JobCards");

            migrationBuilder.AddColumn<Guid>(
                name: "JobCardID",
                table: "TaskDescriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobCardV3JobCardID",
                table: "TaskDescriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TaskDescriptions",
                columns: new[] { "Task_Description_ID", "Description", "JobCardID", "JobCardV3JobCardID", "LabourCost", "PartsPrice", "TotalTaskCost" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000015"), "Remove and fit clutch", new Guid("00000000-0000-0000-0000-000000000012"), null, "1500", "2000", "3500" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDescriptions_JobCardV3JobCardID",
                table: "TaskDescriptions",
                column: "JobCardV3JobCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDescriptions_JobCards_JobCardV3JobCardID",
                table: "TaskDescriptions",
                column: "JobCardV3JobCardID",
                principalTable: "JobCards",
                principalColumn: "JobCardID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
