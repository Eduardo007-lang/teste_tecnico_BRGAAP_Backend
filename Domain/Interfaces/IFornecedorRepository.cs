using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using teste_tecnico_api.Domain.Models;


namespace teste_tecnico_api.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task AddFornecedorAsync(Fornecedor fornecedor);
        Task<Fornecedor> GetFornecedorByIdAsync(string id);
        Task<IEnumerable<Fornecedor>> GetAllFornecedoresAsync();
    }
}
