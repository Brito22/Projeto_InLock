using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogosDomain
    {
        public int idJogo { get; set; }
        public string nomeJogo { get; set; }
        public string descrição { get; set; }

        public int idEstudio { get; set; }
        //public  int idEstudio { get; set; }
        public EstudioDomain estudio { get; set; }
        public DateTime dataLançamento { get; set; }
        public decimal Valor { get; set; }
    }
}
