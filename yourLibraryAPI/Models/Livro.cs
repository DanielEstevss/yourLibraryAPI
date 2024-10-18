using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace yourLibraryAPI.Models;

public class Livro
{
    public int LivroId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80)]
    public string? Autor { get; set; }

    // Id do gênero que o livro está associado
    public int GeneroId { get; set; }

    [Required]
    public int Preco { get; set; }

    [Required]
    public int Estoque { get; set; }

    [Required]
    [StringLength(80)]
    public string? Editora { get; set; }

    [Required]
    public string? Isbn { get; set; }
    public int AnoPublicacao { get; set; }
    public DateTime DataCadastro { get; set; }

    // Reafirma que cada livro está associado a um Gênero
    [JsonIgnore]
    public Genero? Genero { get; set; }
}
