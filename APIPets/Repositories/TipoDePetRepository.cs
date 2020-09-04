using APIPets.Context;
using APIPets.Domais;
using APIPets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Repositories
{
    public class TipoDePetRepository : ITipoDePet
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();
        public TipoDePet Alterar(int id, TipoDePet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoDePet SET " +
                "Descricao = @descricao " +
                
                "WHERE IdTipoDePet = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public TipoDePet BuscarPorId(int id)
        {
            // Abrimos a conexao
            cmd.Connection = conexao.Conectar();

            // Atribuimos nossa conexao
            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDoPet = @id";

            // Dizemos quem é o @id
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet a = new TipoDePet();

            while (dados.Read())
            {
                a.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();

            }

            conexao.Desconectar();

            return a;
        }

        public TipoDePet Cadastrar(TipoDePet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO TipoDePet " +
                "(IdTipoDePet, Descricao)" +
                "VALUES" +
                "(@idtipodepet @descricao)";
            cmd.Parameters.AddWithValue("@idtipodepet", a.IdTipoDePet);
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TipoDePet> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            // Atribuimos nossa conexao
            cmd.CommandText = "SELECT * FROM TipoDePet";

            // Lemos os dados
            SqlDataReader dados = cmd.ExecuteReader();

            // Criamos uma lista para ser populada
            List<TipoDePet> pets = new List<TipoDePet>();

            // Criamos um laço para ler todas as linhas
            while (dados.Read())
            {
                pets.Add(
                    new TipoDePet()
                    {
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
            }

            // Fechamos a conexao
            conexao.Desconectar();

            return pets;
        }
    }
}
