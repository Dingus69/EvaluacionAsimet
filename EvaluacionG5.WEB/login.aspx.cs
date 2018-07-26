using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;
using System.Net;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.WEB
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Page.IsPostBack))
                {
                    Session["SessionUsuario"] = null;
                    if (Request["Rut"] != null)
                    {
                        IngresarNonSecure(Utiles.ConvertToInt64(Request["Rut"]));
                    }
                }
            }
            catch (Exception ex)
            {
                Log objLog = new Log();
                objLog.EscribirLog(ex);
            }
        }
        protected void ingresar()
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                {
                    bodyLogin.Attributes.Add("onload", "alert('" + (String)GetGlobalResourceObject("etiquetas", "_alertUsuarioNoValido") + "');");
                    return;
                }
                if (string.IsNullOrEmpty(txtClave.Text))
                {
                    bodyLogin.Attributes.Add("onload", "alert('" + (String)GetGlobalResourceObject("etiquetas", "_alertClaveNoValida") + "');");
                    return;
                }
                if (!(Utiles.ValidarRut(txtUsuario.Text.Trim())))
                {
                    bodyLogin.Attributes.Add("onload", "alert('" + (String)GetGlobalResourceObject("etiquetas", "_alertRutNoValido") + "');");
                    return;
                }
                long Rut = Utiles.RutUsrALng(this.txtUsuario.Text);
                string Passwd = Utiles.ConvertToString(this.txtClave.Text);
                BFSESSIONUSUARIO objBFSesionUsuario = new BFSESSIONUSUARIO();
                ESESSIONUSUARIO objSesionUsuario = new ESESSIONUSUARIO();
                objSesionUsuario = objBFSesionUsuario.GetSESSIONUSUARIO(Rut, Passwd);
                if (objSesionUsuario.RutUsuario == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('" + (String)GetGlobalResourceObject("etiquetas", "_alertDatosNoValidos") + "');", true);
                    return;
                }
                else
                {
                    Session["SessionUsuario"] = objSesionUsuario;
                    Session.Timeout = 1000;
                    if ((objSesionUsuario.EsAdministrador) || (objSesionUsuario.EsGestion))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "document.location.href='modulos/evaluacion/dashboard.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "document.location.href='modulos/evaluacion/dashboard.aspx';", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Log objLog = new Log();
                objLog.EscribirLog(ex);
            }
        }
        protected void lnkCambioClave_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp", "Menu('2');", true);
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresar();
        }
        protected void IngresarNonSecure(Int64 Rut)
        {
            try
            {
                BFSESSIONUSUARIO objBFSesionUsuario = new BFSESSIONUSUARIO();
                ESESSIONUSUARIO objSesionUsuario = new ESESSIONUSUARIO();
                objSesionUsuario = objBFSesionUsuario.GetSESSIONUSUARIONONSECURE(Rut);
                if (objSesionUsuario.RutUsuario == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('" + (String)GetGlobalResourceObject("alertas", "_alertDatosNoValidos") + "');", true);
                    return;
                }
                else
                {
                    Session["SessionUsuario"] = objSesionUsuario;
                    Session.Timeout = 1000;
                    if ((objSesionUsuario.EsAdministrador) || (objSesionUsuario.EsGestion))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "document.location.href='modulos/evaluacion/dashboard.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "document.location.href='modulos/evaluacion/dashboard.aspx';", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Log objLog = new Log();
                objLog.EscribirLog(ex);
            }
        }

        protected void lnkOlvidasteContrasena_Click(object sender, EventArgs e)
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory + "include\\images\\captcha";
            string[] imagenes = System.IO.Directory.GetFiles(strPath);
            Random rnd = new Random();
            char separador = '\\';
            string[] arrTmp = imagenes[rnd.Next(0, (imagenes.Length - 1))].Split(separador);
            string NombreImagen = arrTmp[arrTmp.Length - 1];
            this.imgCaptcha.ImageUrl = Page.ResolveUrl("~/include/images/captcha/" + NombreImagen); ;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {

            if (this.txtRut.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('ATENCION: Debe ingresar el Rut del usuario');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
                return;
            }
            if (Utiles.ValidarRut(this.txtRut.Text) != true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('ATENCION: El Rut ingresado no es valido');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
                return;
            }
            if (this.txtCaptcha.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('ATENCION: Debe ingresar el texto de la imagen');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
                return;
            }
            BFUSUARIO objBFUS = new BFUSUARIO();
            EUSUARIO objUS = objBFUS.GetUSUARIO(Utiles.RutUsrALng(this.txtRut.Text));
            if (objUS.RUTUSUARIO != Utiles.RutUsrALng(this.txtRut.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('ATENCION: El Rut ingresado no se encuentra registrado en el sistema');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
                return;
            }

            char separador = '/';
            string[] arrTmp = imgCaptcha.ImageUrl.Split(separador);
            separador = '.';
            string[] arrTmp2 = arrTmp[arrTmp.Length - 1].Split(separador);
            string strcaptcha = arrTmp2[0];

            if (this.txtCaptcha.Text == strcaptcha)
            {
                string Asunto = "Recuperación de contraseña";
                string Body = "Estimado " + objUS.NOMBRECOMPLETO + "<br /><br />Tus datos de acceso a la plataforma de evaluación del desempeño son:<br /><br />Usuario: " + objUS.RUTCOMPLETO + "<br />Clave: " + CCryptografia.Desencriptar(objUS.PASSWORD) + "<br /><br />Saludos cordiales.";
                 
                BFPARAMETROSGENERALES objBFPA = new BFPARAMETROSGENERALES();
                EPARAMETROSGENERALES objPA = objBFPA.GetPARAMETROSGENERALESAll()[0];
                Utiles.EnviarCorreo(objPA.DOMINIO, objPA.SMTP, objPA.EMAIL, objPA.PASSWORD, objPA.PUERTO, objUS.EMAIL, Asunto, Body);
                this.txtRut.Text = "";
                this.txtCaptcha.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('ATENCION: La contraseña ha sido enviada a su correo');", true);
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('ATENCION: El dato ingresado no coincide con el captcha');", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
        }
    }
}