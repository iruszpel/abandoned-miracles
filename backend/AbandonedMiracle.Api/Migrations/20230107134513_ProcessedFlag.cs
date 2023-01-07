using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbandonedMiracle.Api.Migrations
{
    /// <inheritdoc />
    public partial class ProcessedFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Processed",
                table: "Reports",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Processed",
                table: "Reports");
        }
    }
}
