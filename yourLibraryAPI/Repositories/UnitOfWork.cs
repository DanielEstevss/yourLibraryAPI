
using yourLibraryAPI.Context;

namespace yourLibraryAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IGeneroRepository? _generoRepo;

    private ILivrosRepository? _livrosRepo;

    public yourLibraryDbContext _context;

    public UnitOfWork(yourLibraryDbContext? context)
    {
        _context = context;
    }


    public IGeneroRepository GeneroRepository
    {
        get { return _generoRepo = _generoRepo ?? new GeneroRepository(_context); }
    }

    public ILivrosRepository LivrosRepository
    {
        get { return _livrosRepo = _livrosRepo ?? new LivroRepository(_context); }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
