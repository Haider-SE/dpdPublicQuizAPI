using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dpdPublicQuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedStudentsInClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassRoomId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassRoomId",
                table: "Users",
                column: "ClassRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ClassRoom_ClassRoomId",
                table: "Users",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ClassRoom_ClassRoomId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClassRoomId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                table: "Users");
        }
    }
}
