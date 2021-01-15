using Eplayes_AspCore.Interfaces;
using System.IO;
using System.Collections.Generic;
using Eplayes_AspCore.Controllers;

namespace Eplayes_AspCore.Models
{
    public class Jogador
    {
        public int IdJogador { get; set; }

        public string Nome { get; set; }

        public int IdEquipe { get; set; }
        
        private const string PATH = "Database/Jogador.csv";

    }
}