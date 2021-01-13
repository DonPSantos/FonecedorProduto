using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificaoes = await Task.FromResult(_notificador.ObterNotificacoes());

            notificaoes.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Mensagem));

            return View();
        }
    }
}