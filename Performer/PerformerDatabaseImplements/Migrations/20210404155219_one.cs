using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PerformerDatabaseImplements.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Purchases_PurchaseId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Visits_VisitId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_PurchaseId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_VisitId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "Procedures");

            migrationBuilder.CreateTable(
                name: "ProcedurePurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedurePurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedurePurchase_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedurePurchase_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    VisitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedureVisit_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureVisit_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedurePurchase_ProcedureId",
                table: "ProcedurePurchase",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedurePurchase_PurchaseId",
                table: "ProcedurePurchase",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureVisit_ProcedureId",
                table: "ProcedureVisit",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureVisit_VisitId",
                table: "ProcedureVisit",
                column: "VisitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcedurePurchase");

            migrationBuilder.DropTable(
                name: "ProcedureVisit");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Procedures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "Procedures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_PurchaseId",
                table: "Procedures",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_VisitId",
                table: "Procedures",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Purchases_PurchaseId",
                table: "Procedures",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Visits_VisitId",
                table: "Procedures",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
