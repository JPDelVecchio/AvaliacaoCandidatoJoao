using MiniApiMegaLaudo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace MiniApiMegaLaudo.Controllers
{
    [RoutePrefix("Servico")]
    public class ServicoController : ApiController
    {
        /******** inclussão ***********/
        [HttpPost]
        [Route("Incluir")]
        public HttpResponseMessage Incluir(Servico servico)
        {
            try
            {
                bool res = false;

                if (servico == null)
                {
                    throw new ArgumentNullException("servico");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC INCLUIR_SERVICO @NOME, @DESCRICAO, @CLIENTE, @VEICULO, @VALOR";

                command.Parameters.AddWithValue("nome", servico.Nome);
                command.Parameters.AddWithValue("descricao", ((object)servico.Descricao) ?? DBNull.Value);
                command.Parameters.AddWithValue("cliente", ((object)servico.Cliente.Id) ?? DBNull.Value);
                command.Parameters.AddWithValue("veiculo", ((object)servico.Veiculo.Id) ?? DBNull.Value);
                command.Parameters.AddWithValue("valor", ((object)servico.Valor) ?? DBNull.Value);

                int i = command.ExecuteNonQuery();
                res = i > 0;

                cx.DesconectarBase();

                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        } 
        /******** Excluir ***********/
        [HttpDelete]
        [Route("Excluir")]
        public HttpResponseMessage Excluir(Servico servico)
        {
            try
            {
                bool res = false;

                if (servico == null)
                {
                    throw new ArgumentNullException("servico");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC EXCLUIR_SERVICO @ID";

                command.Parameters.AddWithValue("id", servico.Id);

                int i = command.ExecuteNonQuery();
                res = i > 0;

                cx.DesconectarBase();
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /******** ALterar ***********/
        [HttpPut]
        [Route("Alterar")]
        public HttpResponseMessage Alterar(Servico servico)
        {
            try
            {
                bool res = false;

                if (servico == null)
                {
                    throw new ArgumentNullException("servico");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC ALTERAR_SERVICO @ID, @NOME, @DESCRICAO, @CLIENTE, @VEICULO, @VALOR";

                command.Parameters.AddWithValue("id", servico.Id);
                command.Parameters.AddWithValue("Nome", ((object)servico.Nome ?? DBNull.Value));
                command.Parameters.AddWithValue("Descricao", ((object)servico.Descricao ?? DBNull.Value));
                command.Parameters.AddWithValue("cliente", ((object)servico.Descricao ?? DBNull.Value));
                command.Parameters.AddWithValue("veiculo", ((object)servico.Descricao ?? DBNull.Value));
                command.Parameters.AddWithValue("valor", ((object)servico.Descricao ?? DBNull.Value));

                int i = command.ExecuteNonQuery();
                res = i > 0;

                cx.DesconectarBase();
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            } 
        }

        [HttpGet]
        [Route("Todos")]
        public HttpResponseMessage Todos()
        { 
            try
            {
                var listaservicos = new List<Servico>();
                Conexao con = new Conexao();
                con.ConectarBase();

                SqlCommand command = new SqlCommand();
                command.Connection = con.connection;
                command.CommandText = "exec LEITURA_SERVICOS";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var servico = new Servico();
                    {
                        servico.DataServico = reader["DATASERVICO"] == DBNull.Value ? Convert.ToDateTime(null) : Convert.ToDateTime(reader["DATASERVICO"]);
                        servico.Nome = reader["SERVICO"] == DBNull.Value ? string.Empty : reader["SERVICO"].ToString();
                        servico.Descricao = reader["DESCRICAO"] == DBNull.Value ? string.Empty : reader["DESCRICAO"].ToString();
                        servico.Cliente.Id = reader["CLIENTE"] == DBNull.Value ? 0 : Convert.ToInt32( reader["CLIENTE"]);
                        servico.Valor = reader["VALOR"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["VALOR"]);

                    }
                    listaservicos.Add(servico);
                } 
                con.DesconectarBase();

                return Request.CreateResponse(HttpStatusCode.OK, listaservicos.ToArray());
            } 
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }


        [HttpGet]
        [Route("BuscaPorVeiculo")]
        public HttpResponseMessage ServicoPorVeiculo(string placa)
        { 
            try
            {
                var listaservicos = new List<Servico>();
                Conexao con = new Conexao();
                con.ConectarBase();

                SqlCommand command = new SqlCommand();
                command.Connection = con.connection;
                command.CommandText = "EXEC LEITURA_SERVICO_VEICULO '@PLACA'";
                command.Parameters.AddWithValue("Placa", placa).ToString();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var servico = new Servico();
                    {
                        servico.DataServico = reader["DATASERVICO"] == DBNull.Value ? Convert.ToDateTime(null) : Convert.ToDateTime(reader["DATASERVICO"]);
                        servico.Nome = reader["SERVICO"] == DBNull.Value ? string.Empty : reader["SERVICO"].ToString();
                        servico.Descricao = reader["DESCRICAO"] == DBNull.Value ? string.Empty : reader["DESCRICAO"].ToString(); 
                        servico.Valor = reader["VALOR"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["VALOR"]);
                        servico.Veiculo.Placa = reader["PLACA"] == DBNull.Value ? string.Empty : reader["PLACA"].ToString();
                        servico.Veiculo.AnoModelo = reader["ANOMODELO"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ANOMODELO"]);
                        servico.Veiculo.AnoFabricacao = reader["ANOFABRICACAO"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ANOFABRICACAO"]);

                    }
                    listaservicos.Add(servico);
                }
                con.DesconectarBase();

                return Request.CreateResponse(HttpStatusCode.OK, listaservicos.ToArray());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }


        [HttpGet]
        [Route("BuscaPorCliente")]
        public HttpResponseMessage ServicoPorCliente(string cpfCliente)
        {
            try
            {
                var listaservicos = new List<Servico>();
                Conexao con = new Conexao();
                con.ConectarBase();

                SqlCommand command = new SqlCommand();
                command.Connection = con.connection;
                command.CommandText = "EXEC LEITURA_SERVICO_VEICULO '@CPF'";
                command.Parameters.AddWithValue("CPF", cpfCliente).ToString();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var servico = new Servico();
                    {
                        servico.DataServico = reader["DATASERVICO"] == DBNull.Value ? Convert.ToDateTime(null) : Convert.ToDateTime(reader["DATASERVICO"]);
                        servico.Nome = reader["SERVICO"] == DBNull.Value ? string.Empty : reader["SERVICO"].ToString();
                        servico.Descricao = reader["DESCRICAO"] == DBNull.Value ? string.Empty : reader["DESCRICAO"].ToString();
                        servico.Valor = reader["VALOR"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["VALOR"]);
                        servico.Cliente.Nome = reader["CLIENTE"] == DBNull.Value ? string.Empty : reader["CLIENTE"].ToString();
   
                    }
                    listaservicos.Add(servico);
                }
                con.DesconectarBase();

                return Request.CreateResponse(HttpStatusCode.OK, listaservicos.ToArray());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
