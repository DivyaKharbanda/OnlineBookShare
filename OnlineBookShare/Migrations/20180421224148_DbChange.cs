using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineBookShare.Migrations
{
    public partial class DbChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeatils_Login_loginUserId",
                table: "UserDeatils");

            migrationBuilder.DropIndex(
                name: "IX_UserDeatils_loginUserId",
                table: "UserDeatils");

            migrationBuilder.DropColumn(
                name: "loginUserId",
                table: "UserDeatils");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserDeatils",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserDeatils_UserId",
                table: "UserDeatils",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeatils_Login_UserId",
                table: "UserDeatils",
                column: "UserId",
                principalTable: "Login",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeatils_Login_UserId",
                table: "UserDeatils");

            migrationBuilder.DropIndex(
                name: "IX_UserDeatils_UserId",
                table: "UserDeatils");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDeatils");

            migrationBuilder.AddColumn<int>(
                name: "loginUserId",
                table: "UserDeatils",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDeatils_loginUserId",
                table: "UserDeatils",
                column: "loginUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeatils_Login_loginUserId",
                table: "UserDeatils",
                column: "loginUserId",
                principalTable: "Login",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
