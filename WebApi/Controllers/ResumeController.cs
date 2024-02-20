using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly IContentTypeProvider _contentTypeProvider;

        public ResumeController(IContentTypeProvider contentTypeProvider)
        {
            _contentTypeProvider = contentTypeProvider;
        }

        [HttpGet]
        public IActionResult GetResume(string nomeArquivo)
        {
            var caminhoArquivo = $"wwwroot/{nomeArquivo}";

            if (!System.IO.File.Exists(caminhoArquivo))
            {
                return BadRequest(new
                {
                    Titulo = "Erro ao fazer o download do arquivo",
                    Detalhes = $"Arquivo não existe: {nomeArquivo}",
                    StatusCode = 400,
                });
            }

            var fileInBytes = System.IO.File.ReadAllBytes(caminhoArquivo);

            var contentType = "application/octet-stream";
            if (_contentTypeProvider.TryGetContentType(caminhoArquivo, out var contentTypeProvided))
            {
                contentType = contentTypeProvided;
            }

            return File(fileInBytes, contentType);

        }

        [HttpPost]
        public async Task<IActionResult> PostResume(IFormFile file)
        {
            var caminhoArquivo = $"wwwroot/{file.FileName}";

            string[] extensoesPermitidas = [".pdf", ".doc", ".docx"];

            var ExtensaoArquivo = Path.GetExtension(caminhoArquivo);


            if (ValidateFile(file) != null)
            {
                return ValidateFile(file)!;
            }

            using (var fileStream = System.IO.File.Create(caminhoArquivo))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok(new { FileName = file.FileName });
        }

        private IActionResult? ValidateFile(IFormFile file)
        {
            var caminhoArquivo = $"wwwroot/{file.FileName}";

            string[] extensoesPermitidas = [".pdf", ".doc", ".docx"];

            var ExtensaoArquivo = Path.GetExtension(caminhoArquivo);

            if (file.Length > 5 * 1024 * 1024)
            {
                return BadRequest(new
                {
                    Titulo = "Erro ao fazer o upload",
                    Detalhes = "Tamanho excede o limite permitido",
                    StatusCode = 400,
                });
            }
            if (!extensoesPermitidas.Contains(ExtensaoArquivo))
            {
                return BadRequest(new
                {
                    Titulo = "Erro ao fazer upload",
                    Detalhes = "Extensão não permitida",
                    StatusCode = 400,
                });
            }

            return null;
        }
    }
}
