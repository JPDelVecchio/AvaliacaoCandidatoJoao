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
        public int Id_Cliente { get; set; }
        public int id_Veiculo { get; set; }
        public double Valor { get; set; } 
        public DateTime DataServico { get; set; }
            
    }
}