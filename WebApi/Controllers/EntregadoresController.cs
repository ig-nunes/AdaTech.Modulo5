using Dados;
using Dados.CustomExceptions;
using Dados.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.RequestModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntregadoresController : Controller
    {
        private readonly IEntregadorRepositorio<Entregador> _entregadorRepositorio;

        public EntregadoresController(IEntregadorRepositorio<Entregador> entregadorRepositorio)
        {
            _entregadorRepositorio = entregadorRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Get(bool error)
        {
            if (error)
            {
                throw new ApiException("Você escolheu dar erro. 'I'm a teapot'", 418);
            }
            var entregador = _entregadorRepositorio.Get();
            if (entregador == null)
            {
                return NotFound();
            }

            return Ok(entregador);
        }

        [HttpGet("{cpf}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetByCpf(string cpf, bool error)
        {
            if (error)
            {
                throw new ApiException("Você escolheu dar erro. 'I'm a teapot'", 418);
            }
            var entregador = _entregadorRepositorio.GetByCpf(cpf);
            if (entregador == null)
            {
                return NotFound();
            }                

            return Ok(entregador);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [TypeFilter(typeof(FiltroAutorizacao))]
        public IActionResult Post([FromBody] EntregadorRequest entregadorRequest)
        {
            var entregador = new Entregador
            {
                Cpf = entregadorRequest.Cpf,
                DataNascimento = entregadorRequest.DataNascimento,
                Nome = entregadorRequest.Nome,
            };
            _entregadorRepositorio.Add(entregador);
            return Ok(entregador);
        }

    }
}
