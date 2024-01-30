using BlazorShop.Models.DTOs;
using BlazorShop.Web.Services;

namespace BlazorShop.Api.Controllers
{
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
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>("api/produtos");

                return produtosDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos : api/produtos");
                throw;
            }

        }
    }
}
