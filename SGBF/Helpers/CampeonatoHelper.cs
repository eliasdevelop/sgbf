using System;
using SGBF.Controllers;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SGBF.Helpers
{
    public class CampeonatoHelper
    {
        public static void populate(DropDownList element)
        {
            if (element.Items.Count == 1)
            {
                element.DataSource = controller().index();
                element.AppendDataBoundItems = true;
                element.DataTextField = "nome";
                element.DataValueField = "id";
                element.DataBind();
            }
        }

        private static CampeonatoController controller()
        {
            return new CampeonatoController();
        }

        public static Campeonato search(String id_campeonato)
        {
            int id = Int32.Parse(id_campeonato);
            return controller().edit(id);
        }
    }
}