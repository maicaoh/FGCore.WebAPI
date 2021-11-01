using System;
using System.Collections.Generic;
using System.Text;

namespace FGCore.Dominio
{
    public class TimePonto
    {
        public Time Time { get; set; }
        public int Ponto { get; set; }

        public TimePonto(Time time)
        {
            this.Time = time;
            Ponto = 0;
        }
       
    }
}
