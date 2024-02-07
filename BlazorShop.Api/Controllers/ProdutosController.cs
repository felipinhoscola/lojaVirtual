using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;


[ApiController]//Permite acesso a recursos para trarar requests e posts http
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItens()
    {
        try
        {
            var produtos = await _produtoRepository.GetItens();
            if (produtos is null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao receber dados do banco de dados ");


            var produtosDtos = produtos.ConverterProdutosParaDto();
            return Ok(produtosDtos);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao receber dados do banco de dados ");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProdutoDto>> GetItem(int id)
    {
        try
        {
            var produto = await _produtoRepository.GetItem(id);
            if (produto is null)
                return NotFound("Produto não localizado");


            var produtoDto = produto.ConverterProdutoParaDto();
            return Ok(produtoDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao receber dados do banco de dados ");
        }
    }

    [HttpGet]
    [Route("GetItensPorCategoria/{categoriaId}")]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
    {
        try
        {
            var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);
            if (produtos is null)
                return NotFound("Erro ao acessar a categoria");

            var produtosDto = produtos.ConverterProdutosParaDto();
            return Ok(produtosDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Erro ao receber dados do banco de dados ");
        }
    }

    [HttpGet]
    [Route("GetCategorias")]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategorias()
    {
        try
        {
            var categorias = await _produtoRepository.GetCategorias();
            if (categorias is null) return NotFound("Lista de Categorias não encontrada");

            var categoriasDto = categorias.ConverterCategoriasParaDto();
            return Ok(categoriasDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Erro ao receber dados do banco de dados ");
        }
    }
}
