using System;
using SGBF.Controllers;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SGBF.Helpers
{
    public class EstadioHelper
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

        private static EstadioController controller()
        {
            return new EstadioController();
        }

        public static Estadio search(String id_estadio)
        {
            int id = Int32.Parse(id_estadio);
            return controller().edit(id);
        }
    }
}