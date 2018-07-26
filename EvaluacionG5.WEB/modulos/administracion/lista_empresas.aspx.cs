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
    public partial class lista_empresas : System.Web.UI.Page
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
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litError.Visible = false;
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litError.Visible = false;
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Consultar();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: El Rut ingresado no es valido.');", true);
            }
        }

        private void Consultar()
        {
            try
            {
                BFEMPRESA objBFEM = new BFEMPRESA();
                List<EEMPRESA> lst = objBFEM.GetEmpresasByRutOrName(Utiles.RutUsrALng(txtRut.Text), txtNombre.Text.Trim());
                objWEB.LlenaGrilla(ref this.grdResultados, lst.Cast<DomainObject>().ToList(), 20);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litError.Visible = false;
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        private bool ValidarDatos()
        {
            if (this.txtRut.Text.Trim() != "")
            {
                return Utiles.ValidarRut(this.txtRut.Text.Trim());
            }
            else
            {
                return true;
            }
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["Modo"] = "Actualizar";
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

                txtRutMant.Text = ((Label)fila.FindControl("lblRut")).Text;
                txtNomFantMant.Text = ((Label)fila.FindControl("lblNombreFantasia")).Text;
                txtRazSocMant.Text = ((Label)fila.FindControl("lblRazonSocial")).Text;
                txtNomContMant.Text = ((HiddenField)fila.FindControl("hdfNombreContacto")).Value;
                txtCarContMant.Text = ((HiddenField)fila.FindControl("hdfCargoContacto")).Value;
                txtFonContMant.Text = ((HiddenField)fila.FindControl("hdfFonoContacto")).Value;
                txtEmaContMant.Text = ((HiddenField)fila.FindControl("hdfEmailContacto")).Value;
                txtGirMant.Text = ((HiddenField)fila.FindControl("hdfGiro")).Value;
                chkActMant.Checked = Utiles.ConvertToBoolean(((HiddenField)fila.FindControl("hdfFlagActivo")).Value);
                txtConMant.Text = "";
                textRepContmant.Text = "";

                txtRutMant.ReadOnly = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litError.Visible = false;
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string strArchivo = fulLogo.FileName;
            string strExtension = strArchivo.Substring(strArchivo.LastIndexOf(".") + 1);
            //if (!(strExtension.ToUpper() == "XLS"))
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: Debe seleccionar un archivo (XLS).');", true);
            //    return;
            //}

            string strRuta = "";
            strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "include\\logos_empresas\\" + Utiles.RutUsrALng(txtRutMant.Text.Trim()) + "." + strExtension;
            if (System.IO.File.Exists(strRuta))
            {
                System.IO.File.Delete(strRuta);
            }
            this.fulLogo.SaveAs(strRuta);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('2');", true);
        }

        protected void btnContinuarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosMant())
                {
                    Guardar();
                }
                else
                {
                    litError.Visible = true;
                    litCatchError.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litError.Visible = false;
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        private bool ValidarDatosMant()
        {
            if ((txtRutMant.Text.Trim() == "") || (txtNomFantMant.Text.Trim() == "") || (txtConMant.Text.Trim() == "") || (textRepContmant.Text.Trim() == ""))
            {
                litError.Text = "ATENCION: Debe ingresar al menos el Rut, Nombre de Fantasia y Contraseña.";
                return false;
            }
            if (Utiles.ValidarRut(txtRutMant.Text.Trim()) == false)
            {
                litError.Text = "ATENCION: El Rut ingresado no es valido.";
                return false;
            }
            if (txtConMant.Text.Trim() != textRepContmant.Text.Trim())
            {
                litError.Text = "ATENCION: Las contraseñas ingresadas no coinciden";
                return false;
            }
            return true;
        }

        private void Guardar()
        {
            try
            {
                EEMPRESA objEM = new EEMPRESA();
                EUSUARIO objUS = new EUSUARIO();
                EPERFILUSUARIO objPU = new EPERFILUSUARIO();

                objEM.RUTEMPRESA = Utiles.RutUsrALng(txtRutMant.Text.Trim());
                objEM.NOMBREFANTASIA = txtNomFantMant.Text.Trim();
                objEM.RAZONSOCIAL = txtRazSocMant.Text.Trim();
                objEM.NOMBRE_CONTACTO = txtNomContMant.Text.Trim();
                objEM.CARGO_CONTACTO = txtCarContMant.Text.Trim();
                objEM.FONO_CONTACTO = txtFonContMant.Text.Trim();
                objEM.EMAIL_CONTACTO = txtEmaContMant.Text.Trim();
                objEM.GIRO = txtGirMant.Text.Trim();
                objEM.FLAG_ACTIVO = Utiles.ConvertToBoolean(chkActMant.Checked);

                objUS.RUTUSUARIO = Utiles.RutUsrALng(txtRutMant.Text.Trim());
                objUS.NOMBREUSUARIO = txtNomFantMant.Text.Trim();
                objUS.EMAIL = txtEmaContMant.Text.Trim();
                objUS.FLAGACTIVO = Utiles.ConvertToBoolean(chkActMant.Checked);
                objUS.PASSWORD = CCryptografia.Encriptar(txtConMant.Text.Trim());

                objPU.RUTUSUARIO = Utiles.RutUsrALng(txtRutMant.Text.Trim());
                objPU.CODPERFIL = 1;

                if (ViewState["Modo"].ToString() == "Actualizar")
                {
                    objEM.IsPersisted = true;
                    objUS.IsPersisted = true;
                    objPU.IsPersisted = true;
                }
                BFEMPRESA objBFEM = new BFEMPRESA();
                BFUSUARIO objBFUS = new BFUSUARIO();
                BFPERFILUSUARIO objBFPU = new BFPERFILUSUARIO();
                objBFEM.Save(objEM);
                objBFUS.Save(objUS);
                objBFPU.Save(objPU);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);




            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litError.Visible = false;
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ViewState["Modo"] = "Insertar";
            txtRutMant.Text = "";
            txtNomFantMant.Text = "";
            txtRazSocMant.Text = "";
            txtNomContMant.Text = "";
            txtCarContMant.Text = "";
            txtFonContMant.Text = "";
            txtEmaContMant.Text = "";
            txtGirMant.Text = "";
            chkActMant.Checked = false;
            txtConMant.Text = "";
            textRepContmant.Text = "";

            txtRutMant.ReadOnly = false;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
        }
    }
}