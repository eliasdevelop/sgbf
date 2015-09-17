using System;
using SGBF.Controllers;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SGBF.Helpers
{
    public class EquipeHelper
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

        private static EquipeController controller()
        {
            return new EquipeController();
        }

        public static Equipe search(String id_equipe)
        {
            int id = Int32.Parse(id_equipe);
            return controller().edit(id);
        }
    }
}