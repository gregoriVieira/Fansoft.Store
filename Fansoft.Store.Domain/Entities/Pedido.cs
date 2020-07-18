using System;
using System.Collections.Generic;
using Fansoft.Store.Domain.Enums;

namespace Fansoft.Store.Domain.Entities
{
    public class Pedido : Entity
    {
        public Guid Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string DadosPagto { get; set; }
        public StatusPedido Status { get; set; } = StatusPedido.EmProcessamento;

        public IEnumerable<PedidoItens> PedidoItens { get; set; }

    }
}