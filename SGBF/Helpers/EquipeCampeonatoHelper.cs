using System;
using SGBF.Controllers;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SGBF.Helpers
{
    public class EquipeCampeonatoHelper
    {
        private static EquipeCampeonatoController controller()
        {
            return new EquipeCampeonatoController();
        }

        public static void addPontuacao(int id_equipe, int id_campeonato, int pontuacao)
        {
             controller().update(id_equipe, id_campeonato, pontuacao);
        }
    }
}