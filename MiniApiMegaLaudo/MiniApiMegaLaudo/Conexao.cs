using System.Data.SqlClient; 
namespace MiniApiMegaLaudo
{
    public class Conexao
    {
        private static string ConnectionString = "Data Source=LAPTOP-7TSFR77V;User Id=sa;Password=sa;Initial Catalog=MEGALAUDO";
        public SqlConnection connection = new SqlConnection(ConnectionString);
        public void ConectarBase()
        {
            this.connection.Open();
        }
        public void DesconectarBase()
        {
            this.connection.Close();
        }
    }
}