using System;
using System.Collections.Generic;
using System.Text;

namespace FGCore.Dominio
{
    public class ManipulaObj
    {
        public Object objetoCampeonato(Campeonato campeonato)
        {
            Object objetoRetorno = new
            {
                Partidas = arrayPartidas(campeonato),
                campeao = campeonato.Campeao,
                vice = campeonato.Vice,
                terceiro = campeonato.Terceiro
            };
            return objetoRetorno;
        }
        private Object arrayPartidas(Campeonato campeonato)
        {
            List<Object> obj = new List<Object>();
            foreach(var elemento in campeonato.Partidas)
            {
                obj.Add(new {
                    times = elemento.TimeUm.Time.Nome + " x " + elemento.TimeDois.Time.Nome,
                    resultado = elemento.GolTimeUm.ToString() + " x " + elemento.GolTimeDois.ToString()
                });
            }
            return obj;
        }

    }

   
}
