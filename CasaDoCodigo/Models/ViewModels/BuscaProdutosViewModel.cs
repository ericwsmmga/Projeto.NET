using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaProdutosViewModel
    {
        public IList<Produto> Produtos;
        public String pesquisa;

        public BuscaProdutosViewModel(IList<Produto> produtos, string pesquisa)
        {
            this.Produtos = produtos;
            this.pesquisa = pesquisa;
        }
    }
}
