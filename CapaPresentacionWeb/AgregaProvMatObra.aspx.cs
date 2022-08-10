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
    public partial class AgregaProvMatObra : System.Web.UI.Page
    {
        LN bl = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) //Si es la primera ves que carga la aplicación
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new LN(cdn);
                Session["bl"] = bl;
                cargarMaterial();
                cargaProve();
                cargarObra();
            }
            else //Si viene de un postBack
            {

                bl = (LN)Session["bl"];
            }
        }

        private void cargarMaterial()
        {
            List<Material> listRecibe = null;
            string msg = "";
            listRecibe = bl.getMaterial(ref msg);

            if (listRecibe != null)
            {
                dropMaterial.Items.Clear();
                foreach (Material item in listRecibe)
                {
                    dropMaterial.Items.Add(new ListItem(item.desc, item.idMAterial.ToString()));
                }
                //dropMarcas.Items.Add(new ListItem("Selecciona una marca", "0",));

            }
        }
        private void cargarObra()
        {
            List<Obra> listRecibe = null;
            string msg = "";
            listRecibe = bl.getObra(ref msg);

            if (listRecibe != null)
            {
                dropObra.Items.Clear();
                foreach (Obra item in listRecibe)
                {
                    dropObra.Items.Add(new ListItem(item.obra, item.idObra.ToString()));
                }
                //dropMarcas.Items.Add(new ListItem("Selecciona una marca", "0",));

            }
        }
        
        private void cargaProve()
        {
            List<Proveedor> listRecibe = null;
            string msg = "";
            listRecibe = bl.getProveedor(ref msg);

            if (listRecibe != null)
            {
                dropProveedor.Items.Clear();
                foreach (Proveedor item in listRecibe)
                {
                    dropProveedor.Items.Add(new ListItem(item.proveedor, item.idProveedor.ToString()));
                }
                //dropMarcas.Items.Add(new ListItem("Selecciona una marca", "0",));

            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string resp = "";
            Boolean recibe = false;
            int obra = Convert.ToInt32(ViewState["obraId"]);
            int mat = Convert.ToInt32(ViewState["mat"]);
            int provee = Convert.ToInt32(ViewState["provee"]);
            float precio = float.Parse(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            recibe = bl.InsertarProveMatObra(txtRecibio.Text, txtEntrego.Text, cantidad,FechaEntrego.SelectedDate, precio, obra, mat, provee);

            if (recibe)
            {
                TextBox1.Text = "Se agrego registro";
                txtEntrego.Text = "";
                txtPrecio.Text = "";
                txtCantidad.Text = "";
                ViewState["obraId"] = (int)0;
                ViewState["mat"] = (int)0;
                ViewState["provee"] = (int)0;
            }
        }

        protected void dropObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["obraId"] = dropObra.SelectedValue.ToString();
        }

        protected void dropMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["mat"] = dropMaterial.SelectedValue.ToString();
        }

        protected void dropProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["provee"] = dropProveedor.SelectedValue.ToString();
        }

        protected void RegresarBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}