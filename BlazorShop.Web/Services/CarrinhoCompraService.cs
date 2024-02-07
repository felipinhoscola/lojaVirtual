using BlazorShop.Models.DTOs;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorShop.Web.Services
{
    public class CarrinhoCompraService : ICarrinhoCompraService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoCompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public event Action<int> OncarrinhoCompraChanged;

        public async Task<CarrinhoItemDto> AdicionaItem(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<CarrinhoItemAdicionaDto>("api/CarrinhoCompra", carrinhoItemAdicionaDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return default(CarrinhoItemDto);

                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"{response.StatusCode} Message -{message}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CarrinhoItemDto> AtualizaQuantidade(CarrinhoItemAtualizaQuantidadeDto carrinhoItemAtualizaQuantidadeDto)
        {
            try
            {
                var jsonRequest = JsonSerializer.Serialize(carrinhoItemAtualizaQuantidadeDto);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await _httpClient.PatchAsync($"api/CarrinhoCompra/{carrinhoItemAtualizaQuantidadeDto.CarrinhoItemId}", content);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CarrinhoItemDto> DeletaItem(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/CarrinhoCompra/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                return default(CarrinhoItemDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CarrinhoItemDto>> GetItens(int usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/CarrinhoCompra/{usuarioId}/GetItens");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return Enumerable.Empty<CarrinhoItemDto>().ToList();

                    return await response.Content.ReadFromJsonAsync<List<CarrinhoItemDto>>();
                }

                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RaiseEventOnCarrinhoCompraChanged(int totalQuantidade)
        {
            if (OncarrinhoCompraChanged != null)
            {
                OncarrinhoCompraChanged.Invoke(totalQuantidade);
            }
        }
    }
}
