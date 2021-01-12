using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Eplayes_AspCore.Models;
using System;

namespace Eplayes_AspCore.Controllers
{

    [Route("Equipe")]
    //https://localhost:5000/Equipe

    public class EquipeController : Controller
    {

        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

    [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            //Método de cadastro de equipes no arquivo CSV
            equipeModel.Create(novaEquipe);

            //Atualiza a lista de equipes na View
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}
