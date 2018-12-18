using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SUM_Project.Data.Migrations
{
    public partial class temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Tilbud",
                columns: table => new
                {
                    tilbud_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    beskrivelse = table.Column<string>(nullable: true),
                    kunde_id = table.Column<int>(nullable: false),
                    pris = table.Column<double>(nullable: false),
                    projekt_ansvarlig = table.Column<int>(nullable: false),
                    rabat = table.Column<double>(nullable: false),
                    slut_dato = table.Column<string>(nullable: true),
                    start_dato = table.Column<string>(nullable: true),
                    titel = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilbud", x => x.tilbud_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tilbud");

          
        }
    }
}
