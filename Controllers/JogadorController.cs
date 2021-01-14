using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Eplayes_AspCore.Models;
using System;
using System.IO;


namespace Eplayes_AspCore.Controllers
{

    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();

        [Route("Listar")]

        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();
            
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.Nome = form["Nome"];
            novoJogador.IdEquipe =  Int32.Parse(form["IdEquipe"]);

            //Upload Inicio

            //Verifica se o usuário selecionou um arquivo

            //Método de cadastro de equipes no arquivo CSV
            jogadorModel.Create( novoJogador );

            //Atualiza a lista de equipes na View
            ViewBag.Jogadores = JogadorModel.ReadAll();

            return LocalRedirect("~/Jogador/Listar");
        }

    [Route("{id}")]
    public IActionResult Excluir(int id)
    {
        equipeModel.Delete(id);
        ViewBag.Equipes = equipeModel.ReadAll();
        return LocalRedirect("~/Jogador/Listar"); 
    }

    }
}