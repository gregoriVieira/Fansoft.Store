using System;
using System.Collections.Generic;
using System.Linq;
using Fansoft.Store.Domain.Entities;
using Fansoft.Store.Domain.Enums;

namespace Fansoft.Store.Api.Models.PedidosCtrlVM
{
    public class Get
    {
        public Guid Id { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<Itens> Itens { get; set; }
        public string Status { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Itens 
    {
        public Guid Id { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public decimal ValorUnitario { get; set; }
        public float Qtde { get; set; }
    }


    public static class ModelExtensions
    {
        public static Get ToVM(this Pedido data)
        {
            return new Get
            {
                Id = data.Id,
                Cliente = new Cliente { Id = data.ClienteId, Nome = data.Cliente.Nome},
                Itens = data.PedidoItens.Select(i => new Itens{ Id = i.Id, ProdutoId = i.ProdutoId, ProdutoNome = i.Produto.Nome, ValorUnitario = i.PrecoUnitario, Qtde = i.Quantidade}),
                Status = Enum.GetName(typeof(StatusPedido), data.Status)
            };
        }
    }

}