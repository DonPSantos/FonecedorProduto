using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task AdicionarAsync(Fornecedor fornecedor);

        Task AtualizarAsync(Fornecedor fornecedor);

        Task AtualizarEnderecoAsync(Endereco endereco);

        Task RemoverAsync(Guid id);
    }
}