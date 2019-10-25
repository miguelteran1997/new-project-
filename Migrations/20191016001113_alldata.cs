using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OffPractice.Migrations
{
    public partial class alldata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    CID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CN = table.Column<string>(nullable: true),
                    TID = table.Column<int>(nullable: false),
                    TN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PN = table.Column<string>(nullable: true),
                    PL = table.Column<string>(nullable: true),
                    CID = table.Column<int>(nullable: false),
                    TID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PID);
                    table.ForeignKey(
                        name: "FK_Players_Coach_CID",
                        column: x => x.CID,
                        principalTable: "Coach",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Team_TID",
                        column: x => x.TID,
                        principalTable: "Team",
                        principalColumn: "TID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_CID",
                table: "Players",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TID",
                table: "Players",
                column: "TID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Coach");
        }
    }
}
