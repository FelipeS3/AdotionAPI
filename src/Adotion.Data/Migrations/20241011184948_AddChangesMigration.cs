using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adotion.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddChangesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adotantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adotantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Especie = table.Column<string>(type: "varchar(100)", nullable: false),
                    Raca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    NecessidadesEspeciais = table.Column<string>(type: "varchar(100)", nullable: true),
                    Castrado = table.Column<bool>(type: "bit", nullable: false),
                    Vacinado = table.Column<bool>(type: "bit", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1500)", nullable: true),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(1000)", nullable: false),
                    AdotanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animais_Adotantes_AdotanteId",
                        column: x => x.AdotanteId,
                        principalTable: "Adotantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdotanteId = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Adotantes_AdotanteId",
                        column: x => x.AdotanteId,
                        principalTable: "Adotantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animais_AdotanteId",
                table: "Animais",
                column: "AdotanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_AdotanteId",
                table: "Enderecos",
                column: "AdotanteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Adotantes");
        }
    }
}
