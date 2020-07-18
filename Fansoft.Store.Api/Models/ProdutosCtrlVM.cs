using System;
using System.ComponentModel.DataAnnotations;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Api.Models.ProdutosCtrl
{
    public class PostCommand
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "limite de 50 caracteres excedido")]
        public string Nome { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal PrecoUnitario { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Valor inválido")]
        public int CategoriaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Valor inválido")]
        public float QtdeEmEstoque { get; set; }

    }
    public class PutCommand 
    {

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "limite de 50 caracteres excedido")]
        public string Nome { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal PrecoUnitario { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Valor inválido")]
        public int CategoriaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Valor inválido")]
        public float QtdeEmEstoque { get; set; }
    }


    public class GetAll
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public float QtdeEmEstoque { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }



    public static class ModelExtensions
    {
        public static GetAll ToVM(this Produto data)
        {
            return new GetAll
            {
                Id = data.Id,
                Nome = data.Nome,
                Categoria = data.Categoria?.Nome,
                QtdeEmEstoque = data.QtdeEmEstoque,
                DataAlteracao = data.DataAlteracao,
                DataCriacao = data.DataCriacao
            };
        }

        public static Produto ToData(this PostCommand vm)
        {
            return new Produto
            {
                Nome = vm.Nome,
                CategoriaId = vm.CategoriaId,
                PrecoUnitario = vm.PrecoUnitario
            };
        }


    }


}