using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public class EstadioController : ApplicationController
    {
        public List<Estadio> index()
        {
            var con = db();

            return con.Estadio.ToList();
        }

        public bool create(String nome, int capacidade, String cidade)
        {
            var con = db();

            Estadio estadio = new Estadio();
            estadio.nome = nome;
            estadio.capacidade = capacidade;
            estadio.cidade = cidade;

            con.Estadio.Add(estadio);

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public Estadio edit(int id)
        {
            var con = db();

            return con.Estadio.Find(id);
        }

        public bool update(int id, String nome, int capacidade, String cidade)
        {
            var con = db();

            Estadio estadio = con.Estadio.Find(id);
            estadio.nome = nome;
            estadio.capacidade = capacidade;
            estadio.cidade = cidade;

            int rows = con.SaveChanges();

            return rows.Equals(1);
        }

        public bool delete(int id)
        {
            var con = db();
            int rows = 0;
            try
            {
                Estadio estadio = con.Estadio.Find(id);
                con.Estadio.Remove(estadio);

                rows = con.SaveChanges();

                return rows.Equals(1);
            }
            catch (Exception ex)
            { 

            }

            return rows.Equals(1);
        }
    }
}