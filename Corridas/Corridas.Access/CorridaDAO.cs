using Corridas.Access.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corridas.Access
{
    public class CorridaDAO
    {
        public const string StringConexao = "Persist Security Info=False;server=localhost;"+
            "database=calendariocorridas;uid=root;pwd=aluno";

        private static CorridaDAO _instance = null;

        private MySqlConnection conexao { get; set; }

        public CorridaEntity CorridaEntity { get; set; }
        public LocalEntity LocalEntity { get; set; }

        private CorridaDAO()
        {
            if (this.Conectar())
            {
                this.LocalEntity = new LocalEntity();
                this.CorridaEntity = new CorridaEntity();
            }
        }

        private bool Conectar()
        {
            try
            {
                this.conexao = new MySqlConnection(CorridaDAO.StringConexao);
                this.conexao.Open();
                this.conexao.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static CorridaDAO Entities
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CorridaDAO();
                }

                return _instance;
            }
        }
    }
}
