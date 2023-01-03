using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbandonedMiracle.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReportsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_RegisteringUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_RegisteringUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Reports",
                newName: "ReportingUserId");

            migrationBuilder.RenameColumn(
                name: "RegisteringUserId",
                table: "Reports",
                newName: "Longitude");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Reports",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Reports",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportingUserId",
                table: "Reports",
                column: "ReportingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_ReportingUserId",
                table: "Reports",
                column: "ReportingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_ReportingUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_ReportingUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "ReportingUserId",
                table: "Reports",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Reports",
                newName: "RegisteringUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Reports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_RegisteringUserId",
                table: "Reports",
                column: "RegisteringUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_RegisteringUserId",
                table: "Reports",
                column: "RegisteringUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
