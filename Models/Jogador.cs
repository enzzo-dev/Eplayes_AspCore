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