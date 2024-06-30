using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using teste_tecnico_api.Domain.Interfaces;
using teste_tecnico_api.Domain.Models;
using MongoDB.Driver;

namespace teste_tecnico_api.Application.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMongoClient _mongoClient;

        public NotaFiscalService(
            INotaFiscalRepository notaFiscalRepository,
            IClienteRepository clienteRepository,
            IFornecedorRepository fornecedorRepository,
            IMongoClient mongoClient)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _clienteRepository = clienteRepository;
            _fornecedorRepository = fornecedorRepository;
            _mongoClient = mongoClient;
        }

        public async Task AddNotaFiscalAsync(NotaFiscal notaFiscal)
        {
            if (notaFiscal == null) throw new ArgumentNullException(nameof(notaFiscal));
            if (notaFiscal.Cliente == null) throw new ArgumentNullException(nameof(notaFiscal.Cliente), "Cliente cannot be null");
            if (notaFiscal.Fornecedor == null) throw new ArgumentNullException(nameof(notaFiscal.Fornecedor), "Fornecedor cannot be null");

                    await _clienteRepository.AddClienteAsync(notaFiscal.Cliente);
                    await _fornecedorRepository.AddFornecedorAsync(notaFiscal.Fornecedor);
                    await _notaFiscalRepository.AddNotaFiscalAsync(notaFiscal);
    
        }

        public async Task<NotaFiscal> GetNotaFiscalByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID cannot be null or whitespace.", nameof(id));
            return await _notaFiscalRepository.GetNotaFiscalByIdAsync(id);
        }

        public async Task<IEnumerable<NotaFiscal>> GetAllNotasFiscaisAsync()
        {
            return await _notaFiscalRepository.GetAllNotasFiscaisAsync();
        }
    }
}
