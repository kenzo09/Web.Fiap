using Fiap01.Data;
using Fiap01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap01.Controllers
{
    public class HomeController : Controller
    {
        private PerguntasContext _context;

        public HomeController(PerguntasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewBag.Nome = "Rodolfo";
            //ViewData["NomeDoAluno"] = $"Outro Nome {DateTime.Now}";

            ////Imaginem um acesso ao DB
            //var pergunta = new Pergunta() { Id = 1, Descricao = "Que horas é a chamada?", Autor = "Daniel" };
            
            return View(_context.Perguntas.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Perguntas.Add(pergunta);
                await _context.SaveChangesAsync();
                //salva no banco
                var a = pergunta;

            }

            return View();
        }

        //[HttpPost]
        //public IActionResult Create(IFormCollection collection)
        //{
        //    var desc = collection["Descricao"];
        //    var auth = collection["Autor"];
        //    return View();
        //}



        public IActionResult Ajuda()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }
    }
}
