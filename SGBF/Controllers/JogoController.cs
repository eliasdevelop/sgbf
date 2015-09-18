using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class JogoController : ApplicationController
    {
        public List<Jogo> index()
        {
            var con = db();

            return con.Jogo.ToList();
        }

        public List<Jogo> find_by_campeonato(int id_campeonato)
        {
            var con = db();

            return con.Jogo.Where(Jogo => Jogo.id_campeonato == id_campeonato).ToList();
        }

        public bool create(int id_campeonato, int id_equipe_casa, int id_equipe_visitante, int id_arbitro)
        {
            var con = db();

            if(id_equipe_casa == id_equipe_visitante)
            {
                return false;
            }
            else
            {
                Jogo jogo = new Jogo();
                jogo.id_campeonato = id_campeonato;
                jogo.id_equipe_casa = id_equipe_casa;
                jogo.id_equipe_visitante = id_equipe_visitante;
                jogo.id_arbitro = id_arbitro;

                con.Jogo.Add(jogo);

                int rows = con.SaveChanges();

                return rows.Equals(1);
            }
        }

        public bool update(int id, int gols_casa, int gols_fora)
        {
            var con = db();

            Jogo jogo = con.Jogo.Find(id);
            jogo.num_gol_casa = gols_casa;
            jogo.num_gol_visitante = gols_fora;
           
            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Jogo edit(int id)
        {
            var con = db();

            return con.Jogo.Find(id);
        }

        public bool delete(int id)
        {
            var con = db();

            Jogo jogo = con.Jogo.Find(id);
            con.Jogo.Remove(jogo);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

    }
}