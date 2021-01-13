using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task AdicionarAsync(Produto produto);

        Task AtualizarAsync(Produto produto);

        Task RemoverAsync(Guid id);
    }
}