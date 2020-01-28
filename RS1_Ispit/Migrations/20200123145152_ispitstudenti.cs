using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class ispitstudenti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ispiti_Angazovan_AngazovanId",
                table: "Ispiti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ispiti",
                table: "Ispiti");

            migrationBuilder.RenameTable(
                name: "Ispiti",
                newName: "Ispit");

            migrationBuilder.RenameIndex(
                name: "IX_Ispiti_AngazovanId",
                table: "Ispit",
                newName: "IX_Ispit_AngazovanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ispit",
                table: "Ispit",
                column: "IspitID");

            migrationBuilder.CreateTable(
                name: "IspitStudenti",
                columns: table => new
                {
                    IspitStudentiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IspitID = table.Column<int>(nullable: false),
                    Ocjena = table.Column<int>(nullable: false),
                    PristupioIspitu = table.Column<bool>(nullable: false),
                    StudentIme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IspitStudenti", x => x.IspitStudentiID);
                    table.ForeignKey(
                        name: "FK_IspitStudenti_Ispit_IspitID",
                        column: x => x.IspitID,
                        principalTable: "Ispit",
                        principalColumn: "IspitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IspitStudenti_IspitID",
                table: "IspitStudenti",
                column: "IspitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit_Angazovan_AngazovanId",
                table: "Ispit",
                column: "AngazovanId",
                principalTable: "Angazovan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ispit_Angazovan_AngazovanId",
                table: "Ispit");

            migrationBuilder.DropTable(
                name: "IspitStudenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ispit",
                table: "Ispit");

            migrationBuilder.RenameTable(
                name: "Ispit",
                newName: "Ispiti");

            migrationBuilder.RenameIndex(
                name: "IX_Ispit_AngazovanId",
                table: "Ispiti",
                newName: "IX_Ispiti_AngazovanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ispiti",
                table: "Ispiti",
                column: "IspitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ispiti_Angazovan_AngazovanId",
                table: "Ispiti",
                column: "AngazovanId",
                principalTable: "Angazovan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
