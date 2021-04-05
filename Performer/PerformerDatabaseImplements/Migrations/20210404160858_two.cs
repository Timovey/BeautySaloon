using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PerformerDatabaseImplements.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Clients_ClientId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Clients_ClientId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Clients_ClientId",
                table: "Visits");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Visits",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Purchases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Procedures",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Clients_ClientId",
                table: "Procedures",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Clients_ClientId",
                table: "Purchases",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Clients_ClientId",
                table: "Visits",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Clients_ClientId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Clients_ClientId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Clients_ClientId",
                table: "Visits");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Visits",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Purchases",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Procedures",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Clients_ClientId",
                table: "Procedures",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Clients_ClientId",
                table: "Purchases",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Clients_ClientId",
                table: "Visits",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
