using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace yourLibraryAPI.Models;

public class Genero
{
    // Inicializando a coleção através de um construtor
    public Genero()
    {
        Livros = new Collection<Livro>();
    }

    public int GeneroId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }


    // Coleção do tipo Livro
    // Um gênero poderá ter uma coleção livros
    [JsonIgnore]
    public ICollection<Livro>? Livros { get; set; }
}
