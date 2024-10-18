using yourLibraryAPI.Models;

namespace yourLibraryAPI.Repositories;

public interface ILivrosRepository
{
    // Assinatura dos métodos da classe "LivroRepository"

    // Retorna um livro pelo nome
    Task<Livro> GetLivroPorNomeAsync(string nome);

    // Retorna um livro pelo id
    Task<Livro> GetLivroPorId(int id);

    // Retorna todos os livros cadastrados
    Task<IEnumerable<Livro>> GetTodosLivrosAsync();

    // Cadastra um livro
    Livro CreateLivro(Livro livro);

    // Atualiza o cadastro de um livro
    Livro UpdateLivro(Livro livro);

    // Deleta o cadastro de um livro
    Livro DeleteLivro(int id);
}
