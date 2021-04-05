using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PerformerDatabaseImplements.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedurePurchase_Procedures_ProcedureId",
                table: "ProcedurePurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedurePurchase_Purchases_PurchaseId",
                table: "ProcedurePurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureVisit_Procedures_ProcedureId",
                table: "ProcedureVisit");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureVisit_Visits_VisitId",
                table: "ProcedureVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcedureVisit",
                table: "ProcedureVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcedurePurchase",
                table: "ProcedurePurchase");

            migrationBuilder.RenameTable(
                name: "ProcedureVisit",
                newName: "ProcedureVisits");

            migrationBuilder.RenameTable(
                name: "ProcedurePurchase",
                newName: "ProcedurePurchases");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureVisit_VisitId",
                table: "ProcedureVisits",
                newName: "IX_ProcedureVisits_VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureVisit_ProcedureId",
                table: "ProcedureVisits",
                newName: "IX_ProcedureVisits_ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedurePurchase_PurchaseId",
                table: "ProcedurePurchases",
                newName: "IX_ProcedurePurchases_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedurePurchase_ProcedureId",
                table: "ProcedurePurchases",
                newName: "IX_ProcedurePurchases_ProcedureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcedureVisits",
                table: "ProcedureVisits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcedurePurchases",
                table: "ProcedurePurchases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedurePurchases_Procedures_ProcedureId",
                table: "ProcedurePurchases",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedurePurchases_Purchases_PurchaseId",
                table: "ProcedurePurchases",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureVisits_Procedures_ProcedureId",
                table: "ProcedureVisits",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureVisits_Visits_VisitId",
                table: "ProcedureVisits",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedurePurchases_Procedures_ProcedureId",
                table: "ProcedurePurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedurePurchases_Purchases_PurchaseId",
                table: "ProcedurePurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureVisits_Procedures_ProcedureId",
                table: "ProcedureVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureVisits_Visits_VisitId",
                table: "ProcedureVisits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcedureVisits",
                table: "ProcedureVisits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcedurePurchases",
                table: "ProcedurePurchases");

            migrationBuilder.RenameTable(
                name: "ProcedureVisits",
                newName: "ProcedureVisit");

            migrationBuilder.RenameTable(
                name: "ProcedurePurchases",
                newName: "ProcedurePurchase");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureVisits_VisitId",
                table: "ProcedureVisit",
                newName: "IX_ProcedureVisit_VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureVisits_ProcedureId",
                table: "ProcedureVisit",
                newName: "IX_ProcedureVisit_ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedurePurchases_PurchaseId",
                table: "ProcedurePurchase",
                newName: "IX_ProcedurePurchase_PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedurePurchases_ProcedureId",
                table: "ProcedurePurchase",
                newName: "IX_ProcedurePurchase_ProcedureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcedureVisit",
                table: "ProcedureVisit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcedurePurchase",
                table: "ProcedurePurchase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedurePurchase_Procedures_ProcedureId",
                table: "ProcedurePurchase",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedurePurchase_Purchases_PurchaseId",
                table: "ProcedurePurchase",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureVisit_Procedures_ProcedureId",
                table: "ProcedureVisit",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureVisit_Visits_VisitId",
                table: "ProcedureVisit",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
