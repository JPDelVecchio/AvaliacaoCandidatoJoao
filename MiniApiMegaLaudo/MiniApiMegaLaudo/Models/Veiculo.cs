using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MiniApiMegaLaudo.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public int Id_marca { get; set; }
        public int Id_modelo { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
    }
}