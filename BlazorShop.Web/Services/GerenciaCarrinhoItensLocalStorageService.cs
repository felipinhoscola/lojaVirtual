using Blazored.LocalStorage;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public class GerenciaCarrinhoItensLocalStorageService : IGerenciaCarrinhoItensLocalStorageService
    {
        const string key = "CarrinhoItemCollection";

        private readonly ILocalStorageService _localStorageService;
        private readonly ICarrinhoCompraService _carrinhoCompraService;

        public GerenciaCarrinhoItensLocalStorageService(ILocalStorageService localStorageService, ICarrinhoCompraService carrinhoCompraService)
        {
            _localStorageService = localStorageService;
            _carrinhoCompraService = carrinhoCompraService;
        }

        public async Task<List<CarrinhoItemDto>> GetCollection()
        {
            return await this._localStorageService.GetItemAsync<List<CarrinhoItemDto>>(key) ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await this._localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<CarrinhoItemDto> carrinhoItensDto)
        {
            await this._localStorageService.SetItemAsync(key, carrinhoItensDto);
        }

        private async Task<List<CarrinhoItemDto>> AddCollection()
        {
            var carrinhoCompraCollection = await this._carrinhoCompraService.GetItens(UsuarioLogado.UsuarioId);
            if (carrinhoCompraCollection != null)
                await this._localStorageService.SetItemAsync(key, carrinhoCompraCollection);

            return carrinhoCompraCollection;
        }
    }
}
