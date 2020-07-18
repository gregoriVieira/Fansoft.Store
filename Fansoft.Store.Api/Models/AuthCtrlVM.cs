using System.ComponentModel.DataAnnotations;

namespace Fansoft.Store.Api.Models.AuthCtrlVM
{
    public class PostCommand
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [EmailAddress(ErrorMessage = "email inválido")]
        public string Email { get; set; }
        

        [Required(ErrorMessage = "campo obrigatório")]
        public string Senha { get; set; }
    }
}