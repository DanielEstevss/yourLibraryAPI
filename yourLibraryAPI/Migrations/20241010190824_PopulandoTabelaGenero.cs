using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yourLibraryAPI.Migrations;

public partial class PopulandoTabelaGenero : Migration
{  
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("INSERT INTO Generos (Nome)" +
                             "VALUES ('Romance')");

        migrationBuilder.Sql("INSERT INTO Generos (Nome)" +
                             "VALUES ('Ficção')");

        migrationBuilder.Sql("INSERT INTO Generos (Nome)" +
                             "VALUES ('Comédia')");

        migrationBuilder.Sql("INSERT INTO Generos (Nome)" +
                             "VALUES ('Aventura')");

        migrationBuilder.Sql("INSERT INTO Generos (Nome)" +
                             "VALUES ('Terror')");

        migrationBuilder.Sql("INSERT INTO Generos (Nome)" +
                             "VALUES ('Suspense')");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM Generos");
    }
}
