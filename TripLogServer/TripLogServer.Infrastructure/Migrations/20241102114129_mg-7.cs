using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripLogServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "commands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TripEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TripId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_commands_Trips_TripEntityId",
                        column: x => x.TripEntityId,
                        principalTable: "Trips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_commands_appUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "appUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_AppUserId",
                table: "Trips",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_commands_AppUserId",
                table: "commands",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_commands_TripEntityId",
                table: "commands",
                column: "TripEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_appUsers_AppUserId",
                table: "Trips",
                column: "AppUserId",
                principalTable: "appUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_appUsers_AppUserId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "commands");

            migrationBuilder.DropIndex(
                name: "IX_Trips_AppUserId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Trips");
        }
    }
}
