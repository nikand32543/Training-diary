using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_diary.Migrations
{
    /// <inheritdoc />
    public partial class delFirstName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Athletes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Athletes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
