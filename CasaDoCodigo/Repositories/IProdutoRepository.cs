using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        Task SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
        Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa);
    }
}