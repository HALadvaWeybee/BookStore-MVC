using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.BookStore.Migrations
{
    /// <inheritdoc />
    public partial class addMultilanguageProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageEnum",
                table: "Books",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageEnum",
                table: "Books");
        }
    }
}
