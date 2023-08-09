using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dpdPublicQuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedForiegnKeyInQuestionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionType_QuestionTypeID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionTypeID",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeID",
                table: "Questions",
                column: "QuestionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionType_QuestionTypeID",
                table: "Questions",
                column: "QuestionTypeID",
                principalTable: "QuestionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
