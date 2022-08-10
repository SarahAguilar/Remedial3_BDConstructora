using CapaLogica;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacionWeb
{
    public partial class VerObras : System.Web.UI.Page
    {
        LN bl = null;
        int idDueno = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) //Si es la primera ves que carga la aplicación
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new LN(cdn);
                Session["bl"] = bl;
                idDueno = Convert.ToInt32(Session["idDueno"]);
                duenio.Text = idDueno.ToString();
                cargarObrasById(idDueno);
                
            }
            else //Si viene de un postBack
            {

                bl = (LN)Session["bl"];
            }
        }


        private void cargarObrasById(int id)
        {
            string msg = "";
            GridView1.DataSource = bl.getObraByDuenoDataSet( ref msg, id);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}