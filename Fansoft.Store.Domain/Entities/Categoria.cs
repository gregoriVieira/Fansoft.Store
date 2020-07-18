using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fansoft.Store.Domain.Entities
{
    public class Categoria : Entity
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }

        public void Atualizar(string nome)
        {
            Nome = nome;
            DataAlteracao = DateTime.Now;
        }
    }
}