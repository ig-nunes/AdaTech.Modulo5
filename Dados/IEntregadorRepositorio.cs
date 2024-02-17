namespace Dados
{
    public interface IEntregadorRepositorio<Entregador> 
    {
        Entregador Add(Entregador entregador);
        List<Entregador> Get();
        Entregador GetByCpf(string cpf);
    }
}
