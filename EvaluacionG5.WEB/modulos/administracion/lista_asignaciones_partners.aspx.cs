using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.WEB.modulos.administracion
{
    public partial class lista_asignaciones_partners : System.Web.UI.Page
    {
        ESESSIONUSUARIO objSession;
        UtilesWEB objWEB = new UtilesWEB();

        private void ValidaSession()
        {
            if (objWEB.CheckeaSessionUsuario())
            {
                objSession = objWEB.CargaSessionUsuario();
                if (!objSession.EsAdministrador)
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
            try
            {
                ValidaSession();
                if (!Page.IsPostBack)
                {
                    InicializarFormulario();
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }
        protected void InicializarFormulario()
        {
            try
            {
                this.txtInicio.Text = "01/01/" + DateTime.Now.Year;
                this.txtFin.Text = "31/12/" + DateTime.Now.Year;
                BFINSTRUMENTO objIN = new BFINSTRUMENTO();
                objWEB.LlenaDDL(ref ddlInstrumentos, objIN.GetINSTRUMENTOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODINSTRUMENTO", "NOMBREINSTRUMENTO");

                BFTIPOEVALUACION objBFTE = new BFTIPOEVALUACION();
                objWEB.LlenaDDL(ref ddlDireccion, objBFTE.GetTIPOEVALUACIONAll().Cast<DomainObject>().ToList(), "CODTIPOEVAL", "NOMTIPOEVAL");

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                objWEB.LlenaGrilladt(ref this.grdResultados, objBFIE.BuscarAsignacionesPartners(Utiles.ConvertToDecimal(ddlInstrumentos.SelectedValue), Utiles.ConvertToString(txtNombre.Text), Utiles.ConvertToDateTime(txtInicio.Text), Utiles.ConvertToDateTime(txtFin.Text), Utiles.ConvertToInt16(this.ddlDireccion.SelectedValue), objSession.RutEmpresa), 20);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

                string CodInstrumento = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodInstrumento")).Value);
                string Nombre = Utiles.ConvertToString(((Label)fila.FindControl("lblNombre")).Text);
                string Inicio = Utiles.ConvertToString(((Label)fila.FindControl("lblInicio")).Text);
                string Fin = Utiles.ConvertToString(((Label)fila.FindControl("lblFin")).Text);
                string CodTipoEval = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodTipoEval")).Value);


                string strRuta = HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace("lista_asignaciones_partners.aspx", "asignacion_pares.aspx");
                strRuta = strRuta + "?CodInstrumento=" + CodInstrumento + "&Nombre=" + Nombre + "&Inicio=" + Inicio + "&Fin=" + Fin + "&Tipo=" + CodTipoEval;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string strRuta = HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace("lista_asignaciones_partners.aspx", "asignacion_pares.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnContinuarGuardar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }
    }
}



