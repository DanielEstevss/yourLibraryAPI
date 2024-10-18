using yourLibraryAPI.Models;

namespace yourLibraryAPI.Repositories;

public interface IGeneroRepository
{
    // Assinatura dos métodos da classe "GeneroRepository"

    // Retorna todos os gêneros cadastrados
    Task<IEnumerable<Genero>> GetTodosGenerosAsync();

    // Retorna um gênero pelo id
    Task<Genero> GetGeneroPorIdAsync(int id);

    // Cadastra um gênero
    Genero CreateGenero(Genero genero);

    // Atualiza o cadastro de um gênero
    Genero UpdateGenero(Genero genero);

    // Deleta o cadastro de um gênero
    Genero DeleteGenero(int id);
}
