using System;
using System.Collections.Generic;
using System.Text;

namespace FGCore.Dominio
{
    public class Partida
    {
        public TimePonto TimeUm { get; set; }
        public TimePonto TimeDois { get; set; }
        public int  GolTimeUm { get; set; }
        public int GolTimeDois { get; set; }
        Random rnd = new Random();

        public Partida(TimePonto TimeUmm,TimePonto TimeDois)
        {
            this.TimeUm = TimeUmm;
            this.TimeDois = TimeDois;
            GolTimeUm = rnd.Next(1, 5);
            GolTimeDois = rnd.Next(1, 5);
            if (GolTimeUm > GolTimeDois) {
                TimeUm.Ponto += 3;
            }else if (GolTimeUm < GolTimeDois)
            {
                TimeDois.Ponto += 3;

            }
            else
            {
                TimeUm.Ponto += 1;
                TimeDois.Ponto += 1;
            }
        }
    }
}
