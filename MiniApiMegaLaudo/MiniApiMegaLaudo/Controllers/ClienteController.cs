using MiniApiMegaLaudo.Models;
using System;
using System.Collections.Generic; 
using System.Net;
using System.Net.Http;
using System.Web.Http; 
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace MiniApiMegaLaudo.Controllers
{
    [RoutePrefix("Cliente")]
    
    public class ClienteController : ApiController
    {
        /*********************** Inclusão de Cliente *********************/
        [HttpPost]
        [Route("Incluir")]
        public HttpResponseMessage Incluir(Cliente cliente)
        {
            try
            {
                bool res = false;
                if (cliente == null)
                {
                    throw new ArgumentNullException("Cliente");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "exec INCLUIR_CLIENTE @nome, @cpf, @telefone, @endereco";

                command.Parameters.AddWithValue("nome", cliente.Nome);
                command.Parameters.AddWithValue("cpf", cliente.CPF);
                command.Parameters.AddWithValue("telefone", cliente.Telefone);
                command.Parameters.AddWithValue("endereco", cliente.Endereco);

                int i = command.ExecuteNonQuery();
                res = i > 0;

                cx.DesconectarBase();

                return Request.CreateResponse(HttpStatusCode.OK, res);

            }
            catch (Exception ex)
            { 
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); 
            }
        }



        /*alterar*/
        [HttpPut]
        [Route("Alterar")]
        public HttpResponseMessage Alterar(Cliente cliente)
        {
            try
            {
                bool res = false;

                if (cliente == null) throw new ArgumentNullException("cliente");

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "Exec ALTERAR_CLIENTE @id, @cpf, @nome, @telefone, @endereco;";

                command.Parameters.AddWithValue("@id", cliente.Id);
                command.Parameters.AddWithValue("@cpf",cliente.CPF);
                command.Parameters.AddWithValue("@nome", cliente.Nome);
                command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                command.Parameters.AddWithValue("@Endereco", cliente.Endereco);

                int i = command.ExecuteNonQuery();
                res = i > 0;

                cx.DesconectarBase();
                return Request.CreateResponse(HttpStatusCode.OK, res); 
            }
            catch (Exception ex )
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /********************Consulta de Clientes **********************/
        [HttpGet]
        [Route("Todos")]
        public HttpResponseMessage Todos()
        {
            try
            {
                List<Cliente> lstClientes = new List<Cliente>();
                Conexao con = new Conexao();
                con.ConectarBase();

                SqlCommand command = new SqlCommand();
                command.Connection = con.connection;
                command.CommandText = "exec LEITURA_CLIENTE '' ,''";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        Id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                        Nome = reader["nome"] == DBNull.Value ? string.Empty : reader["nome"].ToString(),
                        CPF = reader["cpf"] == DBNull.Value ? string.Empty : reader["cpf"].ToString(),
                        Endereco = reader["endereco"] == DBNull.Value ? string.Empty : reader["endereco"].ToString(),
                        Telefone = reader["telefone"] == DBNull.Value ? string.Empty : reader["telefone"].ToString(),
                    };
                    lstClientes.Add(cliente);
                }

                con.DesconectarBase();

                return Request.CreateResponse(HttpStatusCode.OK, lstClientes.ToArray());
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /********Excluir************/
        [HttpDelete]
        [Route("Excluir")]
        public HttpResponseMessage Excluir(Cliente cliente)
        {
            try
            {
                bool res = false;
                Conexao con = new Conexao();
                con.ConectarBase();

                SqlCommand command = new SqlCommand();
                command.Connection = con.connection;
                command.CommandText = "EXEC EXCLUIR_CLIENTE @id";
                command.Parameters.AddWithValue("@id", cliente.Id);

                int i = command.ExecuteNonQuery();

                res = 1 > 0;
                con.DesconectarBase();  

                return Request.CreateResponse(HttpStatusCode.BadRequest,res);

            }
            catch (Exception ex )
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); 
            }
        }
    }
}
 

