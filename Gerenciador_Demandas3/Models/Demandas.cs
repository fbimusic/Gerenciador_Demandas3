using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_Demandas3.Models
{
    public class Demandas
    {
        public int DemandasId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public string Importancia { get; set; }
    }
}
