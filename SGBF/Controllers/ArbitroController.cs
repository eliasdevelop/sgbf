using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class ArbitroController : ApplicationController
    {
        public List<Arbitro> index()
        {
            var con = db();

            return con.Arbitro.ToList();
        }

        public bool create(String nome, int idade)
        {
            var con = db();

            Arbitro arbitro = new Arbitro();
            arbitro.nome = nome;
            arbitro.idade = idade;
            
            con.Arbitro.Add(arbitro);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Arbitro edit(int id)
        {
            var con = db();

            return con.Arbitro.Find(id);
        }

        public bool update(int id, String nome, int idade)
        {
            var con = db();

            Arbitro arbitro = con.Arbitro.Find(id);
            arbitro.nome = nome;
            arbitro.idade = idade;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();

            Arbitro arbitro = con.Arbitro.Find(id);
            con.Arbitro.Remove(arbitro);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }
    }
}