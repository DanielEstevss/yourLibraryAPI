using Microsoft.EntityFrameworkCore;
using yourLibraryAPI.Models;

namespace yourLibraryAPI.Context;
// Classe responsável por realizar comandos no banco de dados 
public class yourLibraryDbContext : DbContext
{
    public yourLibraryDbContext(DbContextOptions<yourLibraryDbContext> options) : base(options)
    {
    }

    // Mapeando as tabelas para o banco de dados
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Livro> Livros { get; set; }
}
