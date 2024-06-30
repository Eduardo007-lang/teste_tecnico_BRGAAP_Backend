using System.Collections.Generic;
using System.Threading.Tasks;
using teste_tecnico_api.Domain.Models;

namespace teste_tecnico_api.Application.Services
{
    public interface INotaFiscalService
    {
        Task AddNotaFiscalAsync(NotaFiscal notaFiscal);
        Task<NotaFiscal> GetNotaFiscalByIdAsync(string id);
        Task<IEnumerable<NotaFiscal>> GetAllNotasFiscaisAsync();
    }
}
