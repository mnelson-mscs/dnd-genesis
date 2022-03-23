using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dndgenesis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    RaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolMagic",
                columns: table => new
                {
                    SchoolMagicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolMagicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolMagic", x => x.SchoolMagicId);
                });

            migrationBuilder.CreateTable(
                name: "DndClass",
                columns: table => new
                {
                    DndClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DndClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    HitDice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndClass", x => x.DndClassId);
                    table.ForeignKey(
                        name: "FK_DndClass_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subrace",
                columns: table => new
                {
                    SubraceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubraceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    AbilityScores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subrace", x => x.SubraceId);
                    table.ForeignKey(
                        name: "FK_Subrace_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subrace_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    SpellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpellName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    SchoolMagicId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.SpellId);
                    table.ForeignKey(
                        name: "FK_Spell_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spell_SchoolMagic_SchoolMagicId",
                        column: x => x.SchoolMagicId,
                        principalTable: "SchoolMagic",
                        principalColumn: "SchoolMagicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DndSubclass",
                columns: table => new
                {
                    DndSubclassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DndClassId = table.Column<int>(type: "int", nullable: false),
                    DndSubclassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DndSubclass", x => x.DndSubclassId);
                    table.ForeignKey(
                        name: "FK_DndSubclass_DndClass_DndClassId",
                        column: x => x.DndClassId,
                        principalTable: "DndClass",
                        principalColumn: "DndClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DndClass_BookId",
                table: "DndClass",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_DndSubclass_DndClassId",
                table: "DndSubclass",
                column: "DndClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_BookId",
                table: "Spell",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_SchoolMagicId",
                table: "Spell",
                column: "SchoolMagicId");

            migrationBuilder.CreateIndex(
                name: "IX_Subrace_BookId",
                table: "Subrace",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Subrace_RaceId",
                table: "Subrace",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DndSubclass");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "Subrace");

            migrationBuilder.DropTable(
                name: "DndClass");

            migrationBuilder.DropTable(
                name: "SchoolMagic");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
