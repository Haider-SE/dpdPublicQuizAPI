using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dpdPublicQuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedTeacherandClassTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerText",
                table: "Answers",
                newName: "OpenEndedAnswerText");

            migrationBuilder.AddColumn<Guid>(
                name: "OptionID",
                table: "Answers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRoom");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropColumn(
                name: "OptionID",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "OpenEndedAnswerText",
                table: "Answers",
                newName: "AnswerText");
        }
    }
}
