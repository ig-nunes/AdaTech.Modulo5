using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("imoveis")]
    public class ImoveisController : Controller
    {
        private static List<Imovel> _imoveis;

        public ImoveisController()
        {
            if (_imoveis == null)
            {
                _imoveis = new List<Imovel>();
            }
        }

        /// <summary>
        /// Pesquisar todos os imóveis cadastrados.
        /// </summary>
        /// <returns>Todos os imóveis cadastrados</returns>
        [HttpGet("", Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(bool testeErroMiddleware)
        {
            if (testeErroMiddleware)
            {
                throw new Exception("Você escolheu dar erro.");
            }
            return Ok(_imoveis);
        }


        /// <summary>
        /// Pesquisar imóvel por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O imóvel pesquisado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetImovelId([FromRoute] string id)
        {
            var imovel = _imoveis.FirstOrDefault(x => x.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }
            return Ok(imovel);
        }

        /// <summary>
        /// Criar imóvel.
        /// </summary>
        /// <param name="imovelRequest"></param>
        /// <returns>O imóvel criado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CreateImovel imovelRequest)
        {
            if (imovelRequest == null || imovelRequest.Endereco == null || imovelRequest.Proprietario == null)
            {
                return BadRequest();
            }
            Imovel imovel = new Imovel()
            {
                Id = Guid.NewGuid().ToString(),
                Endereco = imovelRequest.Endereco,
                Proprietario = imovelRequest.Proprietario
            };
            _imoveis.Add(imovel);
            return Ok(imovel);
        }


        /// <summary>
        /// Editar um imóvel por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imovelAtualizado"></param>
        /// <returns>O imóvel editado</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(string id, [FromBody] CreateImovel imovelAtualizado)
        {
            var imovel = _imoveis.FirstOrDefault(i => i.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }
            if (imovelAtualizado == null || string.IsNullOrEmpty(imovelAtualizado.Endereco) && string.IsNullOrEmpty(imovelAtualizado.Proprietario))
            {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(imovelAtualizado.Endereco))
            {
                imovel.Endereco = imovelAtualizado.Endereco;
            }
            if (!string.IsNullOrEmpty(imovelAtualizado.Proprietario))
            {
                imovel.Proprietario = imovelAtualizado.Proprietario;
            }

            return Ok(imovel);
        }


        /// <summary>
        /// Deletar um imóvel por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O imóvel deletado</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] string id)
        {
            var imovel = _imoveis.FirstOrDefault(i => i.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }
            _imoveis.Remove(imovel);
            return Ok(imovel);
        }

    }
}
