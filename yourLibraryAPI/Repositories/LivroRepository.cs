using Microsoft.EntityFrameworkCore;
using yourLibraryAPI.Context;
using yourLibraryAPI.Models;

namespace yourLibraryAPI.Repositories;

public class LivroRepository : ILivrosRepository
{
    private readonly yourLibraryDbContext? _context;

    public LivroRepository(yourLibraryDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Livro>> GetTodosLivrosAsync()
    {
        return await _context.Livros.AsNoTracking().ToListAsync();
    }

    // Método que retornar um livro pelo nome
    public async Task<Livro> GetLivroPorNomeAsync(string nome)
    {
        return await _context.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.Nome == nome);
    }

    public async Task<Livro> GetLivroPorId(int id)
    {
        return await _context.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.LivroId == id);
    }

    public Livro CreateLivro(Livro livro)
    {
        if (livro == null)
        {
            throw new ArgumentNullException(nameof(livro));
        }

        _context.Livros.Add(livro);

        return livro;
    }

    public Livro UpdateLivro(Livro livro)
    {
        if (livro == null)
        {
            throw new ArgumentNullException(nameof(livro));
        }

        _context.Entry(livro).State = EntityState.Modified;

        return livro;
    }

    public Livro DeleteLivro(int id)
    {
        var livro = _context.Livros.Find(id);

        if (livro == null)
        {
            throw new ArgumentNullException(nameof(livro));
        }

        _context.Livros.Remove(livro);

        return livro;
    }
}
