using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webAplicacion.Servicios;
using WebAplicacion.Servicios.Models;

namespace WebAplicacion
{
    public partial class CU_ListaStock : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarGrid();
            }
            void CargarGrid()
            {
                servicioRol oservicioStock = new servicioRol();
                rgvListaStock.DataSource = oservicioStock.GetList(((usuarioLogin)Session["ousuarioLogin"]).token);
                rgvListaStock.DataBind();
            }
        }
    }
}