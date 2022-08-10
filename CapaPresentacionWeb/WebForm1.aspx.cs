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
    public partial class WebForm1 : System.Web.UI.Page
    {

        LN bl = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) //Si es la primera ves que carga la aplicación
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new LN(cdn);
                Session["bl"] = bl;
                cargarMateriales();
                cargaProveeMateriObra();
                mostrarObra();
                cargaDueno();
            }
            else //Si viene de un postBack
            {

                bl = (LN)Session["bl"];
            }
        }

        private void cargarMateriales()
        {
            string msg = "";
            gridMaterial.DataSource = bl.getMaterialDataSet(ref msg);
            gridMaterial.DataBind();
        }

        public void mostrarObra()
        {
            string msj = "";
            griObras.DataSource = bl.VerObra(ref msj);
            griObras.DataBind();
        }

        private void cargarObrasByDuenos(int id)
        {
            string msg = "";
            GridView1.DataSource = bl.getObraByDuenoDataSet(ref msg, id);
            GridView1.DataBind();
        }
        
        private void cargaProveeMateriObra()
        {
            string msg = "";
            gridProvMatObra.DataSource = bl.getProvMatObraDataSet(ref msg);
            gridProvMatObra.DataBind();
        }

        protected void btnAgregaMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregaMaterial.aspx");
        }

        protected void gridProvMatObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["name"] = gridProvMatObra.SelectedRow.Cells[1].Text;
            Response.Redirect("ActualizaProvMatObra.aspx");
        }

        protected void btnAgregaProvMatObra_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregaProvMatObra.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idDueno"] = GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect("VerObras.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        private void cargaDueno()
        {
            List<Dueno> listRecibe = null;
            string msg = "";
            listRecibe = bl.SelectDueno(ref msg);

            if (listRecibe != null)
            {
                ListBox1.Items.Clear();
                foreach (Dueno item in listRecibe)
                {
                    ListBox1.Items.Add(new ListItem(item.Nombre_Dueno, item.ID_Dueno.ToString()));
                }
                //dropMarcas.Items.Add(new ListItem("Selecciona una marca", "0",));

            }
        }

        protected void griObras_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ID_Obra"] = griObras.SelectedRow.Cells[1].Text; //Se guarda el id del profe en una variable de sesion
            string resp = "";
            Boolean recibe = false;
            recibe = bl.BorrarObra(ViewState["ID_Obra"].ToString());

            if (recibe)
            {
                txtBorraObra.Text = "Se elimino exitosamente";
                mostrarObra();
            }
            else
            {
                txtBorraObra.Text = "ERROR! No se puede borrar ya que esta siendo utilizada.";
            }
        }

        protected void btnAddObra_Click(object sender, EventArgs e)
        {
            Response.Redirect("ObrasWeb.aspx");
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["idDuenio"] = ListBox1.SelectedValue.ToString();
            int id = Convert.ToInt32(ViewState["idDuenio"]);

            cargarObrasByDuenos(id);

        }
    }
}