using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations.JTFA_Invoice_
{
    public partial class AddingJTFA_Invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JTFA_Client",
                columns: table => new
                {
                    JTFA_CLIENT_ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Notifications_Permission_Levels_Allowed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JTFA_Client", x => x.JTFA_CLIENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
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
                    table.PrimaryKey("PK_Vehicle", x => x.Vehicle_ID);
                });

            migrationBuilder.CreateTable(
                name: "JobCardV3",
                columns: table => new
                {
                    JobCardID = table.Column<Guid>(nullable: false),
                    JobCardName = table.Column<string>(maxLength: 100, nullable: false),
                    Vehicle_ID = table.Column<Guid>(nullable: true),
                    JTFA_CLIENT_ID = table.Column<Guid>(nullable: true)
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
                name: "JTFA_Invoice",
                columns: table => new
                {
                    JTFA_Invoice_ID = table.Column<Guid>(nullable: false),
                    INV_Number = table.Column<int>(nullable: false),
                    JobcardV3JobCardID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JTFA_Invoice", x => x.JTFA_Invoice_ID);
                    table.ForeignKey(
                        name: "FK_JTFA_Invoice_JobCardV3_JobcardV3JobCardID",
                        column: x => x.JobcardV3JobCardID,
                        principalTable: "JobCardV3",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskDescriptionV3",
                columns: table => new
                {
                    Task_Description_ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LabourCost = table.Column<string>(nullable: true),
                    PartsPrice = table.Column<string>(nullable: true),
                    TotalTaskCost = table.Column<string>(nullable: true),
                    JobCardV3JobCardID = table.Column<Guid>(nullable: true),
                    JobCardIDForRef = table.Column<Guid>(nullable: false)
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
                name: "IX_JobCardV3_JTFA_CLIENT_ID",
                table: "JobCardV3",
                column: "JTFA_CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardV3_Vehicle_ID",
                table: "JobCardV3",
                column: "Vehicle_ID");

            migrationBuilder.CreateIndex(
                name: "IX_JTFA_Invoice_JobcardV3JobCardID",
                table: "JTFA_Invoice",
                column: "JobcardV3JobCardID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDescriptionV3_JobCardV3JobCardID",
                table: "TaskDescriptionV3",
                column: "JobCardV3JobCardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JTFA_Invoice");

            migrationBuilder.DropTable(
                name: "TaskDescriptionV3");

            migrationBuilder.DropTable(
                name: "JobCardV3");

            migrationBuilder.DropTable(
                name: "JTFA_Client");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
