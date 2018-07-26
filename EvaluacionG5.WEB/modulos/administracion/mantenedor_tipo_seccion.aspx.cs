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
    public partial class mantenedor_tipo_seccion : System.Web.UI.Page
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
                if (!(Page.IsPostBack))
                {
                    Cargar();
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

        protected void Cargar()
        {
            try
            {
                BFTIPOSECCION objBFTS = new BFTIPOSECCION();
                objWEB.LlenaGrilla(ref grdResultados, objBFTS.GetTIPOSECCIONAll().Cast<DomainObject>().ToList(), 20);
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
                this.txtCodTipoSeccion.Text = "";
                this.txtNombre.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
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
                this.txtCodTipoSeccion.Text = ((Label)fila.FindControl("lblCodigo")).Text;
                this.txtNombre.Text = ((Label)fila.FindControl("lblNombre")).Text;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                ViewState["Codigo"] = Utiles.ConvertToInt64(((Label)fila.FindControl("lblCodigo")).Text);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('2');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BFTIPOSECCION objBFTS = new BFTIPOSECCION();
                ETIPOSECCION objTS = new ETIPOSECCION();
                objTS.CODTIPOSECCION = Utiles.ConvertToInt16(this.txtCodTipoSeccion.Text);
                objTS.NOMBRETIPOSECCION = Utiles.ConvertToString(this.txtNombre.Text);
                objBFTS.Save(objTS);
                Cargar();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('Los datos han sido ingresados exitosamente.');", true);
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            this.txtCodTipoSeccion.Text = "";
            this.txtNombre.Text = "";
        }

        protected void btnContinuarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BFTIPOSECCION objBFTS = new BFTIPOSECCION();
                ETIPOSECCION objTS = objBFTS.GetTIPOSECCION(Utiles.ConvertToInt64(ViewState["Codigo"]));

                if ((objBFTS.PoseeDatosRelacionados(objTS.CODTIPOSECCION)))
                {
                    this.litErrorDatosRelacionados.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
                }
                else
                {
                    objBFTS.Delete(objTS);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('4');", true);
                }
                Cargar();
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