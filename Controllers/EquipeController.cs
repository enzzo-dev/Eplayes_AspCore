using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Eplayes_AspCore.Models;
using System;
using System.IO;

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

            //Upload Inicio

            //Verifica se o usuário selecionou um arquivo

            if(form.Files.Count > 0)
            {
                //Recebemos o arquivo que o usuário selecionou e armazenamos em uma variavel
                var file = form.Files[0];
                var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Equipes" );

                //Verificamos se a pasta existe, se não a criamos
                if(!Directory.Exists( folder ))
                {
                    Directory.CreateDirectory( folder );
                }

                var path = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName );
                
                using (var stream = new FileStream( path, FileMode.Create ))
                {
                    file.CopyTo( stream );
                }

                novaEquipe.Imagem = file.FileName;

            } else {

                novaEquipe.Imagem = "padrao.png";
            }
            //Upload Final

            //Método de cadastro de equipes no arquivo CSV
            equipeModel.Create( novaEquipe );

            //Atualiza a lista de equipes na View
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

    [Route("{id}")]
    public IActionResult Excluir(int id)
    {
        equipeModel.Delete(id);
        ViewBag.Equipes = equipeModel.ReadAll();
        return LocalRedirect("~/Equipe/Listar"); 
    }

    }
}
