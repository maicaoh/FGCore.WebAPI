using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace FGCore.Dominio
{
    public class Campeonato
    {
        public List<TimePonto> Times { get; set; }
        public List<Partida> Partidas { get; set; }
        public String Campeao { get; set; }
        public String Vice { get; set; }
        public String Terceiro { get; set; }
        
 
        public Campeonato gerarCampeonato(List<TimePonto> time)
        {
            List<Partida> partid = new List<Partida>();
            for(int i =0;i<time.Count;i++)
            {
                for (int j = i+1; j < time.Count; j++)
                {
                    partid.Add(new Partida(time[i], time[j]));
                }
            }
            classificacao(time);
            Campeonato campeonato = new Campeonato() { Partidas=partid,Campeao=Campeao,Vice=Vice,Terceiro=Terceiro }; 
            return campeonato; 
        }

        private void classificacao(List<TimePonto> time)
        {
            List<TimePonto> classific = time.OrderByDescending(elemento => elemento.Ponto).ToList();
            Campeao = classific[0].Time.Nome;
            Vice = classific[1].Time.Nome;
            Terceiro = classific[2].Time.Nome;
        }






    }
}
