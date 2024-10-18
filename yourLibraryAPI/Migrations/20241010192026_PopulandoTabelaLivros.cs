using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yourLibraryAPI.Migrations;

public partial class PopulandoTabelaLivros : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("INSERT INTO Livros (Nome, Autor, GeneroId, Preco, Estoque, Editora, Isbn, AnoPublicacao, DataCadastro)" +
                             "VALUES ('Orgulho e Preconceito', 'Jane Austen', 1, 29.90, 8, 'Martin Claret', '9788572325192', 1813, GETDATE())");

        migrationBuilder.Sql("INSERT INTO Livros (Nome, Autor, GeneroId, Preco, Estoque, Editora, Isbn, AnoPublicacao, DataCadastro)" +
                             "VALUES ('1984', 'George Orwell', 2, 39.90, 3, 'Companhia das Letras', '9788535914849', 1949, GETDATE())");

        migrationBuilder.Sql("INSERT INTO Livros (Nome, Autor, GeneroId, Preco, Estoque, Editora, Isbn, AnoPublicacao, DataCadastro)" +
                             "VALUES ('O Guia do Mochileiro das Galáxias', 'Douglas Adams', 3, 49.90, 12, 'Arqueiro', '9788599296943', 1979, GETDATE())");

        migrationBuilder.Sql("INSERT INTO Livros (Nome, Autor, GeneroId, Preco, Estoque, Editora, Isbn, AnoPublicacao, DataCadastro)" +
                             "VALUES ('A Ilha do Tesouro', 'Robert Louis Stevenson', 4, 34.90, 6, 'Zahar', '9788537801529', 1883, GETDATE())");

        migrationBuilder.Sql("INSERT INTO Livros (Nome, Autor, GeneroId, Preco, Estoque, Editora, Isbn, AnoPublicacao, DataCadastro)" +
                             "VALUES ('Drácula', 'Bram Stoker', 5, 54.90, 10, 'Nova Fronteira', '9788520932747', 1897, GETDATE())");

        migrationBuilder.Sql("INSERT INTO Livros (Nome, Autor, GeneroId, Preco, Estoque, Editora, Isbn, AnoPublicacao, DataCadastro)" +
                             "VALUES ('O Silêncio dos Inocentes', 'Thomas Harris', 6, 69.90, 5, 'BestBolso', '9788577991996', 1988, GETDATE())");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM Livros");
    }
}
