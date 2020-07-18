using System.Linq;
using System.Threading.Tasks;
using Fansoft.Store.Api.Models.ProdutosCtrl;
using Fansoft.Store.Data.EF.Repositories;
using Fansoft.Store.Domain.Contracts.Infra;
using Fansoft.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.Api.Controllers
{
    [Route("api/v1/produtos")]
    public class ProdutosController : ControllerBase
    {

        private IProdutoRepository _prodRepository;
        private readonly IUnitOfWork _uow;

        public ProdutosController(IProdutoRepository prodRepository, IUnitOfWork uow)
        {
            _prodRepository = prodRepository;
            _uow = uow;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _prodRepository.GetAllWithCategoriaAsync();
            var vm = data.Select(p => p.ToVM());
            return Ok(vm);
        }

        [HttpGet("{id}", Name = "GetProdutoById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _prodRepository.GetByIdWithCategoriaAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data.ToVM());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]PostCommand model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var data = model.ToData();
            _prodRepository.Add(data);
            await _uow.CommitAsync();
            
            return CreatedAtRoute("GetProdutoById", new { data.Id }, data);
        }

        [HttpPut("{id}")]
        public  async Task<IActionResult> Update(int id, [FromBody]PutCommand model)
        {
            var produto = await _prodRepository.GetAsync(id);
            if (produto == null) ModelState.AddModelError("Id","Produto não encontrado");
            
            if (!ModelState.IsValid) return BadRequest(ModelState);

            produto.Atualizar(model.Nome, model.PrecoUnitario, model.CategoriaId, model.QtdeEmEstoque);
            
            _prodRepository.Update(produto);
            await _uow.CommitAsync();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _prodRepository.GetAsync(id);

            if (data == null)
                return BadRequest("Esse produto não existe");
            
            _prodRepository.Delete(data);
            await _uow.CommitAsync();

            return NoContent();
        }


    }

}