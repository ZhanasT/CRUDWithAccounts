using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDWithAccounts.Migrations
{
    /// <inheritdoc />
    public partial class StructureMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "IX_Accounts_Login",
                table: "Accounts",
                column: "Login"
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
