using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Api.Models.ClientesCtrlVM
{
    public class Get
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int QtdePedidos { get; set; }
    }


    public class PostCommand
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "limite de 50 caracteres excedido")]
        public string Nome { get; set; }
    }

    public class PutCommand
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "limite de 50 caracteres excedido")]
        public string Nome { get; set; }
    }


    public static class ModelExtensions
    {
        public static Cliente ToData(this PostCommand vm)
        {
            return new Cliente{ Nome = vm.Nome };
        }

        public static Cliente ToData(this PutCommand vm)
        {
            return new Cliente{ Nome = vm.Nome };
        }

        public static Get ToVM(this Cliente data)
        {
            return new Get
            {
                Id = data.Id,
                Nome = data.Nome,
                DataCriacao = data.DataCriacao,
                DataAlteracao = data.DataAlteracao,
                QtdePedidos = data.Pedidos != null ? data.Pedidos.Count() : 0
            };
        }
    }


}