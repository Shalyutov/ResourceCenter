using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceCenter.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_466 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Accounts_AccountsId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Residents_ResidentsId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "AccountResident");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_ResidentsId",
                table: "AccountResident",
                newName: "IX_AccountResident_ResidentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountResident",
                table: "AccountResident",
                columns: new[] { "AccountsId", "ResidentsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountResident_Accounts_AccountsId",
                table: "AccountResident",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountResident_Residents_ResidentsId",
                table: "AccountResident",
                column: "ResidentsId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountResident_Accounts_AccountsId",
                table: "AccountResident");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountResident_Residents_ResidentsId",
                table: "AccountResident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountResident",
                table: "AccountResident");

            migrationBuilder.RenameTable(
                name: "AccountResident",
                newName: "Enrollments");

            migrationBuilder.RenameIndex(
                name: "IX_AccountResident_ResidentsId",
                table: "Enrollments",
                newName: "IX_Enrollments_ResidentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                columns: new[] { "AccountsId", "ResidentsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Accounts_AccountsId",
                table: "Enrollments",
                column: "AccountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Residents_ResidentsId",
                table: "Enrollments",
                column: "ResidentsId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
