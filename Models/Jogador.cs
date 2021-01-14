using Eplayes_AspCore.Interfaces;
using System.IO;
using System.Collections.Generic;
using Eplayes_AspCore.Controllers;

namespace Eplayes_AspCore.Models
{
    public class Jogador : EplayersBase , IJogador , EquipeController
    {
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public int IdEquipe { get; set; }
        
        private const string PATH = "Database/Jogador.csv";

         public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe}";
        }
        
        public void Create(Jogador j)
        {
            string[] linhas = { Prepare(j) };

            //Escrevemos linhas no arquivo csv
            File.AppendAllLines(PATH, linhas);
        }

        public List<Jogador> ReadAll()
        {

            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador novoJogador = new Jogador();

                novoJogador.IdJogador = int.Parse( linha[0] );
                novoJogador.Nome     = linha[1];
                novoJogador.IdEquipe   = int.Parse( linha[2] ); 

                jogadores.Add(novoJogador);  
            }

           return jogadores;

        }


        public void Update(Jogador jogadorAlterado)
        {
            List<string> linhas = ReadAllLinesCSV(PATH); 

            //Removemos as linhas com o código comparado.
            linhas.RemoveAll(x => x.Split(";")[0] == jogadorAlterado.IdJogador.ToString());

            linhas.Add( Prepare(jogadorAlterado ) );

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