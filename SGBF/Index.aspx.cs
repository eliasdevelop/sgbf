using System;
using SGBF.Controllers;
using System.Collections.Generic;
using System.Linq;
using SGBF.Models;
using SGBF.Helpers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SGBF
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CampeonatoHelper.populate(campeonato);
        }

        protected void loadTabela(object sender, EventArgs e)
        {
            int idCampeonato = Int32.Parse(campeonato.Text);

            TabelaList.DataSource = controller().find_by(idCampeonato);
            TabelaList.DataBind();

        }

        private EquipeCampeonatoController controller()
        {
            return new EquipeCampeonatoController();
        }
    }
}