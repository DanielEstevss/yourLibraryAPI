using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yourLibraryAPI.Models;
using yourLibraryAPI.Repositories;

namespace yourLibraryAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class GenerosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public GenerosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genero>>> GetGenerosAsync()
    {
        var generos = await _unitOfWork.GeneroRepository.GetTodosGenerosAsync();

        if (generos is null)
        {
            return NotFound("Gêneros não encontrados");
        }

        return Ok(generos);
    }

    [HttpGet("{id:int}", Name = "ObterGenero")]
    public async Task<ActionResult<Genero>> GetGeneroIdAsync(int id)
    {
        var genero = await _unitOfWork.GeneroRepository.GetGeneroPorIdAsync(id);

        if (genero is null)
        {
            return NotFound($"Gênero de id {id} não encontrados");
        }

        return Ok(genero);
    }

    [HttpPost]
    public async Task<ActionResult<GeneroRepository>> PostGenero(Genero genero)
    {
        if (genero is null)
        {
            return BadRequest("Dados inválidos");
        }

        var generoCriado = _unitOfWork.GeneroRepository.CreateGenero(genero);

        await _unitOfWork.CommitAsync();

        return new CreatedAtRouteResult("ObterGenero", new { id = generoCriado.GeneroId}, generoCriado);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Genero>> PutGenero(int id, Genero genero)
    {
        if (id != genero.GeneroId)
        {
            return BadRequest("Gênero não encontrado");
        }

        var generoAtualizado = _unitOfWork.GeneroRepository.UpdateGenero(genero);

        await _unitOfWork.CommitAsync();

        return Ok(generoAtualizado);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Genero>> DeleteGenero(int id)
    {
        var genero = _unitOfWork.GeneroRepository.GetGeneroPorIdAsync(id);

        if (genero is null)
        {
            return NotFound($"Gênero de id {id} não encontrado");
        }

        var generoExcluido = _unitOfWork.GeneroRepository.DeleteGenero(id);

        await _unitOfWork.CommitAsync();

        return Ok(generoExcluido);
    }
}
