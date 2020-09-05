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
    [RoutePrefix("Modelo")]
    public class ModeloController : ApiController
    {

        /******** inclussão ***********/
        [HttpPost]
        [Route("Incluir")]
        public HttpResponseMessage Incluir(Modelo modelo)
        {
            try
            {
                bool res = false;

                if (modelo == null)
                {
                    throw new ArgumentNullException("Modelo");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "exec INCLUIR_MODELO  @id_marca, @nome, @descricao";

                command.Parameters.AddWithValue("nome", modelo.Nome);
                command.Parameters.AddWithValue("descricao", ((object)modelo.Descricao) ?? DBNull.Value);
                command.Parameters.AddWithValue("id_marca", ((object)modelo.Id_marca) ?? DBNull.Value);

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
        public HttpResponseMessage Excluir(Modelo modelo)
        {
            try
            {
                bool res = false;

                if (modelo == null)
                {
                    throw new ArgumentNullException("Modelo");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC EXCLUIR_MODELO @ID";

                command.Parameters.AddWithValue("id", modelo.Id);

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
        public HttpResponseMessage Alterar(Modelo modelo)
        {
            try
            {
                bool res = false;

                if (modelo == null)
                {
                    throw new ArgumentNullException("modelo");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC ALTERAR_MODELO @ID, @MARCA, @NOME, @DESCRICAO";

                command.Parameters.AddWithValue("id", modelo.Id);
                command.Parameters.AddWithValue("marca", ((object)modelo.Id_marca ?? DBNull.Value));
                command.Parameters.AddWithValue("Nome", ((object)modelo.Nome ?? DBNull.Value));
                command.Parameters.AddWithValue("Descricao", ((object)modelo.Descricao ?? DBNull.Value));

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
