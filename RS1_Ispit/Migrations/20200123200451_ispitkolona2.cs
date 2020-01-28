using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class ispitkolona2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentIme",
                table: "IspitStudenti");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "IspitStudenti",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IspitStudenti_StudentID",
                table: "IspitStudenti",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_IspitStudenti_Student_StudentID",
                table: "IspitStudenti",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IspitStudenti_Student_StudentID",
                table: "IspitStudenti");

            migrationBuilder.DropIndex(
                name: "IX_IspitStudenti_StudentID",
                table: "IspitStudenti");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "IspitStudenti");

            migrationBuilder.AddColumn<string>(
                name: "StudentIme",
                table: "IspitStudenti",
                nullable: true);
        }
    }
}
