using CapaLogica;
using CapaLogica.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacionWeb
{
    public partial class AgregaMaterial : System.Web.UI.Page
    {
        LN bl = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) //Si es la primera ves que carga la aplicación
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new LN(cdn);
                Session["bl"] = bl;
                cargarTipoMaterial();
            }
            else //Si viene de un postBack
            {

                bl = (LN)Session["bl"];
            }
        }

        private void cargarTipoMaterial()
        {
            List<TipoMaterial> listRecibe = null;
            string msg = "";
            listRecibe = bl.getTiposMaterial(ref msg);

            if (listRecibe != null)
            {
                dropTipoM.Items.Clear();
                foreach (TipoMaterial item in listRecibe)
                {
                    dropTipoM.Items.Add(new ListItem(item.tipo, item.ID_Tipo.ToString()));
                }
                //dropMarcas.Items.Add(new ListItem("Selecciona una marca", "0",));

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string resp = "";
            Boolean recibe = false;
            int tipoMarca = Convert.ToInt32(ViewState["tipoMat"]);

            recibe = bl.InsertarMaterial(txtDesc.Text, txtMarca.Text, txtPresentacion.Text, tipoMarca);


            if (recibe)
            {
                TextBox1.Text = "Se agrego Material";
                txtDesc.Text = "";
                txtMarca.Text = "";
                txtPresentacion.Text = "";
                ViewState["tipoMat"] = (int)0;
            }
        }

        protected void dropMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["tipoMat"] = dropTipoM.SelectedValue.ToString();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}