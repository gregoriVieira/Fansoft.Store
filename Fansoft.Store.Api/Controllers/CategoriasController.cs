using System.Threading.Tasks;
using Fansoft.Store.Data.EF;
using Fansoft.Store.Data.EF.Repositories;
using Fansoft.Store.Domain.Contracts.Repositories;
using Fansoft.Store.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fansoft.Store.Api.Models.CategoriasCtrlVM;
using System.Linq;
using Fansoft.Store.Domain.Contracts.Infra;

namespace Fansoft.Store.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository _catRepository;
        private readonly IUnitOfWork _uow;

        public CategoriasController(ICategoriaRepository catRepository, IUnitOfWork uow)
        {
            _catRepository = catRepository;
            _uow = uow;
        }
        
        [HttpGet]
        [Produces("application/json","application/xml")]
        public async Task<IActionResult> GetAll()
        {
                var data = await _catRepository.GetAsync();
                var vm = data.Select(c => c.ToVM());

                return Ok(vm.ToList());
        }

        [HttpGet("{id}", Name="GetCategoriaById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _catRepository.GetAsync(id);
            if (data == null) return NotFound();
            return Ok(data.ToVM());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]PostCommand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var data = model.ToData();

            _catRepository.Add(data);
            await _uow.CommitAsync();

            return CreatedAtRoute("GetCategoriaById", new {data.Id}, data.ToVM());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PutCommand model)
        {
            var categoria = await _catRepository.GetAsync(id);
            if (categoria == null) ModelState.AddModelError("Id","Categoria não encontrada");
            
            if (!ModelState.IsValid) return BadRequest(ModelState);

            categoria.Atualizar(model.Nome);

            _catRepository.Update(categoria);
            await _uow.CommitAsync();

            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _catRepository.GetAsync(id);

            if (data == null)
                return BadRequest("Essa categoria não existe");
            
            _catRepository.Delete(data);
            await _uow.CommitAsync();

            return NoContent();
        }



    }
}