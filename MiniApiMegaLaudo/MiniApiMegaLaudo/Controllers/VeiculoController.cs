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
    [RoutePrefix("Veiculo")]
    public class VeiculoController : ApiController
    {
        /******** inclussão ***********/
        [HttpPost]
        [Route("Incluir")]
        public HttpResponseMessage Incluir(Veiculo veiculo)
        {
            try
            {
                bool res = false;

                if (veiculo == null)
                {
                    throw new ArgumentNullException("Veiculo");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC INCLUIR_VEICULO @PLACA, @MARCA, @MODELO, @ANOFABRICACAO, @ANOMODELO";

                command.Parameters.AddWithValue("Placa", veiculo.Placa);
                command.Parameters.AddWithValue("marca", ((object)veiculo.Id_marca) ?? DBNull.Value);
                command.Parameters.AddWithValue("modelo", ((object)veiculo.Id_modelo) ?? DBNull.Value);
                command.Parameters.AddWithValue("anofabricacao", ((object)veiculo.AnoFabricacao) ?? DBNull.Value);
                command.Parameters.AddWithValue("anomodelo", ((object)veiculo.AnoModelo) ?? DBNull.Value);

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
        public HttpResponseMessage Excluir(Veiculo veiculo)
        {
            try
            {
                bool res = false;

                if (veiculo == null)
                {
                    throw new ArgumentNullException("Veiculo");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC EXCLUIR_VEICULO @ID";

                command.Parameters.AddWithValue("id", veiculo.Id);

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
        public HttpResponseMessage Alterar(Veiculo veiculo)
        {
            try
            {
                bool res = false;

                if (veiculo == null)
                {
                    throw new ArgumentNullException("Veiculo");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC ALTERAR_VEICULO @ID, @PLACA, @MARCA, @MODELO, @ANOMODELO, @ANOFABRICACAO";

                command.Parameters.AddWithValue("id", veiculo.Id);
                command.Parameters.AddWithValue("placa", ((object)veiculo.Id_marca ?? DBNull.Value));
                command.Parameters.AddWithValue("marca", ((object)veiculo.Id_marca ?? DBNull.Value));
                command.Parameters.AddWithValue("modelo", ((object)veiculo.Id_modelo ?? DBNull.Value));
                command.Parameters.AddWithValue("anomodelo", ((object)veiculo.AnoModelo ?? DBNull.Value));
                command.Parameters.AddWithValue("anofabricacao", ((object)veiculo.AnoFabricacao ?? DBNull.Value));

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
