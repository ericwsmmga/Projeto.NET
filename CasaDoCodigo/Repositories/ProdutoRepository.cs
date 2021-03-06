﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ICategoriaRepository categoriaRepository;
        public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public async Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa)
        {
            IQueryable<Produto> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.Nome.Contains(pesquisa));
            }

            query = query
                .Include(prod => prod.Categoria);

            return new BuscaProdutosViewModel(await query.ToListAsync(), pesquisa);
        }

        

        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
              

                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    var categoria = await categoriaRepository.AddCategoria(livro.Categoria);  
                        dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria));                       
                   
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Src { get; set; }
        public decimal Preco { get; set; }
    }
}
