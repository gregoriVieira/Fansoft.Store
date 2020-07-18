using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fansoft.Store.Domain.Entities
{
    
    public class Produto: Entity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public float QtdeEmEstoque { get; set; }

        public IEnumerable<PedidoItens> PedidoItens { get; set; }        

        public void Atualizar(string nome, decimal precoUnitario, int categoriaId, float qtde)
        {
            Nome = nome;
            PrecoUnitario = precoUnitario;
            CategoriaId = categoriaId;
            QtdeEmEstoque = qtde;
            DataAlteracao = DateTime.Now;
        }
    }
}