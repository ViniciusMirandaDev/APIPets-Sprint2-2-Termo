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
    public class RacaRepository : IRaca
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();
        public Raca Alterar(int id, Raca a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET " +
                "Descricao = @descricao " +
                "IdTipoPet = @idtipodepet " +

                "WHERE Raca = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@descicao", a.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", a.IdTipoDePet);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Raca BuscarPorId(int id)
        {
            // Abrimos a conexao
            cmd.Connection = conexao.Conectar();

            // Atribuimos nossa conexao
            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            // Dizemos quem é o @id
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca a = new Raca();

            while (dados.Read())
            {
                a.IdRaca = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
                a.IdTipoDePet = Convert.ToInt32(dados.GetValue(2));

            }

            conexao.Desconectar();

            return a;
        }

        public Raca Cadastrar(Raca a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Raca " +
                "(Descricao, IdTipoDePet)" +
                "VALUES" +
                "(@descricao, @idtipodepet)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", a.IdTipoDePet);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            // Atribuimos nossa conexao
            cmd.CommandText = "SELECT * FROM Raca";

            // Lemos os dados
            SqlDataReader dados = cmd.ExecuteReader();

            // Criamos uma lista para ser populada
            List<Raca> racas = new List<Raca>();

            // Criamos um laço para ler todas as linhas
            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(2)),
                    }
                );
            }

            // Fechamos a conexao
            conexao.Desconectar();

            return racas;
        }
    }
}
