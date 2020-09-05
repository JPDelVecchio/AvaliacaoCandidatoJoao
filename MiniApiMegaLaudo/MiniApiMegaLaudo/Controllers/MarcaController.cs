using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace MiniApiMegaLaudo.Models
{
    [RoutePrefix("Marca")]
    public class MarcaController : ApiController
    {
        /******** inclussão ***********/
        [HttpPost]
        [Route("Incluir")]
        public HttpResponseMessage Incluir(Marca marca)
        {
            try
            {
                bool res = false;

                if (marca == null)
                {
                    throw new ArgumentNullException("marca");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "exec INCLUIR_MARCA @nome, @descricao";

                command.Parameters.AddWithValue("nome", marca.Nome); 
                command.Parameters.AddWithValue("descricao",((object) marca.Descricao )?? DBNull.Value); 

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
        public HttpResponseMessage Excluir(Marca marca)
        {
            try
            {
                bool res = false; 
                
                if (marca == null)
                {
                    throw new ArgumentNullException("marca");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC EXCLUIR_MARCA @ID";
                 
                command.Parameters.AddWithValue("id", marca.Id);

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
        public HttpResponseMessage Alterar(Marca marca)
        {
            try
            {
                bool res = false;

                if (marca == null)
                {
                    throw new ArgumentNullException("marca");
                }

                Conexao cx = new Conexao();
                cx.ConectarBase();
                SqlCommand command = new SqlCommand();
                command.Connection = cx.connection;
                command.CommandText = "EXEC ALTERAR_MARCA @ID, @NOME, DESCRICAO";

                command.Parameters.AddWithValue("id", marca.Id);
                command.Parameters.AddWithValue("Nome", ((object) marca.Nome ?? DBNull.Value));
                command.Parameters.AddWithValue("Descricao", ((object)marca.Descricao ?? DBNull.Value));

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












        /******** Leitura ***********/
        [HttpGet]
        [Route("Buscar")]
        public HttpResponseMessage Buscar(string busca)
        { //EXEC LEITURA_MARCA ''
            try
            {

                List<Marca> listaMarca = new List<Marca>();
                Conexao con = new Conexao();
                con.ConectarBase();

                SqlCommand command = new SqlCommand();
                command.Connection = con.connection;
                command.CommandText = "exec LEITURA_MARCA @busca";
                command.Parameters.AddWithValue("busca", busca);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Marca marca = new Marca()
                    {
                        Id = reader["id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                        Nome = reader["nome"] == DBNull.Value ? string.Empty : reader["nome"].ToString(),
                        Descricao = reader["Descricao"] == DBNull.Value ? string.Empty : reader["Descricao"].ToString()
                    };
                    listaMarca.Add(marca);
                }

                con.DesconectarBase();
                return Request.CreateResponse(HttpStatusCode.OK, listaMarca.ToArray());
            }
            catch (Exception ex)
            { 
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }






    }
}
