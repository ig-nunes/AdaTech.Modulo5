using DadosSistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema.Repositories
{
    public interface IRepositorio<T> where T : class
    {
        public T Add(T entity);
        public List<T> Get();
        public T? GetById(int id);

    }
}
