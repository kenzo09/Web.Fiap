using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiaUrgente)
        {
            var view = noticiaUrgente ? "noticiasUrgentes" : "noticias";
            var itens = GetItens(total);

            return View(view, itens);
        }

        private IEnumerable<Noticia> GetItens(int total)
        {
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia
                {
                    Id = i + 1,
                    Titulo = $"Noticia sobre {i + 1}"
                };
            }
        }
    }

    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }
    }
}
