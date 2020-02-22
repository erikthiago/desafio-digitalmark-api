using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistEnferHos.Infra.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HosHospital",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HosNome = table.Column<string>(type: "varchar(255)", nullable: false),
                    HosTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    HosEndereco = table.Column<string>(type: "varchar(255)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HosHospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnfEnfermeiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EnfNome = table.Column<string>(type: "varchar(255)", nullable: false),
                    EnfTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    COREN = table.Column<string>(type: "varchar(6)", nullable: false),
                    EnfDataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    HospitalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfEnfermeiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnfEnfermeiro_HosHospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "HosHospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnfEnfermeiro_HospitalId",
                table: "EnfEnfermeiro",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnfEnfermeiro");

            migrationBuilder.DropTable(
                name: "HosHospital");
        }
    }
}
