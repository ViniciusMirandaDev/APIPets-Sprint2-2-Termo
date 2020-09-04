using APIPets.Domais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface ITipoDePet
    {
        List<TipoDePet> LerTodos();
        TipoDePet BuscarPorId(int id);
        TipoDePet Cadastrar(TipoDePet a);
        TipoDePet Alterar(int id, TipoDePet a);
        void Excluir(int id);
    }
}
