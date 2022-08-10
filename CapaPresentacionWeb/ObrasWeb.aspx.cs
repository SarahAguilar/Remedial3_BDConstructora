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
    public partial class ObrasWeb : System.Web.UI.Page
    {
        LN bl = null;
        //public LN bl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false) //Si es la primera ves que carga la aplicación
            {
                string cdn = ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString;
                bl = new CapaLogica.LN(cdn);
                Session["bl"] = bl;
                mostrarDueno();
                mostrarEncargado();
                
            }
            else //Si viene de un postBack
            {

                bl = (LN)Session["bl"];
            }
            
        }

        public void mostrarObra()
        {
            string msj = "";
            
        }
        public void mostrarDueno()
        {

            string msj = "";
            List<Dueno> listRecibe = null;
            string msg = "";
            listRecibe = bl.SelectDueno(ref msg);

            if (listRecibe != null)
            {
                DropDownList1.Items.Clear();
                foreach (Dueno item in listRecibe)
                {
                    DropDownList1.Items.Add(new ListItem(item.Nombre_Dueno, item.ID_Dueno.ToString()));
                }

            }
        }

        public void mostrarEncargado()
        {

            string msj = "";
            List<EncargadoObra> listRecibe = null;
            string msg = "";
            listRecibe = bl.SelectEncargado(ref msg);

            if (listRecibe != null)
            {
                DropDownList2.Items.Clear();
                foreach (EncargadoObra item in listRecibe)
                {
                    DropDownList2.Items.Add(new ListItem(item.Nom_Encargado, item.ID_Encargado.ToString()));
                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            EncargadoObra temp1 = new EncargadoObra();
            Dueno temp2 = new Dueno();
            Boolean recibe = false;
            string msj = "";
            string nombre = "", direccion = "";

          
            int dueño = 0, encargado = 0;


            nombre = TextBox1.Text;
            direccion = TextBox2.Text;
            dueño = Convert.ToInt16(ViewState["ID_Dueno"]);
            encargado = Convert.ToInt16(ViewState["ID_Encargado"]);



            recibe = bl.InsertarObra(nombre, direccion, fechaIni.SelectedDate, fechatermino.SelectedDate, dueño, encargado);
            if (recibe == true)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                ViewState["ID_Dueno"] = 0;
                ViewState["ID_Encargado"] = 0;
                TextBoxStatus.Text = "Nuevo registro agregado exitosamente";
            }
            else
            {
                TextBoxStatus.Text = "Error!, no se agrego el registro";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ID_Dueno"] = DropDownList1.SelectedValue.ToString();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ID_Encargado"] = DropDownList2.SelectedValue.ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}