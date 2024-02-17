using DadosSistema.Models;

namespace WebApi.RequestModels
{
    public class VendaRequest
    {
        public string? Cliente { get; set; }
        public List<ItemVendaRequest>? ItemVendaRequests { get; set; }
    }
}
