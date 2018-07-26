using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.WEB.modulos.administracion
{ 
    public partial class carga_nomina : System.Web.UI.Page
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

        private List<EEMPLEADO> lstSeccion = new List<EEMPLEADO>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ValidaSession();
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnCargarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable _dtErroresCarga;
                _dtErroresCarga = new DataTable();
                _dtErroresCarga.Columns.Add("Rut");
                _dtErroresCarga.Columns.Add("Error");
                objWEB.LlenaGrilladt(ref this.grdDetalleErrores, _dtErroresCarga, 100);

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('2');", true);
                string strArchivo = fulUsuarios.FileName;
                string strExtension = strArchivo.Substring(strArchivo.LastIndexOf(".") + 1);
                if (!(strExtension.ToUpper() == "XLS"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: Debe seleccionar un archivo (XLS).');", true);
                    return;
                }

                string strRuta = "";
                strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "tmp\\carga_usuarios_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
                if (System.IO.File.Exists(strRuta))
                {
                    System.IO.File.Delete(strRuta);
                }
                this.fulUsuarios.SaveAs(strRuta);

                BFEMPLEADO objBFSE = new BFEMPLEADO();
                DataTable dt = objBFSE.GetEmpleadosExcel(strRuta, objSession.RutEmpresa);
                objWEB.LlenaGrilladt(ref this.grdResultados, dt, 100);
                objWEB.LlenaGrilladt(ref this.grdDetalleErrores, objBFSE.DtErroresCarga, 100);
                if (grdDetalleErrores.Rows.Count > 0)
                {
                    divErrores.Visible = true;
                }
                else
                {
                    divErrores.Visible = false;
                }
                ViewState["ListaSecciones"] = lstSeccion;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('4');", true);

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void grdResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        protected void btnContinuarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //string strArchivo = fulUsuarios.FileName;
                //string strExtension = strArchivo.Substring(strArchivo.LastIndexOf(".") + 1);
                //if (!(strExtension.ToUpper() == "XLS"))
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: Debe seleccionar un archivo (XLS).');", true);
                //    return;
                //}

                //string strRuta = "";
                //strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "tmp\\carga_usuarios_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
                //if (System.IO.File.Exists(strRuta))
                //{
                //    System.IO.File.Delete(strRuta);
                //}
                //this.fulUsuarios.SaveAs(strRuta);

                //BFEMPLEADO objBFSE = new BFEMPLEADO();
                //DataTable dt = objBFSE.GetEmpleadosExcel(strRuta);
                //objWEB.LlenaGrilladt(ref this.grdResultados, dt, 100);
                //ViewState["ListaSecciones"] = lstSeccion;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('4');", true);
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
            string strRuta = HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace("carga_nomina.aspx", "mantenedor_usuarios.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
        }
    }
}