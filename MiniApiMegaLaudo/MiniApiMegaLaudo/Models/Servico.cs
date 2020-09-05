using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniApiMegaLaudo.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Id_cliente { get; set; }
        public int Id_veiculo { get; set; }
        public decimal Valor { get; set; }
    }
}