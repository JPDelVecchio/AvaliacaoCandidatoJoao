using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniApiMegaLaudo.Models
{
    public class Modelo
    {
        public int Id  { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }   
        public int Id_marca { get; set; }
    }
}