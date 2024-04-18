using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceCenter.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_857 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Residents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Residents_FullName_Number",
                table: "Residents",
                columns: new[] { "FullName", "Number" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Residents_FullName_Number",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Residents");
        }
    }
}
