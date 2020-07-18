using System;
using System.Linq;
using System.Threading.Tasks;
using Fansoft.Store.Api.Models.PedidosCtrlVM;
using Fansoft.Store.Domain.Contracts.Infra;
using Fansoft.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.Api.Controllers
{
    
    [Route("api/v1/[controller]")]
    public class PedidosController: ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _uow;

        public PedidosController(IPedidoRepository pedidoRepository, IUnitOfWork uow)
        {
            _pedidoRepository = pedidoRepository;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data =
                await _pedidoRepository.GetPedidoWithClientesAndItensAsync();

            var vm = data.Select(d => d.ToVM());

            return Ok(vm);
        }

        [HttpGet("{id}", Name = "GetPedidoById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await _pedidoRepository.GetPedidoByIdWithClientesAndItensAsync(id);
            return Ok(data.ToVM());
        }

    }
}