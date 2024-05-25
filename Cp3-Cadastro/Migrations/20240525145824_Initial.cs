using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp3_Cadastro.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    id_pessoa = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_pessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email_pessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha_pessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cpf_pessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.id_pessoa);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id_endereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    rua_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    complemento_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    bairro_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cidade_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    estado_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cep_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    id_pessoa = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    pessoaid_pessoa = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id_endereco);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_pessoaid_pessoa",
                        column: x => x.pessoaid_pessoa,
                        principalTable: "Pessoa",
                        principalColumn: "id_pessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_pessoaid_pessoa",
                table: "Endereco",
                column: "pessoaid_pessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
