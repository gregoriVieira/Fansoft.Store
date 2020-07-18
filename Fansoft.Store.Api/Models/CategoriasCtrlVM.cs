using System;
using System.ComponentModel.DataAnnotations;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Api.Models.CategoriasCtrlVM
{
    public class GetAll
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
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

        public static GetAll ToVM(this Categoria data)
        {
            return new GetAll
            {
                Id = data.Id,
                Nome = data.Nome,
                DataAlteracao = data.DataAlteracao,
                DataCriacao = data.DataCriacao
            };
        }

        public static Categoria ToData(this PostCommand vm)
        {
            return new Categoria { Nome = vm.Nome };
        }


    }

}