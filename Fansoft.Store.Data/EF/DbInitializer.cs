using System;
using Fansoft.Store.Domain.Entities;
using Fansoft.Store.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Fansoft.Store.Data.EF
{
    public static class DbInitializer
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Alimento" },
                new Categoria { Id = 2, Nome = "Vestuário" },
                new Categoria { Id = 3, Nome = "Higiene" },
                new Categoria { Id = 4, Nome = "Papelaria" }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto() { Id = 1, Nome = "Picanha", CategoriaId = 1, PrecoUnitario = 90.99M, QtdeEmEstoque = 100.80f },
                new Produto() { Id = 2, Nome = "Danone", CategoriaId = 1, PrecoUnitario = 8.7M, QtdeEmEstoque = 120 },
                new Produto() { Id = 3, Nome = "Camisa c/ manga", CategoriaId = 2, PrecoUnitario = 80.1M, QtdeEmEstoque = 5 },
                new Produto() { Id = 4, Nome = "Fralda Pampers", CategoriaId = 3, PrecoUnitario = 50.33M, QtdeEmEstoque = 220 },
                new Produto() { Id = 5, Nome = "Pasta de Dente", CategoriaId = 3, PrecoUnitario = 8.99M, QtdeEmEstoque = 1500 },
                new Produto() { Id = 6, Nome = "DVD Regravável", CategoriaId = 4, PrecoUnitario = 5.99M, QtdeEmEstoque = 2150 }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente {Id = 1, Nome = "Cliente 1"},
                new Cliente {Id = 2, Nome = "Cliente 2"},
                new Cliente {Id = 3, Nome = "Cliente 3"}
            );

            var pedidoId1 = Guid.NewGuid();
            var pedidoId2 = Guid.NewGuid();
            var pedidoId3 = Guid.NewGuid();
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido {Id = pedidoId1, ClienteId = 1 , DadosPagto = "XPTO"},
                new Pedido {Id = pedidoId2, ClienteId = 2 , DadosPagto = "XYZ"},
                new Pedido {Id = pedidoId3, ClienteId = 3 , DadosPagto = "ABCD"}
            );

            modelBuilder.Entity<PedidoItens>().HasData(
                new PedidoItens {Id = Guid.NewGuid(), PedidoId = pedidoId1, ProdutoId = 1, PrecoUnitario = 80, Quantidade = 1 },
                new PedidoItens {Id = Guid.NewGuid(), PedidoId = pedidoId1, ProdutoId = 2, PrecoUnitario = 10, Quantidade = 3 },
                new PedidoItens {Id = Guid.NewGuid(), PedidoId = pedidoId2, ProdutoId = 3, PrecoUnitario = 80, Quantidade = 2 },
                new PedidoItens {Id = Guid.NewGuid(), PedidoId = pedidoId2, ProdutoId = 4, PrecoUnitario = 40.99M, Quantidade = 1 },
                new PedidoItens {Id = Guid.NewGuid(), PedidoId = pedidoId3, ProdutoId = 5, PrecoUnitario = 5.99M, Quantidade = 10 },
                new PedidoItens {Id = Guid.NewGuid(), PedidoId = pedidoId3, ProdutoId = 6, PrecoUnitario = 3.99M, Quantidade = 12 }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario{ Id = 1, Nome = "Usuario 1", Email = "user@user.com", Senha = "123456".Encrypt()},
                new Usuario{ Id = 2, Nome = "Usuario 2", Email = "user2@user.com", Senha = "654321".Encrypt()}
            );



        }

    }
}