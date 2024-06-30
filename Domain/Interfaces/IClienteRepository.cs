using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using teste_tecnico_api.Domain.Models;


namespace teste_tecnico_api.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task AddClienteAsync(Cliente cliente);
        Task<Cliente> GetClienteByIdAsync(string id);
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
    }
}
