using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class poprawka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypaAkcji",
                table: "Historia",
                newName: "TypAkcji");

            migrationBuilder.RenameColumn(
                name: "IdGrupy",
                table: "Historia",
                newName: "GrupaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypAkcji",
                table: "Historia",
                newName: "TypaAkcji");

            migrationBuilder.RenameColumn(
                name: "GrupaId",
                table: "Historia",
                newName: "IdGrupy");
        }
    }
}
