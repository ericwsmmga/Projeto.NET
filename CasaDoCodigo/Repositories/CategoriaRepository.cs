
using CasaDoCodigo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


namespace CasaDoCodigo.Repositories
{


    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Categoria> GetCategorias()
        {
            return dbSet.ToList();
        }
        public async Task<Categoria> AddCategoria(string nome)
        {
            var categoria = dbSet.Where(c => c.Nome == nome).SingleOrDefault();
            if (categoria == null)
            {
                var novaCategoria = new Categoria(nome);

                categoria = dbSet.Add(novaCategoria).Entity;

            }
            await contexto.SaveChangesAsync();
            return categoria;
        }

    }
}
