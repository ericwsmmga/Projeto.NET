using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    public class Produto : BaseModel
    {
        public Produto()
        {

        }

        [Required]
        [DataMember]
        public Categoria Categoria { get;  private set; }
        [Required]
        public string Codigo { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public decimal Preco { get; private set; }
        
        public Produto( string codigo, string nome, decimal preco)
        {
         
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;   
        }
        public Produto(string codigo, string nome, decimal preco, Categoria categoria)
        {

            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
            this.Categoria = categoria;
        }


    }
}
