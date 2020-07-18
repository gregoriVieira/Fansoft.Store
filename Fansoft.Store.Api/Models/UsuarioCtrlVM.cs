using System;
using Fansoft.Store.Domain.Entities;

namespace Fansoft.Store.Api.Models.UsuarioCtrlVM
{
    public class GetAll
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }

    public static class ModelExtensions
    {
        public static GetAll ToVM(this Usuario data)
        {
            return new GetAll {
                Id = data.Id, Nome = data.Nome, Email = data.Email, 
                DataCriacao = data.DataCriacao, DataAlteracao = data.DataAlteracao
            };
        }
    }
}