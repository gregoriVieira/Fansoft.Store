using System.Linq;
using System.Threading.Tasks;
using Fansoft.Store.Api.Models.UsuarioCtrlVM;
using Fansoft.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class UsuariosController: ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _usuarioRepository.GetAsync();
            var vm = data.Select(u => u.ToVM());
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _usuarioRepository.GetAsync(id);
            var vm = data.ToVM();
            return Ok(vm);
        }
        
    }
}