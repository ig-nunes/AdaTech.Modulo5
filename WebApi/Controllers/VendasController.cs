using DadosSistema.Models;
using DadosSistema.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.RequestModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : Controller
    {
        private readonly IVendaRepositorio _vendaRepositorio;

        public VendasController(IVendaRepositorio vendaRepositorio)
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
            foreach (var itemRequest in vendaRequest.ItemVendaRequests)
            {
                if (itemRequest.ProdutoRequest == null)
                {
                    return BadRequest("Requisição inválida");
                }

                var produto = new Produto(itemRequest.ProdutoRequest.Nome, itemRequest.ProdutoRequest.Preco);
                var itemVenda = new ItemVenda(produto, itemRequest.Quantidade);
                itensVenda.Add(itemVenda);
            }

            var venda = new Venda(vendaRequest.Cliente, itensVenda);

            _vendaRepositorio.Add(venda);

            return Ok(venda);
        }
    }
}
