using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerce.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "products",
              columns: table => new
              {
                                id = table.Column<long>(type: "bigint", nullable: false).Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                                title = table.Column<string>(type: "text", nullable: false),
                                price = table.Column<long>(type: "bigint", nullable: false),
                                description = table.Column<string>(type: "text", nullable: false),
                                category = table.Column<string>(type: "text", nullable: false),
                                quantity = table.Column<long>(type: "bigint", nullable: false),
                                rating = table.Column<long>(type: "bigint", nullable: false),
                },
              constraints: table =>
              {
                  table.PrimaryKey("PK_User", x => x.id);
              }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.DropTable(name: "products");
        }
    }
}
