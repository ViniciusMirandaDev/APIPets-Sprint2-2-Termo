using APIPets.Domais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface IRaca
    {
        List<Raca> LerTodos();
        Raca BuscarPorId(int id);
        Raca Cadastrar(Raca a);
        Raca Alterar(int id, Raca a);
        void Excluir(int id);
    }
}
