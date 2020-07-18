using System.Linq;
using System.Threading.Tasks;
using Fansoft.Store.Api.Models.ClientesCtrlVM;
using Fansoft.Store.Domain.Contracts.Infra;
using Fansoft.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRep;
        private readonly IUnitOfWork _uow;

        public ClientesController(IClienteRepository clienteRep, IUnitOfWork uow)
        {
            _clienteRep = clienteRep;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data =
                await _clienteRep.GetAllWithPedidosAsync();

            var vm = data.Select(d => d.ToVM());

            return Ok(vm);
        }

        [HttpGet("{id}", Name = "GetClienteById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _clienteRep.GetByIdWithPedidosAsync(id);
            return Ok(data.ToVM());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]PostCommand model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = model.ToData();
            _clienteRep.Add(data);

            await _uow.CommitAsync();

            return CreatedAtRoute("GetClienteById", new { data.Id }, data);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]PutCommand model)
        {
           var cliente = await _clienteRep.GetAsync(id);
            if (cliente == null) ModelState.AddModelError("Id","Cliente não encontrada");
            
            if (!ModelState.IsValid) return BadRequest(ModelState);

            cliente.Atualizar(model.Nome);

            _clienteRep.Update(cliente);
            await _uow.CommitAsync();

            
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _clienteRep.GetAsync(id);

            if (data == null)
                return BadRequest("Esse cliente não existe");
            
            _clienteRep.Delete(data);
            await _uow.CommitAsync();

            return NoContent();
        }



    }
}