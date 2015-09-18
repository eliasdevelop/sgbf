using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class EquipeCampeonatoController : ApplicationController
    {
        public List<Equipe_Campeonato> index()
        {
            var con = db();

            return con.Equipe_Campeonato.ToList();
        }

        public List<Equipe_Campeonato> find_by(int id_campeonato)
        {
            var con = db();

            return con.Equipe_Campeonato.Where(Equipe_Campeonato => Equipe_Campeonato.id_campeonato == id_campeonato).ToList();
        }

        public bool create(int id_equipe, int id_campeonato)
        {
            var con = db();
            int rows = 0;

            try
            {
                Equipe_Campeonato equipe_camp = new Equipe_Campeonato();
                equipe_camp.id_equipe = id_equipe;
                equipe_camp.id_campeonato = id_campeonato;
                equipe_camp.num_pontuacao = 0;

                con.Equipe_Campeonato.Add(equipe_camp);

                rows = con.SaveChanges();

                return rows.Equals(1);
            }
            catch (Exception)
            {
                
            }
            return rows.Equals(1);
        }

        public bool delete(int id_campeonato, int id_equipe)
        {
            var con = db();

            Equipe_Campeonato equipe_camp = con.Equipe_Campeonato.Find(id_campeonato, id_equipe);
            con.Equipe_Campeonato.Remove(equipe_camp);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}