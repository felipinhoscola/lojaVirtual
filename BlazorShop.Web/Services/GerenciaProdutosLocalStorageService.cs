using Blazored.LocalStorage;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services
{
    public class GerenciaProdutosLocalStorageService : IGerenciaProdutosLocalStorageService
    {
        private const string key = "ProdutoCollection";

        private readonly ILocalStorageService _localStorage;
        private readonly IProdutoService _produtoService;

        public GerenciaProdutosLocalStorageService(ILocalStorageService localStorage, IProdutoService produtoService)
        {
            _localStorage = localStorage;
            _produtoService = produtoService;
        }

        public async Task<IEnumerable<ProdutoDto>> GetCollection()
        {
            return await this._localStorage.GetItemAsync<IEnumerable<ProdutoDto>>(key) ?? await AddCollection(); ;
        }

        public async Task RemoveCollection()
        {
            await this._localStorage.RemoveItemAsync(key);
        }

        private async Task<IEnumerable<ProdutoDto>> AddCollection()
        {
            var produtoCollection = await this._produtoService.GetItens();
            if (produtoCollection != null)
                await this._localStorage.SetItemAsync(key, produtoCollection);

            return produtoCollection;
        }
    }
}
