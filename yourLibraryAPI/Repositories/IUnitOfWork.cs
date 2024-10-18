namespace yourLibraryAPI.Repositories;

public interface IUnitOfWork
{
    IGeneroRepository GeneroRepository { get; }

    ILivrosRepository LivrosRepository { get; }

    Task CommitAsync();
}
