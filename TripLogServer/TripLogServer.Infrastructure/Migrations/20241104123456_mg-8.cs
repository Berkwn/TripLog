using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripLogServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commands_Trips_TripEntityId",
                table: "commands");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "commands");

            migrationBuilder.AlterColumn<Guid>(
                name: "TripEntityId",
                table: "commands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_commands_Trips_TripEntityId",
                table: "commands",
                column: "TripEntityId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commands_Trips_TripEntityId",
                table: "commands");

            migrationBuilder.AlterColumn<Guid>(
                name: "TripEntityId",
                table: "commands",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "TripId",
                table: "commands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_commands_Trips_TripEntityId",
                table: "commands",
                column: "TripEntityId",
                principalTable: "Trips",
                principalColumn: "Id");
        }
    }
}
