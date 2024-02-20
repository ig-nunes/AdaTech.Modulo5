using DadosSistema.Models;
using DadosSistema.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.RequestModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevolucaoController : ControllerBase
    {
        private readonly IRepositorio<Devolucao> _devolucaoRepositorio;
        private readonly IRepositorio<Venda> _vendaRepositorio;

        public DevolucaoController(IRepositorio<Devolucao> devolucaoRepositorio)
        {
            _devolucaoRepositorio = devolucaoRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetDevolucao()
        {
            var devolucao = _devolucaoRepositorio.Get();
            return Ok(devolucao);
        }

        [HttpGet("buscar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetDevolucaoQuery([FromQuery] int id) 
        {
            var devolucao = _devolucaoRepositorio.GetById(id);
            if (devolucao == null)
            {
                return BadRequest("Devolucao não encontrada");
            }

            return Ok(devolucao);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetDevolucaoRoute([FromRoute] int id)
        {
            var devolucao = _devolucaoRepositorio.GetById(id);
            if (devolucao == null)
            {
                return BadRequest("Devolucao não encontrada");
            }

            return Ok(devolucao);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult PostDevolucao(DevolucaoRequest devolucaoRequest)
        {
            var venda = _vendaRepositorio.GetById(devolucaoRequest.VendaId);
            if (venda == null)
            {
                return BadRequest("Venda não encontrada");
            }
            var item = _vendaRepositorio.GetById(devolucaoRequest.ItemId);
            if (item == null)
            {
                return BadRequest("Item de venda não encontrada");
            }

            var devolucao = new Devolucao(devolucaoRequest.VendaId, devolucaoRequest.ItemId, DateTime.Now);

            _devolucaoRepositorio.Add(devolucao);

            return Ok(devolucao);
        }
    }
}
