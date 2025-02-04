﻿using App.Extensions;
using Business.Interfaces;
using Business.Models;
using Business.Notifications;
using Business.Services;
using Data.Context;
using Data.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDenpendencies(this IServiceCollection services)
        {
            services.AddScoped<FornecedorProdutoContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaAttributeAdapterProvider>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}