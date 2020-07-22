using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JTFA_Invoice_
{
    public partial class Remove_Reference_Navigation_Property_JobCardV3_From_JTFA_Invoice_Type_And_Add_ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JTFA_Invoice_JobCardV3_JobcardV3JobCardID",
                table: "JTFA_Invoice");

            migrationBuilder.DropTable(
                name: "TaskDescriptionV3");

            migrationBuilder.DropTable(
                name: "JobCardV3");

            migrationBuilder.DropTable(
                name: "JTFA_Client");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_JTFA_Invoice_JobcardV3JobCardID",
                table: "JTFA_Invoice");

            migrationBuilder.DropColumn(
                name: "JobcardV3JobCardID",
                table: "JTFA_Invoice");

            migrationBuilder.AddColumn<Guid>(
                name: "JobCardID",
                table: "JTFA_Invoice",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobCardID",
                table: "JTFA_Invoice");

            migrationBuilder.AddColumn<Guid>(
                name: "JobcardV3JobCardID",
                table: "JTFA_Invoice",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JTFA_Client",
                columns: table => new
                {
                    JTFA_CLIENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notifications_Permission_Levels_Allowed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JTFA_Client", x => x.JTFA_CLIENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Vehicle_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Engine_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Vehicle_ID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardV3",
                columns: table => new
                {
                    JobCardID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JTFA_CLIENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobCardName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vehicle_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardV3", x => x.JobCardID);
                    table.ForeignKey(
                        name: "FK_JobCardV3_JTFA_Client_JTFA_CLIENT_ID",
                        column: x => x.JTFA_CLIENT_ID,
                        principalTable: "JTFA_Client",
                        principalColumn: "JTFA_CLIENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobCardV3_Vehicle_Vehicle_ID",
                        column: x => x.Vehicle_ID,
                        principalTable: "Vehicle",
                        principalColumn: "Vehicle_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskDescriptionV3",
                columns: table => new
                {
                    Task_Description_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCardIDForRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCardV3JobCardID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LabourCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartsPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTaskCost = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDescriptionV3", x => x.Task_Description_ID);
                    table.ForeignKey(
                        name: "FK_TaskDescriptionV3_JobCardV3_JobCardV3JobCardID",
                        column: x => x.JobCardV3JobCardID,
                        principalTable: "JobCardV3",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JTFA_Invoice_JobcardV3JobCardID",
                table: "JTFA_Invoice",
                column: "JobcardV3JobCardID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardV3_JTFA_CLIENT_ID",
                table: "JobCardV3",
                column: "JTFA_CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardV3_Vehicle_ID",
                table: "JobCardV3",
                column: "Vehicle_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDescriptionV3_JobCardV3JobCardID",
                table: "TaskDescriptionV3",
                column: "JobCardV3JobCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_JTFA_Invoice_JobCardV3_JobcardV3JobCardID",
                table: "JTFA_Invoice",
                column: "JobcardV3JobCardID",
                principalTable: "JobCardV3",
                principalColumn: "JobCardID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
