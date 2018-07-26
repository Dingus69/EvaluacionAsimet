using System;
using System.Data;
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
    public partial class asignacion_pares : System.Web.UI.Page
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

        List<EEMPLEADO> lstEM = new List<EEMPLEADO>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ValidaSession();
                if (!Page.IsPostBack)
                {
                    InicializarFormulario();
                    if (Request["CodInstrumento"] != null)
                    {
                        Cargar();
                    }
                    else
                    {
                        ViewState["Modo"] = "Insertar";
                    }
                    litUsuariosNoEncontrados.Visible = false;
                    btnContinuarSi.Visible = false;
                    btnContinuarNo.Visible = false;
                    litAdvertencia.Visible = true;
                    btnContinuarGuardar.Visible = true;
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
                this.txtInicio.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                this.txtFin.Text = "31/12/" + DateTime.Now.Year;
                BFINSTRUMENTO objIN = new BFINSTRUMENTO();
                objWEB.LlenaDDL(ref ddlInstrumentos, objIN.GetINSTRUMENTOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODINSTRUMENTO", "NOMBREINSTRUMENTO");

                BFTIPOEVALUACION objBFTE = new BFTIPOEVALUACION();
                objWEB.LlenaDDL(ref ddlTipoEvaluacion, objBFTE.GetTIPOEVALUACIONAll().Cast<DomainObject>().ToList(), "CODTIPOEVAL", "NOMTIPOEVAL");


                ViewState["Asignaciones"] = lstEM;
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
                this.ddlInstrumentos.SelectedValue = Request["CodInstrumento"];
                this.txtNombre.Text = Request["Nombre"];
                this.txtInicio.Text = Request["Inicio"];
                this.txtFin.Text = Request["Fin"];
                this.txtInicio.Text = Request["Inicio"];
                this.txtFin.Text = Request["Fin"];
                this.ddlInstrumentos.Enabled = false;
                this.ddlTipoEvaluacion.SelectedValue = Request["Tipo"];
                this.ddlTipoEvaluacion.Enabled = false;
                this.txtNombre.Enabled = false;

                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                List<EINSTRUMENTOEMPLEADO> lstAsg = objBFIE.GetAsignaciones(ddlInstrumentos.SelectedValue, this.txtNombre.Text, Utiles.ConvertToDateTime(txtInicio.Text), Utiles.ConvertToDateTime(txtFin.Text), Utiles.ConvertToInt16(ddlTipoEvaluacion.SelectedValue));

                objWEB.LlenaGrilla(ref this.grdAsignaciones, lstAsg.Cast<DomainObject>().ToList(), 1000);
                ViewState["Modo"] = "Actualizar";

                if (this.grdAsignaciones.Rows.Count > 0)
                {
                    divActualizacion.Visible = true;
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

        protected void btnCargarPares_Click(object sender, EventArgs e)
        {
            try
            {
                string strArchivo = fulAsignaciones.FileName;
                string strExtension = strArchivo.Substring(strArchivo.LastIndexOf(".") + 1);
                if (!(strExtension.ToUpper() == "XLS"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: Debe seleccionar un archivo (XLS).');", true);
                    return;
                }

                string strRuta = "";
                strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "tmp\\carga_pares_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
                if (System.IO.File.Exists(strRuta))
                {
                    System.IO.File.Delete(strRuta);
                }
                this.fulAsignaciones.SaveAs(strRuta);

                BFINSTRUMENTOEMPLEADO objBFSE = new BFINSTRUMENTOEMPLEADO();
                //DataTable dt = objBFSE.AsignacionesPorExcel(strRuta);
                DataSet ds = objBFSE.AsignacionesPorExcel(strRuta, objSession.RutEmpresa);
                DataTable dt = ds.Tables[0];
                DataTable dtError = ds.Tables[1];
                objWEB.LlenaGrilladt(ref this.grdColaboradores, dt, 5000);
                string RutError = "";
                if (dtError.Rows.Count > 0)
                { 
                    foreach (DataRow dr in dtError.Rows)
                    {
                        RutError = RutError + dr["RUT"].ToString() + ", ";
                    }
                    RutError = RutError.Substring(0, RutError.Length - 2);
                    string Mensaje = "";
                    Mensaje = "Los siguientes Rut no existen en nuestros registros: \n" + RutError + " \n ¿Desea continuar?";

                    litUsuariosNoEncontrados.Visible = true;
                    btnContinuarSi.Visible = true;
                    btnContinuarNo.Visible = true;
                    litAdvertencia.Visible = false;
                    btnContinuarGuardar.Visible = false;

                    litUsuariosNoEncontrados.Text = Mensaje;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('2');", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "alert('" + Mensaje + "');", true);
                }

            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkEvaluar_Click(object sender, EventArgs e)
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

        protected void btnVolver_Click(object sender, EventArgs e)
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
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

        protected void grdAsignaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstado");
                    HiddenField hdfCodEstado = (HiddenField)e.Row.FindControl("hdfCodEstado");
                    BFESTADOINSTRUMENTO objBFEI = new BFESTADOINSTRUMENTO();
                    objWEB.LlenaDDL(ref ddlEstado, objBFEI.GetESTADOINSTRUMENTOAll().Cast<DomainObject>().ToList(), "CODESTADOEVAL", "NOMESTADOEVAL");
                    ddlEstado.SelectedValue = Utiles.ConvertToString(hdfCodEstado.Value);

                    ((Label)e.Row.FindControl("lblInicio")).Text = ((Label)e.Row.FindControl("lblInicio")).Text.Substring(0, 10);
                    ((Label)e.Row.FindControl("lblFin")).Text = ((Label)e.Row.FindControl("lblFin")).Text.Substring(0, 10);

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

        protected void btnContinuarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar();
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void Guardar()
        {
            try
            {
                BFINSTRUMENTO objBFIN = new BFINSTRUMENTO();
                EINSTRUMENTO objIN = objBFIN.GetINSTRUMENTOEMPRESA(Utiles.ConvertToInt64(this.ddlInstrumentos.SelectedValue), objSession.RutEmpresa);
                List<EEMPLEADO> lst = new List<EEMPLEADO>(); //= (List<EEMPLEADO>)ViewState["Empleados"];

                BFEMPLEADO objBFEM = new BFEMPLEADO();
                EEMPLEADO objEM;
                foreach (GridViewRow grdRow in this.grdColaboradores.Rows)
                {
                    objEM = objBFEM.GetEMPLEADO(Utiles.RutUsrALng(((Label)grdRow.FindControl("lblRut")).Text));
                    objEM.RUTJEFE = Utiles.RutUsrALng(((HiddenField)grdRow.FindControl("hdfRutEvaluador")).Value);
                    lst.Add(objEM);
                }

                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                objBFIE.AsignarPorTipo(objIN, lst, this.txtNombre.Text, Utiles.ConvertToDateTime(this.txtInicio.Text), Utiles.ConvertToDateTime(this.txtFin.Text), Utiles.ConvertToInt16(ddlTipoEvaluacion.SelectedValue));


                List<EINSTRUMENTOEMPLEADO> lstAsg = objBFIE.GetAsignaciones(ddlInstrumentos.SelectedValue, this.txtNombre.Text, Utiles.ConvertToDateTime(txtInicio.Text), Utiles.ConvertToDateTime(txtFin.Text), Utiles.ConvertToInt16(ddlTipoEvaluacion.SelectedValue));

                objWEB.LlenaGrilla(ref this.grdAsignaciones, lstAsg.Cast<DomainObject>().ToList(), 1000);
                ViewState["Modo"] = "Actualizar";
                if (this.grdAsignaciones.Rows.Count > 0)
                {
                    divActualizacion.Visible = true;
                }

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

        protected void btnAplicarFechas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow grdRow in this.grdAsignaciones.Rows)
                {
                    if (((CheckBox)grdRow.FindControl("chkSeleccionar")).Checked)
                    {
                        ((Label)grdRow.FindControl("lblInicio")).Text = this.txtActInicio.Text;
                        ((Label)grdRow.FindControl("lblFin")).Text = this.txtActFin.Text;
                    }
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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow grdRow in this.grdAsignaciones.Rows)
                {
                    if (((CheckBox)grdRow.FindControl("chkSeleccionar")).Checked)
                    {
                        BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                        EINSTRUMENTOEMPLEADO objIE = objBFIE.GetINSTRUMENTOEMPLEADO(Utiles.ConvertToInt64(((HiddenField)grdRow.FindControl("hdfCodInstrumentoEmpleado")).Value));
                        objIE.INICIOEVALUACION = Utiles.ConvertToDateTime(((Label)grdRow.FindControl("lblInicio")).Text);
                        objIE.FINEVALUACION = Utiles.ConvertToDateTime(((Label)grdRow.FindControl("lblFin")).Text);
                        objIE.CODESTADOEVAL = Utiles.ConvertToDecimal(((DropDownList)grdRow.FindControl("ddlEstado")).SelectedValue);
                        objIE.IsPersisted = true;
                        objBFIE.Save(objIE);
                    }
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

        protected void btnSeleccionTodos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow grdRow in this.grdAsignaciones.Rows)
                {
                    ((CheckBox)grdRow.FindControl("chkSeleccionar")).Checked = true;
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

        protected void btnDeseleccionarTodas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow grdRow in this.grdAsignaciones.Rows)
                {
                    ((CheckBox)grdRow.FindControl("chkSeleccionar")).Checked = false;
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

        protected void btnContinuarNo_Click(object sender, EventArgs e)
        {

        }

        protected void btnContinuarSi_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar();
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