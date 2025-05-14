using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lms_server.Migrations
{
    /// <inheritdoc />
    public partial class ParsedWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParsedWord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitNumber = table.Column<int>(type: "integer", nullable: false),
                    SentenceNumber = table.Column<int>(type: "integer", nullable: false),
                    Parsing = table.Column<string>(type: "text", nullable: false),
                    Lemma = table.Column<string>(type: "text", nullable: false),
                    DictionaryForm = table.Column<string>(type: "text", nullable: false),
                    Gloss = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsedWord", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParsedWord");
        }
    }
}
