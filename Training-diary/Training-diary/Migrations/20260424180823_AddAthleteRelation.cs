using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_diary.Migrations
{
    /// <inheritdoc />
    public partial class AddAthleteRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AthleteId",
                table: "TrainingSessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessions_AthleteId",
                table: "TrainingSessions",
                column: "AthleteId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSessions_Athletes_AthleteId",
                table: "TrainingSessions",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSessions_Athletes_AthleteId",
                table: "TrainingSessions");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSessions_AthleteId",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "AthleteId",
                table: "TrainingSessions");
        }
    }
}
