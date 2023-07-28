using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDWithAccounts.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectedDisks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    accountId = table.Column<int>(type: "INTEGER", nullable: false),
                    diskId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedDisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedDisks_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedDisks_Disks_diskId",
                        column: x => x.diskId,
                        principalTable: "Disks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedDisks_accountId",
                table: "SelectedDisks",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedDisks_diskId",
                table: "SelectedDisks",
                column: "diskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedDisks");
        }
    }
}
