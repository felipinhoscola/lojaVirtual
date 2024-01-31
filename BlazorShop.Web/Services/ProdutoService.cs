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

    public async Task<ProdutoDto> GetProdutoById(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/produtos/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return default(ProdutoDto);

                return await response.Content.ReadFromJsonAsync<ProdutoDto>();
            }

            var message = await response.Content.ReadAsStringAsync();
            _logger.LogError($"Erro ao obter produto pelo id={id} - {message}");
            throw new Exception($"Status Code: {response.StatusCode} - {message}");
        }
        catch (Exception)
        {
            _logger.LogError($"Erro ao obter produto pelo id={id}");
            throw;
        }
    }
}
