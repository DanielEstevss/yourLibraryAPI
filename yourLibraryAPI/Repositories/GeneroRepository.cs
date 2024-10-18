using Microsoft.EntityFrameworkCore;
using yourLibraryAPI.Context;
using yourLibraryAPI.Models;

namespace yourLibraryAPI.Repositories;

public class GeneroRepository : IGeneroRepository
{
    // Instância da classe "yourLibraryDbContext"
    private readonly yourLibraryDbContext? _context;

    public GeneroRepository(yourLibraryDbContext? context)
    {
        _context = context;
    }

    // Método que retornar todos os gêneros
    public async Task<IEnumerable<Genero>> GetTodosGenerosAsync()
    {
        return await _context.Generos.AsNoTracking().ToListAsync();
    }

    // Método que retornar um gênero por id
    public async Task<Genero> GetGeneroPorIdAsync(int id)
    {
        return await _context.Generos.FirstOrDefaultAsync(g => g.GeneroId == id);
    }

    // Método que adiciona um gênero
    public Genero CreateGenero(Genero genero)
    {
        if (genero == null)
        {
            throw new ArgumentNullException(nameof(genero));
        }

        _context.Generos.Add(genero);

        return genero;
    }

    // Método que atualiza um gênero
    public Genero UpdateGenero(Genero genero)
    {
        if (genero == null)
        {
            throw new ArgumentNullException(nameof(genero));
        }

        _context.Entry(genero).State = EntityState.Modified;

        return genero;
    }

    // Método que deleta um gênero
    public Genero DeleteGenero(int id)
    {
        var genero = _context.Generos.Find(id);

        if (genero == null)
        {
            throw new ArgumentNullException(nameof(genero));
        }

        _context.Generos.Remove(genero);

        return genero;
    }
}
