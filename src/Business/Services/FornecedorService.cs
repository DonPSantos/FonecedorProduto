﻿using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IEnderecoRepository enderecoRepository, INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task AdicionarAsync(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor) || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco))
                return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe fornecedor com o documento informado.");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task AtualizarAsync(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor))
                return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe fornecedor com o documento informado.");
                return;
            }
            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEnderecoAsync(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco))
                return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public void Dispose()
        {
            _enderecoRepository?.Dispose();
            _fornecedorRepository?.Dispose();
        }

        public async Task RemoverAsync(Guid id)
        {
            if (_fornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            await _fornecedorRepository.Remover(id);
        }
    }
}