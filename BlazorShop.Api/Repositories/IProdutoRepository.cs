using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories;

public interface IProdutoRepository
{
    //busca todos itens do carrinho
    Task<IEnumerable<Produto>> GetItens();
    //busca item através do id
    Task<Produto> GetItem(int id);
    //busca todos itens da categoria através do id da categoria
    Task<IEnumerable<Produto>> GetItensPorCategoria(int id);
}
