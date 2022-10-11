using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge1.Migrations
{
    /// <inheritdoc />
    public partial class edit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Tipodeproductos_TipodeproductoId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Tipodeproductos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TipodeproductoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "TipodeproductoId",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "Tipodeproducto",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipodeproducto",
                table: "Productos");

            migrationBuilder.AddColumn<int>(
                name: "TipodeproductoId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tipodeproductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipodeproductos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipodeproductoId",
                table: "Productos",
                column: "TipodeproductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Tipodeproductos_TipodeproductoId",
                table: "Productos",
                column: "TipodeproductoId",
                principalTable: "Tipodeproductos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
