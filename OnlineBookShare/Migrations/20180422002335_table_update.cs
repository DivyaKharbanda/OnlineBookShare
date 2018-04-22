using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineBookShare.Migrations
{
    public partial class table_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMaster_Login_UserId",
                table: "BookMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDeatils_Login_LoginDetailsUserId",
                table: "UserDeatils");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDeatils_Login_UserId",
                table: "UserDeatils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "BookMaster");

            migrationBuilder.RenameTable(
                name: "Login",
                newName: "User");

            migrationBuilder.AddColumn<int>(
                name: "ImageNumber",
                table: "BookMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMaster_User_UserId",
                table: "BookMaster",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeatils_User_LoginDetailsUserId",
                table: "UserDeatils",
                column: "LoginDetailsUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeatils_User_UserId",
                table: "UserDeatils",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMaster_User_UserId",
                table: "BookMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDeatils_User_LoginDetailsUserId",
                table: "UserDeatils");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDeatils_User_UserId",
                table: "UserDeatils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ImageNumber",
                table: "BookMaster");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Login");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "BookMaster",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login",
                table: "Login",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMaster_Login_UserId",
                table: "BookMaster",
                column: "UserId",
                principalTable: "Login",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeatils_Login_LoginDetailsUserId",
                table: "UserDeatils",
                column: "LoginDetailsUserId",
                principalTable: "Login",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeatils_Login_UserId",
                table: "UserDeatils",
                column: "UserId",
                principalTable: "Login",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
