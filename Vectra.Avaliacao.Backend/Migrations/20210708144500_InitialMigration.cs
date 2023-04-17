using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vectra.Avaliacao.Backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ID", "Agencia", "Cliente", "CREATED_AT", "IS_ACTIVE", "Numero", "Saldo", "UPDATED_AT" },
                values: new object[] { 1, "9237", "Cliente 1", new DateTime(2021, 7, 8, 11, 45, 0, 423, DateTimeKind.Local).AddTicks(5047), true, "33521-5", 0.10000000000000001, new DateTime(2021, 7, 8, 11, 45, 0, 423, DateTimeKind.Local).AddTicks(5071) });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ID", "Agencia", "Cliente", "CREATED_AT", "IS_ACTIVE", "Numero", "Saldo", "UPDATED_AT" },
                values: new object[] { 2, "9237", "Cliente 2", new DateTime(2021, 7, 8, 11, 45, 0, 423, DateTimeKind.Local).AddTicks(5117), true, "33521-5", 0.10000000000000001, new DateTime(2021, 7, 8, 11, 45, 0, 423, DateTimeKind.Local).AddTicks(5119) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
