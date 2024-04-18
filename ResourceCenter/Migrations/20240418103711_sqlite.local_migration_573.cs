using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceCenter.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_573 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountResident");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Residents",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Residents_AccountId",
                table: "Residents",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Accounts_AccountId",
                table: "Residents",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Accounts_AccountId",
                table: "Residents");

            migrationBuilder.DropIndex(
                name: "IX_Residents_AccountId",
                table: "Residents");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Residents");

            migrationBuilder.CreateTable(
                name: "AccountResident",
                columns: table => new
                {
                    AccountsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountResident", x => new { x.AccountsId, x.ResidentsId });
                    table.ForeignKey(
                        name: "FK_AccountResident_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountResident_Residents_ResidentsId",
                        column: x => x.ResidentsId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountResident_ResidentsId",
                table: "AccountResident",
                column: "ResidentsId");
        }
    }
}
