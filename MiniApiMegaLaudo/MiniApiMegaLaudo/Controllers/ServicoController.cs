using MiniApiMegaLaudo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
                command.Parameters.AddWithValue("cliente", ((object)servico.Id_cliente) ?? DBNull.Value);
                command.Parameters.AddWithValue("veiculo", ((object)servico.Id_veiculo) ?? DBNull.Value);
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




    }
}
