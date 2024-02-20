using DadosSistema.Models;
using DadosSistema.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.RequestModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrocaController : Controller
    {
        private readonly IRepositorio<Troca> _trocaRepositorio;
        private readonly IRepositorio<Venda> _vendaRepositorio;

        public TrocaController(IRepositorio<Troca> trocaRepositorio, IRepositorio<Venda> vendaRepositorio)
        {
            _trocaRepositorio = trocaRepositorio;
            _vendaRepositorio = vendaRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetTroca()
        {
            var trocas = _trocaRepositorio.Get();
            return Ok(trocas);
        }

        [HttpGet("buscar")]
        [ProducesResponseType(200)]
        public IActionResult GetTrocaQuery([FromQuery] int id)
        {
            var troca = _trocaRepositorio.GetById(id);
            if (troca == null)
            {
                return NotFound();
            }

            return Ok(troca);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetTrocaRoute([FromRoute] int id)
        {
            var troca = _trocaRepositorio.GetById(id);
            if (troca == null)
            {
                return NotFound();
            }

            return Ok(troca);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult PostTroca(TrocaRequest trocaRequest)
        {
            if (trocaRequest == null || trocaRequest.VendaId <= 0 || trocaRequest.ItemVendaId <= 0 || trocaRequest.ProdutoNovo == null)
            {
                return BadRequest("Requisição inválida");
            }

            var venda = _vendaRepositorio.GetById(trocaRequest.VendaId);
            if (venda == null)
            {
                return BadRequest("Venda não existe");
            }

            var itemVenda = venda.Itens.FirstOrDefault(itemVenda => itemVenda.Id == trocaRequest.ItemVendaId);
            if (itemVenda == null)
            {
                return BadRequest("Item de venda Não existe");
            }

            var troca = new Troca(trocaRequest.VendaId, trocaRequest.ItemVendaId, trocaRequest.ProdutoNovo);
            _trocaRepositorio.Add(troca);

            return Ok(troca);
        }
    }
}
