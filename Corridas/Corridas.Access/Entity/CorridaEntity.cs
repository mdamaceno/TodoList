using Corridas.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corridas.Access.Entity
{
    public class CorridaEntity : EntityBase
    {

        public CorridaEntity()
        {
            this.Tabela = "corrida";
        }

        public bool Alterar(Corrida corrida)
        {
            var conexao = new MySqlConnection(CorridaDAO.StringConexao);
            try
            {
                conexao.Open();

                var sql = "UPDATE corrida SET nome = @nome, id_Local = @id_Local "+
                    "where id = @id";

                var cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@nome", corrida.Nome);
                cmd.Parameters.AddWithValue("@id_Local", corrida.Local.Id);
                cmd.Parameters.AddWithValue("@id", corrida.Id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool Inserir(Corrida corrida)
        {
            var conexao = new MySqlConnection(CorridaDAO.StringConexao);
            try
            {
                conexao.Open();

                var sql = "INSERT INTO corrida (nome, id_local, valor, distancia, dataCorrida) "+
                    " VALUES (@nome, @idLocal, 0, @distancia, @dataCorrida)";

                var cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@nome", corrida.Nome);
                cmd.Parameters.AddWithValue("@idLocal", corrida.Local.Id);
                cmd.Parameters.AddWithValue("@distancia", corrida.Distancia);
                cmd.Parameters.AddWithValue("@dataCorrida", corrida.DataCorrida);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<Corrida> GetAll()
        {
            try
            {
                var lista = new List<Corrida>();

                var sql = "select * from " + this.Tabela;

                var dataSet = new DataSet();
                var query = new MySqlDataAdapter(sql, CorridaDAO.StringConexao);
                query.Fill(dataSet);

                var locais = CorridaDAO.Entities.LocalEntity.GetAll();

                foreach (var item in dataSet.Tables[0].AsEnumerable().ToList())
                {
                    var corrida = new Corrida()
                    {
                        Id = Convert.ToInt16(item["Id"]),
                        Nome = item["Nome"].ToString(),
                        DataCorrida = Convert.ToDateTime(item["dataCorrida"]),
                        Distancia = Convert.ToInt16(item["distancia"]),
                        Local = locais.FirstOrDefault(f => f.Id == Convert.ToInt16(item["Id_local"]))
                    };

                    lista.Add(corrida);
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
