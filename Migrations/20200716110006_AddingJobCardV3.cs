using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard_MK4.Migrations
{
    public partial class AddingJobCardV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JTFA_Clients",
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
                    table.PrimaryKey("PK_JTFA_Clients", x => x.JTFA_CLIENT_ID);
                });

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

            migrationBuilder.CreateTable(
                name: "JobCardsV3",
                columns: table => new
                {
                    JobCardID = table.Column<Guid>(nullable: false),
                    JobCardName = table.Column<string>(maxLength: 100, nullable: false),
                    Vehicle_ID = table.Column<Guid>(nullable: true),
                    JTFA_CLIENT_ID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCardsV3", x => x.JobCardID);
                    table.ForeignKey(
                        name: "FK_JobCardsV3_JTFA_Clients_JTFA_CLIENT_ID",
                        column: x => x.JTFA_CLIENT_ID,
                        principalTable: "JTFA_Clients",
                        principalColumn: "JTFA_CLIENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobCardsV3_Vehicles_Vehicle_ID",
                        column: x => x.Vehicle_ID,
                        principalTable: "Vehicles",
                        principalColumn: "Vehicle_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskDescriptions",
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
                    table.PrimaryKey("PK_TaskDescriptions", x => x.Task_Description_ID);
                    table.ForeignKey(
                        name: "FK_TaskDescriptions_JobCardsV3_JobCardV3JobCardID",
                        column: x => x.JobCardV3JobCardID,
                        principalTable: "JobCardsV3",
                        principalColumn: "JobCardID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "JobCardsV3",
                columns: new[] { "JobCardID", "JTFA_CLIENT_ID", "JobCardName", "Vehicle_ID" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), null, "Clutch Replacement", null });

            migrationBuilder.CreateIndex(
                name: "IX_JobCardsV3_JTFA_CLIENT_ID",
                table: "JobCardsV3",
                column: "JTFA_CLIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCardsV3_Vehicle_ID",
                table: "JobCardsV3",
                column: "Vehicle_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDescriptions_JobCardV3JobCardID",
                table: "TaskDescriptions",
                column: "JobCardV3JobCardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDescriptions");

            migrationBuilder.DropTable(
                name: "JobCardsV3");

            migrationBuilder.DropTable(
                name: "JTFA_Clients");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
