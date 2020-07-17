using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Categoria : BaseModel
    {
    
        public Categoria(string nome)
        {
            this.Nome = nome;
        }
        public Categoria()
        {

        }
        [Required]
        public String Nome { get; set; }


    }

}
