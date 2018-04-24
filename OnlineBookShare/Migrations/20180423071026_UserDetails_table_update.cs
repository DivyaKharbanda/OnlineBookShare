using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineBookShare.Migrations
{
    public partial class UserDetails_table_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeatils_User_LoginDetailsUserId",
                table: "UserDeatils");

            migrationBuilder.DropIndex(
                name: "IX_UserDeatils_LoginDetailsUserId",
                table: "UserDeatils");

            migrationBuilder.DropColumn(
                name: "LoginDetailsUserId",
                table: "UserDeatils");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "UserDeatils",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ContactNumber",
                table: "UserDeatils",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginDetailsUserId",
                table: "UserDeatils",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDeatils_LoginDetailsUserId",
                table: "UserDeatils",
                column: "LoginDetailsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeatils_User_LoginDetailsUserId",
                table: "UserDeatils",
                column: "LoginDetailsUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
