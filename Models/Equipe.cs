using Eplayes_AspCore.Interfaces;
using System.IO;
using System.Collections.Generic;

namespace Eplayes_AspCore.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        
        public void Create(Equipe e)
        {
            string[] linhas = { Prepare(e) };

            //Escrevemos linhas no arquivo csv
            File.AppendAllLines(PATH, linhas);
        }

        public List<Equipe> ReadAll()
        {

            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Equipe novaEquipe = new Equipe();

                novaEquipe.IdEquipe = int.Parse( linha[0]);
                novaEquipe.Nome     = linha[1];
                novaEquipe.Imagem   = linha[2]; 

                equipes.Add(novaEquipe);  
            }

           return equipes;

        }


        public void Update(Equipe equipeAlterada)
        {
            List<string> linhas = ReadAllLinesCSV(PATH); 

            //Removemos as linhas com o código comparado.
            linhas.RemoveAll(x => x.Split(";")[0] == equipeAlterada.IdEquipe.ToString());

            linhas.Add( Prepare(equipeAlterada) );

            RewriteCSV(PATH, linhas);

        }


        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH); 

            //Removemos as linhas com o código comparado.
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            

            RewriteCSV(PATH, linhas);
        }

       
    }
}