using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_gamer.Infra;
using Projeto_gamer.Models;

namespace Projeto_gamer.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();

        [Route("Listar")] //http://localhost//Jogador//Listar

        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Jogador = c.jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();
            return View();
        }

        [Route("Cadastrar")] //https://localhost/Jogador/Cadastrar
        public IActionResult Cadastrar(IFormCollection form)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            Jogador j = new Jogador();

            j.Name = form["Nome"].ToString();
            j.Email = form["Email"].ToString();
            j.Senha = form["Senha"].ToString();

            string novaEquipe = form["Equipe"].ToString();

            j.Equipe = c.Equipe.First(x => x.Nome == novaEquipe);

            j.IdEquipe = j.Equipe.IdEquipe;

            c.jogador.Add(j);

            c.SaveChanges();

            ViewBag.Jogador = c.jogador.ToList();
            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir/{id}")]

        public IActionResult Excluir(int id)
        {
            Jogador jogadorBuscada = c.jogador.FirstOrDefault(e => e.IdJogador == id);

            c.jogador.Remove(jogadorBuscada);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }
        [Route("Editar/{id}")]

        public IActionResult Editar(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            Jogador jogador = c.jogador.First(x => x.IdJogador == id);

            ViewBag.Jogador = jogador;

            ViewBag.Equipe = c.Equipe.ToList();

            return View("Edit");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            // Instanciando 

            Jogador jogador = new Jogador();

            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            jogador.IdJogador = int.Parse(form["IdJogador"].ToString());

            jogador.Name = form["Name"].ToString();

            jogador.Email = form["Email"].ToString();
            
            jogador.Senha = form["Senha"].ToString();
            
            // Codificando e Atualizando
            Jogador jogadorBuscada = c.jogador.First(x => x.IdJogador == jogador.IdJogador);

            jogadorBuscada.Name = jogador.Name;

            jogadorBuscada.Email = jogador.Email;

            jogadorBuscada.Senha = jogador.Senha;

            // Atualizando a Imagem da equipe
            string novaEquipe = form["Equipe"].ToString();

            jogador.Equipe = c.Equipe.First(x => x.Nome == novaEquipe);

            jogador.IdEquipe = jogador.Equipe.IdEquipe;

            jogadorBuscada.Equipe = jogador.Equipe;
            
            // Salvando as atualizações
            c.jogador.Update(jogadorBuscada);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


    }
}