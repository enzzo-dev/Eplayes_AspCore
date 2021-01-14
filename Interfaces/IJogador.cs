using Eplayes_AspCore.Models;
using System.Collections.Generic;

namespace Eplayes_AspCore.Interfaces
{
    public interface IJogador
    {
          //Métodos de CRUD - Contrato de negócio
        void Create(Jogador j); 

        List<Jogador> ReadAll();

        void Update(Jogador jogadorAlterado);

        void Delete(int id);
    }
}