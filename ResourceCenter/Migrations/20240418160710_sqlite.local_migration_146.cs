using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceCenter.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_146 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountResident");

            migrationBuilder.CreateTable(
                name: "ResidentAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResidentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentAccounts", x => new { x.AccountId, x.ResidentId });
                    table.ForeignKey(
                        name: "FK_ResidentAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentAccounts_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentAccounts_ResidentId",
                table: "ResidentAccounts",
                column: "ResidentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentAccounts");

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
