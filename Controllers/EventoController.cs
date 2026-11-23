using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciciosASP.NET.Models;
using ExerciciosASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExerciciosASP.NET.Controllers
{
    public class EventoController : Controller
    {
        
         private static List<Evento> _evento = new()
        {
          new Evento{ Id = 1, Nome = "Aniversario do Neymar", Descricao = "Festa de 35 anos do jogador", Local = "Vila Belmiro",
           DataEvento = new DateTime(2027, 02, 05), QuantidadesVagas = 52, ValorIngresso = 70.00m},   
          new Evento{ Id = 2, Nome = "Formatura SENAI", Descricao = "Formatura do curso tecnico de DS", Local = "Ibiza",
           DataEvento = new DateTime(2027, 12, 20), QuantidadesVagas = 40, ValorIngresso = 210.00m }   
        };

//GET /Alunos - listar todos os alunos
        public IActionResult Index()
        {
            return View(_evento);
        }

        // GET /Alunos/Detalhes/1 - mostrar um aluno especifico
        public IActionResult Detalhes(int Id)
        {
            var evento = _evento.FirstOrDefault(a => a.Id == Id);
            if(evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

    // GET /Alunos/Criar - retomar a view de Criação de Alunos
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

    // POST /Alunos/Criar - recebe dados da View Criar()
        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if(!ModelState.IsValid)
            {
                return View(evento); 

            }

            evento.Id = _evento.Any() ? _evento.Max(a => a.Id) + 1 : 1;
            _evento.Add(evento);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }

        // POST /Alunos/Buscar
        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel vm)
        {
            if(!string.IsNullOrEmpty(vm.NomeBusca))
            {
                
            vm.Resultados = _evento
                .Where(a => a.Nome.Contains(vm.NomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();

            }
                return View(vm);
        }

        
    }
}