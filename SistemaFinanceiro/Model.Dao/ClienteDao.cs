using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao {
    internal class ClienteDao : Obrigatorio<Cliente> {

        private ConexaoDb objConexaoDB;  // vai criar a conexao
        private SqlCommand comando;


        public ClienteDao() {
            // vai criar a conexão no momento da instância do objeto
            objConexaoDB = ConexaoDb.saberEstado();
        }

        public void create1(Cliente objCliente) {
            string create = $"insert into cliente(nome, endereco, telefone, cpf) values ('{objCliente.Nome}','{objCliente.Endereco}','{objCliente.Telefone}','{objCliente.Cpf}')";
            try {
                // cria a instância passando a query e pegando a conexao
                comando = new SqlCommand(create, objConexaoDB.getCon());
                // abre a conexao
                objConexaoDB.getCon().Open();
                // salva os dados no banco
                comando.ExecuteNonQuery();
            }
            catch (Exception e) {

                objCliente.Estado = 1;
            }
            finally {
                // fecha a conexao
                objConexaoDB.getCon().Close();
                // encerra o banco
                objConexaoDB.CloseDB();
            }
        }

        public void create(Cliente objCliente) {
            // insert via procedimento (store procedure) SQL
            string create = "sp_cliente_adc" + objCliente.Nome + ", " + objCliente.Endereco + ", " + objCliente.Telefone + ", " + objCliente.Cpf;
            try {
                // cria a instância passando a query e pegando a conexao
                comando = new SqlCommand(create, objConexaoDB.getCon());
                // abre a conexao
                objConexaoDB.getCon().Open();
                // salva os dados no banco
                comando.ExecuteNonQuery();
            }
            catch (Exception e) {

                objCliente.Estado = 1;
            }
            finally {
                // fecha a conexao
                objConexaoDB.getCon().Close();
                // encerra o banco
                objConexaoDB.CloseDB();
            }
        }


        public void delete(Cliente objCliente) {

            string delete = $"delete from cliente where idCliente = '{objCliente.IdCliente}'";
            try {
                // cria a instância passando a query e pegando a conexao
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                // abre a conexao
                objConexaoDB.getCon().Open();
                // salva os dados no banco
                comando.ExecuteNonQuery();
            }
            catch (Exception e) {

                objCliente.Estado = 1;
            }
            finally {
                // fecha a conexao
                objConexaoDB.getCon().Close();
                // encerra o banco
                objConexaoDB.CloseDB();
            }

        }

        public bool find(Cliente objCliente) {

            bool temRegistros;

            string find = $"Select * from cliente where idCliente = '{objCliente.IdCliente}'";
            try {
                // cria a instância passando a query e pegando a conexao
                comando = new SqlCommand(find, objConexaoDB.getCon());
                // abre a conexao
                objConexaoDB.getCon().Open();

                // vai ler as informações no banco e listar os dados
                // toda vez que tivermos que pegar informações do banco devemos utilizar o SqlDataReader
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros) {
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    objCliente.Estado = 99;
                }
                else {
                    //não econtrou registro
                    objCliente.Estado = 1;
                }
            }
            catch (Exception) {

                throw;
            }
            finally {
                // fecha a conexao
                objConexaoDB.getCon().Close();
                // encerra o banco
                objConexaoDB.CloseDB();
            }
            return temRegistros;
        }

        public List<Cliente> findAll() {

           List<Cliente> listaClientes = new List<Cliente> ();
            string findAll = "Select * from cliente order by nome asc";
            try {
                // cria a instância passando a query e pegando a conexao
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                // abre a conexao
                objConexaoDB.getCon().Open();

                // vai ler as informações no banco e listar os dados
                // toda vez que tivermos que pegar informações do banco devemos utilizar o SqlDataReader
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nome = reader[1].ToString();
                    objCliente.Endereco = reader[2].ToString();
                    objCliente.Telefone = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    listaClientes.Add(objCliente);
                }

            }
            catch (Exception) {

                throw;
            }
            finally {
                // fecha a conexao
                objConexaoDB.getCon().Close();
                // encerra o banco
                objConexaoDB.CloseDB();
            }
            return listaClientes;
        }

        public void update(Cliente objCliente) {
            string update = $"update cliente set nome = ''";
            try {
                // cria a instância passando a query e pegando a conexao
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                // abre a conexao
                objConexaoDB.getCon().Open();
                // salva os dados no banco
                comando.ExecuteNonQuery();
            }
            catch (Exception e) {

                objCliente.Estado = 1;
            }
            finally {
                // fecha a conexao
                objConexaoDB.getCon().Close();
                // encerra o banco
                objConexaoDB.CloseDB();
            }
        }
    }
}
