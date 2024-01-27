using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAplicacion.Servicios.Models;

namespace WebAplicacion
{
    public partial class pagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            servicioAutenticar oservicioAutenticar = new servicioAutenticar();
            usuarioLogin ousuarioLogin = oservicioAutenticar.RecuperaToken(TextBox1.Text.ToString(), TextBox2.Text.ToString());

            if (ousuarioLogin.token != null )
            {
                Session.Add("ousuarioLogin", ousuarioLogin);
                Response.Redirect("./wfStock.aspx");
            }
        }
    }
}