using System;
using SGBF.Controllers;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SGBF.Helpers
{
    public class JogadorHelper
    {
        public static void populate(CheckBoxList element, int id_equipe)
        {           
            element.DataSource = controller().find_by_equipe(id_equipe);
            element.AppendDataBoundItems = true;
            element.DataTextField = "nome";
            element.DataValueField = "id";
            element.DataBind();
      
        }

        private static JogadorController controller()
        {
            return new JogadorController();
        }
    }
}