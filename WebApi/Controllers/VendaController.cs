using DadosSistema.Models;
using DadosSistema.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.RequestModels;
using WebApi.ResponseModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : Controller
    {
        private readonly IRepositorio<Venda> _vendaRepositorio;

        public VendaController(IRepositorio<Venda> vendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            var venda = _vendaRepositorio.Get();
            return Ok(venda);
        }

        [HttpGet("buscar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetQuery([FromQuery] int id)
        {
            var venda = _vendaRepositorio.GetById(id);
            if (venda == null)
            {
                return NotFound(new ErroResponse
                {
                    Titulo = "Erro ao procurar venda",
                    Detalhes = "Venda não encontrada",
                    StatusCode = 404,
                });
            }
            return Ok(venda);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetRoute([FromRoute] int id)
        {
            var venda = _vendaRepositorio.GetById(id);
            if (venda == null)
            {
                return NotFound( new ErroResponse 
                {
                    Titulo = "Erro ao procurar venda",
                    Detalhes = "Venda não encontrada",
                    StatusCode = 404,
                });
            }
            return Ok(venda);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] VendaRequest vendaRequest)
        {
            if (vendaRequest == null || vendaRequest.ItemVendaRequests == null || string.IsNullOrWhiteSpace(vendaRequest.Cliente))
            {
                return BadRequest("Requisição inválida");
            }

            var itensVenda = new List<ItemVenda>();
            int itemVendaId = 1;
            foreach (var itemRequest in vendaRequest.ItemVendaRequests)
            {
                if (itemRequest.ProdutoRequest == null)
                {
                    return BadRequest("Requisição inválida");
                }

                var produto = new Produto(itemRequest.ProdutoRequest.Nome, itemRequest.ProdutoRequest.Preco);
                var itemVenda = new ItemVenda(itemVendaId, produto, itemRequest.Quantidade);
                itensVenda.Add(itemVenda);

                itemVendaId++;
            }

            var venda = new Venda(vendaRequest.Cliente, itensVenda);

            _vendaRepositorio.Add(venda);

            return Ok(venda);
        }
    }
}
