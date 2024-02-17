using Dados;
using Dados.CustomExceptions;
using Dados.Models;

namespace Dados
{
    public class EntregadorRepositorioInMemory : IEntregadorRepositorio<Entregador>
    {
        private List<Entregador> _entregadores = new List<Entregador>() 
        { 
            new Entregador
            {
                Cpf = "111.111.111-11",
                Nome = "Braga",
                DataNascimento = new DateTime(1996, 2, 15)
            } 
        };

        public Entregador Add(Entregador entregador)
        {
            if (_entregadores.Count > 10)
            {
                throw new Exception("Banco está cheio");
            }
            _entregadores.Add(entregador);
            return entregador;
        }

        public List<Entregador> Get()
        {

            return _entregadores; 
        }

        public Entregador GetByCpf(string cpf)
        {        
            var entregadores = _entregadores.FirstOrDefault(x => x.Cpf == cpf);

            if (entregadores is null)
            {
                throw new ApiException($"Não foi encontrado Entregador com este Cpf: {cpf}", 404);
            }

            return entregadores;
        }
    }
}
