using System;

namespace Fansoft.Store.Domain.Entities
{
    public class PedidoItens: Entity
    {
        public Guid Id { get; set; }

        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public decimal PrecoUnitario { get; set; }
        public float Quantidade { get; set; }
    }
}