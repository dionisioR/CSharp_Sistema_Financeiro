using System.Data.SqlClient;

namespace Model.Dao {
    internal class ConexaoDb {
        private static ConexaoDb objConexaoDB = null;
        private SqlConnection con;

        private ConexaoDb() {
            con = new SqlConnection("Data Source=DESKTOP-74TBS68\\SQLEXPRESS; Initial Catalog=financeiro; Integrated Security=True");
        }

        /// <summary>
        /// Cria a conexão caso ela não exista
        /// </summary>
        /// <returns></returns>
        public static ConexaoDb saberEstado() {

            if (objConexaoDB == null) {
                objConexaoDB = new ConexaoDb();
            }
            return objConexaoDB;
        }

        public SqlConnection getCon() {
            return con;
        }

        public void CloseDB() {
            objConexaoDB = null;
        }
    }
}
