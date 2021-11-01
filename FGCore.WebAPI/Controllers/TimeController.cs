using FGCore.Dominio;
using FGCore.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FGCore.WebAPI.Controllers
{
    [ApiController]
    [Route("/api")]

    public class TimeController : ControllerBase
    {
        public readonly TimeContext _context;

        public TimeController(TimeContext context)
        {
            _context = context;
        }

        [HttpPost("Time")]
        public ActionResult Post([FromBody] Time time)
        {
            try
            {
              _context.Times.Add(time);
              _context.SaveChanges();
              return Ok("Cadastrado Com Sucesso!");
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
           
        }

        [HttpPut("Time/{id}")]
        public ActionResult Put(int id, [FromBody] Time equipe)
        {
            try
            {
                var time = new Time { Id = id, Nome = equipe.Nome };
                _context.Times.Update(time);
                _context.SaveChanges();
                return Ok("Atualizado Com Sucesso!");               
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpDelete("Time/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var time = _context.Times.Where(time => time.Id == id).FirstOrDefault();
                if (time == null)
                {
                    throw new Exception(message: "Equipe não Cadastrada!");
                }
                else
                {
                    _context.Times.Remove(time);
                    _context.SaveChanges();
                    return Ok("Excluido com Sucesso");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("Time/{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var time = _context.Times.Where(time => time.Id == id).FirstOrDefault(); if (time == null)
                {
                    throw new Exception(message: "Equipe não Cadastrada!");
                }
                else
                {
                    return Ok(time);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("Time")]
        public  ActionResult GetTimes([FromQuery(Name = "pagina")] int pagina, [FromQuery(Name = "tamanhoPagina")] int tamanhoPagina)
        {
            try
            {
                    int totalEquipes = _context.Times.ToList().Count;
                    var listEquipes = _context.Times.Skip((pagina * tamanhoPagina)).Take(tamanhoPagina).ToList();

                    var pagin = new Paginacao { Pagina = pagina, TamanhoPagina = tamanhoPagina, QtdPagina = (int)(Math.Ceiling((double)totalEquipes / tamanhoPagina)), Itens = listEquipes };
                    return Ok(pagin);
             
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet("Campeonato")]
        public ActionResult GetCampeonato()
        {
            try
            {

                var listEquipes = _context.Times.ToList();
                if(listEquipes.Count < 3)
                {
                    throw new Exception(message: "Equipes insuficientes para realizar campeonato!");

                }
                List<TimePonto> listEquipesPonto = new List<TimePonto>();
                foreach (Time equipe in listEquipes)
                {
                    listEquipesPonto.Add(new TimePonto(equipe));
                }

                var Campeonato = new Campeonato().gerarCampeonato(listEquipesPonto);
                var objFormatado = new ManipulaObj().objetoCampeonato(Campeonato);
                return Ok(objFormatado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
