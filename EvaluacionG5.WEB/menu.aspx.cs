using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EvaluacionG5.COMMON;
using System.Web.UI.WebControls;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.WEB
{
    public partial class menu : System.Web.UI.Page
    {
        ESESSIONUSUARIO objSession;
        UtilesWEB objWEB = new UtilesWEB();

        private void ValidaSession()
        {
            if (objWEB.CheckeaSessionUsuario())
            {
                objSession = objWEB.CargaSessionUsuario(); 
                if ((!objSession.EsAdministrador) && (!objSession.EsGestion))
                {
                    string RutaHome = Page.ResolveUrl("~/modulos/evaluacion/dashboard.aspx?Acceso=No");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + RutaHome + "';", true);
                }
            }
            else
            {
                Response.Redirect("~/login.aspx?FinSesion=1");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidaSession();
            if (!Page.IsPostBack)
            {
                //if (objSession.EsAdministrador)
                //{
                //    itemAdmin.Visible = true;
                //}
                //else
                //{
                //    itemAdmin.Visible = false;
                //}
                //if (objSession.EsGestion)
                //{
                //    itemGestion.Visible = true;
                //}
                //else
                //{
                //    itemGestion.Visible = false;
                //}
            }
        }
    }
}