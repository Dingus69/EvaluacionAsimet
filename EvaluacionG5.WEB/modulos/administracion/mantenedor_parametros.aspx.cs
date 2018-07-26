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
    public partial class mantenedor_parametros : System.Web.UI.Page
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
                BFPARAMETROSGENERALES objBFPG = new BFPARAMETROSGENERALES();
                EPARAMETROSGENERALES obj = objBFPG.GetPARAMETROSGENERALESAll()[0];
                this.txtDominio.Text = obj.DOMINIO;
                this.txtPuerto.Text = obj.PUERTO;
                this.txtUsuario.Text = obj.EMAIL;
                this.txtSMTP.Text = obj.SMTP;
                this.txtPassword.Text = obj.PASSWORD;
                this.txtNombreClasificador1.Text = obj.NOMBRE_CLASIFICADOR_1;
                this.txtNombreClasificador2.Text = obj.NOMBRE_CLASIFICADOR_2;
                this.txtUrlPlataforma.Text = obj.URL_PLATAFORMA;
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
                EPARAMETROSGENERALES obj = new EPARAMETROSGENERALES();
                obj.DOMINIO = Utiles.ConvertToString(this.txtDominio.Text);
                obj.PUERTO = Utiles.ConvertToString(this.txtPuerto.Text);
                obj.EMAIL = Utiles.ConvertToString(this.txtUsuario.Text);
                obj.PASSWORD = Utiles.ConvertToString(this.txtPassword.Text);
                obj.SMTP = Utiles.ConvertToString(this.txtSMTP.Text);
                obj.NOMBRE_CLASIFICADOR_1 = Utiles.ConvertToString(this.txtNombreClasificador1.Text);
                obj.NOMBRE_CLASIFICADOR_2 = Utiles.ConvertToString(this.txtNombreClasificador2.Text);
                obj.URL_PLATAFORMA = Utiles.ConvertToString(this.txtUrlPlataforma.Text);
                obj.IsPersisted = true;
                BFPARAMETROSGENERALES objBFPG = new BFPARAMETROSGENERALES();
                objBFPG.Save(obj);
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