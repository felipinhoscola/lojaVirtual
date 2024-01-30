using BlazorShop.Models.DTOs;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services;

public class ProdutoService : IProdutoService
{
    public HttpClient _httpClient;
    public ILogger<ProdutoService> _logger;

    public ProdutoService(ILogger<ProdutoService> logger, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<ProdutoDto>> GetItens()
    {
        try
        {
            var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("/api/produtos");

            return produtosDto;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"Erro ao acessar produtos: {ex.Message}, Status: {ex.StatusCode}");
            throw;
        }

    }
}
