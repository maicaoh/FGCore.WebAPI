using System;
using System.Collections.Generic;
using System.Text;

namespace FGCore.Dominio
{
    public class Paginacao
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int QtdPagina { get; set; }
        public List<Time> Itens { get; set; }
    }
}
