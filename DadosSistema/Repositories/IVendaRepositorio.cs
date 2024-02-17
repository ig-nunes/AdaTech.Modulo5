using DadosSistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema.Repositories
{
    public interface IVendaRepositorio
    {
        public Venda Add(Venda venda);
        public List<Venda> Get();
        public Venda? GetById(int id);

    }
}
