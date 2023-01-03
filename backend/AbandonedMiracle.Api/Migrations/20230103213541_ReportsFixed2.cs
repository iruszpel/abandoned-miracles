using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbandonedMiracle.Api.Migrations
{
    /// <inheritdoc />
    public partial class ReportsFixed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessingStatus",
                table: "Reports",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Reports",
                newName: "ProcessingStatus");
        }
    }
}
