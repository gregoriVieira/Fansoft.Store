using System;
using System.Collections.Generic;

namespace Fansoft.Store.Domain.Entities
{
    public class Cliente: Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Pedido> Pedidos { get; set; }

        public void Atualizar(string nome)
        {
            Nome = nome;
            DataAlteracao = DateTime.Now;
        }
    }
}