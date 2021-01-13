using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task AdicionarAsync(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Adicionar(produto);
        }

        public async Task AtualizarAsync(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Atualizar(produto);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        public async Task RemoverAsync(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
    }
}