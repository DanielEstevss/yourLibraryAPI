using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yourLibraryAPI.Context;
using yourLibraryAPI.Models;
using yourLibraryAPI.Repositories;

namespace yourLibraryAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public LivrosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livro>>> GetLivrosAsync()
    {
        var livros = await _unitOfWork.LivrosRepository.GetTodosLivrosAsync();

        if (livros is null)
        {
            return NotFound("Livros não encontrados");
        }

        return Ok(livros);
    }

    [HttpGet("nome", Name = "ObterLivro")]
    public async Task<ActionResult<Livro>> GetLivroIdAsync(string nome)
    {
        var livro = await _unitOfWork.LivrosRepository.GetLivroPorNomeAsync(nome);

        if (livro is null)
        {
            return NotFound($"Livro de nome {nome} não encontrado");
        }

        return Ok(livro);
    }

    [HttpPost]
    public async Task<ActionResult<Livro>> PostLivro(Livro livro)
    {
        if (livro is null)
        {
            return BadRequest("Dados inválidos");
        }

        var livroCriado = _unitOfWork.LivrosRepository.CreateLivro(livro);

        await _unitOfWork.CommitAsync();

        return new CreatedAtRouteResult("ObterLivro", new { nome = livroCriado.Nome }, livroCriado);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Livro>> PutLivro(int id, Livro livro)
    {
        if (id != livro.LivroId)
        {
            return BadRequest("Livro não encontrado");
        }

        var livroAtualizado = _unitOfWork.LivrosRepository.UpdateLivro(livro);

        await _unitOfWork.CommitAsync();

        return Ok(livroAtualizado);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Livro>> DeleteLivro(int id)
    {
        var livro = _unitOfWork.LivrosRepository.GetLivroPorId(id);

        if (livro is null)
        {
            return NotFound($"Livro de nome {id} não encontrado");
        }

        var livroExcluido = _unitOfWork.LivrosRepository.DeleteLivro(id);

        await _unitOfWork.CommitAsync();

        return Ok(livroExcluido);
    }
}
