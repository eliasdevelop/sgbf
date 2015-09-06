using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class CampeonatoController : ApplicationController
    {
        public List<Campeonato> index()
        {
            var con = db();

            return con.Campeonato.ToList();
        }

        public bool create(String nome, String divisao)
        {
            var con = db();

            Campeonato campeonato = new Campeonato();
            campeonato.nome = nome;
            campeonato.divisao = divisao;

            con.Campeonato.Add(campeonato);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Campeonato edit(int id)
        {
            var con = db();

            return con.Campeonato.Find(id);
        }

        public bool update(int id, String nome, String divisao)
        {
            var con = db();

            Campeonato campeonato = con.Campeonato.Find(id);
            campeonato.nome = nome;
            campeonato.divisao = divisao;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();

            Campeonato campeonato = con.Campeonato.Find(id);
            con.Campeonato.Remove(campeonato);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}