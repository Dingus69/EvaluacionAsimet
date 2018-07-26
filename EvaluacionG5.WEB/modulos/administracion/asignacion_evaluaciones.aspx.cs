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
    public partial class asignacion_evaluaciones : System.Web.UI.Page
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
        List<EEMPLEADO> lstEMTmp = new List<EEMPLEADO>();
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
                        divActualizacion.Visible = true;
                    }
                    else
                    {
                        ViewState["Modo"] = "Insertar";
                    }
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

        protected void InicializarFormulario()
        {
            try
            {
                this.txtInicio.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                this.txtFin.Text = "31/12/" + DateTime.Now.Year;
                this.txtActInicio.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                this.txtActFin.Text = "31/12/" + DateTime.Now.Year;
                BFINSTRUMENTO objIN = new BFINSTRUMENTO();
                objWEB.LlenaDDL(ref ddlInstrumentos, objIN.GetINSTRUMENTOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODINSTRUMENTO", "NOMBREINSTRUMENTO");
                BFGRADO objGR = new BFGRADO();
                objWEB.LlenaDDL(ref ddlDireccion, objWEB.Direccion(), "valor", "texto");


                BFEMPRESA objBFEMP = new BFEMPRESA();
                objWEB.LlenaDDL(ref this.ddlEmpresa, objBFEMP.GetEMPRESAAll().Cast<DomainObject>().ToList(), "RUTEMPRESA", "NOMBREFANTASIA");
                objWEB.AgregaValorDDL(ref this.ddlEmpresa, "Sin Información", "0");
                this.ddlEmpresa.SelectedValue = "0";
                if (ddlEmpresa.Items.Count > 1)
                {
                    this.divEmpresa.Visible = true;
                }
                BFGERENCIA objBFEGE = new BFGERENCIA();
                objWEB.LlenaDDL(ref this.ddlGerencia, objBFEGE.GetGERENCIAAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODGERENCIA", "NOMBREGERENCIA");
                this.ddlGerencia.SelectedValue = "-";
                if (ddlGerencia.Items.Count > 1)
                {
                    this.divGerencia.Visible = true;
                }
                BFCENTROCOSTO objBFCC = new BFCENTROCOSTO();
                objWEB.LlenaDDL(ref this.ddlCentroCosto, objBFCC.GetCENTROCOSTOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCENTROCOSTO", "NOMBRECENTROCOSTO");
                this.ddlCentroCosto.SelectedValue = "-";
                if (ddlCentroCosto.Items.Count > 1)
                {
                    this.divCentroCosto.Visible = true;
                }
                BFSUCURSAL objBFSU = new BFSUCURSAL();
                objWEB.LlenaDDL(ref this.ddlSucursal, objBFSU.GetSUCURSALAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODSUCURSAL", "NOMBRESUCURSAL");
                this.ddlSucursal.SelectedValue = "-";
                if (ddlSucursal.Items.Count > 1)
                {
                    this.divSucursal.Visible = true;
                }
                BFAREA objBFAR = new BFAREA();
                objWEB.LlenaDDL(ref this.ddlArea, objBFAR.GetAREAAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODAREA", "NOMBREAREA");
                this.ddlArea.SelectedValue = "-";
                if (ddlArea.Items.Count > 1)
                {
                    this.divArea.Visible = true;
                }
                BFCARGO objBFCA = new BFCARGO();
                objWEB.LlenaDDL(ref this.ddlCargo, objBFCA.GetCARGOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCARGO", "NOMBRECARGO");
                this.ddlCargo.SelectedValue = "-";
                if (ddlCargo.Items.Count > 1)
                {
                    this.divCargo.Visible = true;
                }
                BFROL objBFRO = new BFROL();
                objWEB.LlenaDDL(ref this.ddlRol, objBFRO.GetROLAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODROL", "NOMBREROL");
                this.ddlRol.SelectedValue = "-";
                if (ddlRol.Items.Count > 1)
                {
                    this.divRol.Visible = true;
                }
                BFCLASIFICADOR1 objBFCL1 = new BFCLASIFICADOR1();
                objWEB.LlenaDDL(ref this.ddlClasificador1, objBFCL1.GetCLASIFICADOR1All(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCLASIFICADOR1", "NOMBRECLASIFICADOR1");
                this.ddlClasificador1.SelectedValue = "";
                if (ddlClasificador1.Items.Count > 1)
                {
                    this.divClasificador1.Visible = true;
                }
                BFCLASIFICADOR2 objBFCL2 = new BFCLASIFICADOR2();
                objWEB.LlenaDDL(ref this.ddlClasificador2, objBFCL2.GetCLASIFICADOR2All(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCLASIFICADOR2", "NOMBRECLASIFICADOR2");
                this.ddlClasificador2.SelectedValue = "";
                if (ddlClasificador2.Items.Count > 1)
                {
                    this.divClasificador2.Visible = true;
                } 

                ViewState["Empleados"] = lstEM;
                ViewState["EmpleadosTmp"] = lstEMTmp;
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
                this.txtActInicio.Text = Request["Inicio"];
                this.txtActFin.Text = Request["Fin"];
                this.ddlInstrumentos.Enabled = false;
                this.txtNombre.Enabled = false;

                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                List<EINSTRUMENTOEMPLEADO> lst = objBFIE.GetAsignaciones(this.txtNombre.Text);

                objWEB.LlenaGrilla(ref this.grdAsignaciones, lst.Cast<DomainObject>().ToList(), 1000);
                ViewState["Modo"] = "Actualizar";
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnBuscarColaboradores_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lstEMTmp = (List<EEMPLEADO>)ViewState["EmpleadosTmp"];

                BFEMPLEADO objBFEM = new BFEMPLEADO();
                lstEMTmp = objBFEM.GetEmpleadosPorFiltros(Utiles.ConvertToString(this.txtNombreColaborador.Text),
                                        Utiles.ConvertToInt64(this.ddlEmpresa.SelectedValue), this.ddlGerencia.SelectedValue,
                                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                                        this.ddlClasificador2.SelectedValue);
                ViewState["EmpleadosTmp"] = lstEMTmp;
                objWEB.LlenaGrilla(ref this.grdColaboradoresTmp, lstEMTmp.Cast<DomainObject>().ToList(), 20);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                List<EEMPLEADO> lst = (List<EEMPLEADO>)ViewState["Empleados"];

                Boolean blnExiste;
                foreach (GridViewRow grd in this.grdColaboradoresTmp.Rows)
                {
                    if (((CheckBox)grd.FindControl("chkSeleccionar")).Checked)
                    {
                        blnExiste = false;
                        foreach (EEMPLEADO obj in lst)
                        {
                            if (obj.RUTCOMPLETO == ((Label)grd.FindControl("lblRut")).Text)
                            {
                                blnExiste = true;
                            }
                        }
                        if (blnExiste == false)
                        {
                            BFEMPLEADO objBFEM = new BFEMPLEADO();
                            lst.Add(objBFEM.GetEMPLEADO(Utiles.RutUsrALng(((Label)grd.FindControl("lblRut")).Text)));
                        }
                    }
                }
                ViewState["Empleados"] = lst;
                objWEB.LlenaGrilla(ref this.grdColaboradores, lst.Cast<DomainObject>().ToList(), 25);
                if (this.grdColaboradores.Rows.Count > 0)
                {
                    btnEliminarColaborador.Visible = true;
                }
                else
                {
                    btnEliminarColaborador.Visible = false;
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

        protected void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                List<EEMPLEADO> lstTmp = (List<EEMPLEADO>)ViewState["EmpleadosTmp"];
                List<EEMPLEADO> lst = (List<EEMPLEADO>)ViewState["Empleados"];
                Boolean blnExiste;
                foreach (EEMPLEADO objTMP in lstTmp)
                {
                    blnExiste = false;
                    foreach (EEMPLEADO obj in lst)
                    {
                        if (objTMP.RUTCOMPLETO == obj.RUTCOMPLETO)
                        {
                            blnExiste = true;
                        }
                    }

                    if (blnExiste == false)
                    {
                        lst.Add(objTMP);
                    }
                }
                ViewState["Empleados"] = lst;
                objWEB.LlenaGrilla(ref this.grdColaboradores, lst.Cast<DomainObject>().ToList(), 25);
                if (this.grdColaboradores.Rows.Count > 0)
                {
                    btnEliminarColaborador.Visible = true;
                }
                else
                {
                    btnEliminarColaborador.Visible = false;
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

        protected void btnCerrar_Click(object sender, EventArgs e)
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('2');", true);
        }

        protected void btnContinuarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTO objBFIN = new BFINSTRUMENTO();
                EINSTRUMENTO objIN = objBFIN.GetINSTRUMENTO(Utiles.ConvertToInt64(this.ddlInstrumentos.SelectedValue));
                List<EEMPLEADO> lst = (List<EEMPLEADO>)ViewState["Empleados"];
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                objBFIE.Asignar(objIN, lst, this.txtNombre.Text, Utiles.ConvertToDateTime(this.txtInicio.Text), Utiles.ConvertToDateTime(this.txtFin.Text), this.ddlDireccion.SelectedValue);


                List<EINSTRUMENTOEMPLEADO> lstAsg = objBFIE.GetAsignaciones(this.txtNombre.Text);

                objWEB.LlenaGrilla(ref this.grdAsignaciones, lstAsg.Cast<DomainObject>().ToList(), 1000);
                ViewState["Modo"] = "Actualizar";
                divActualizacion.Visible = true;

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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string strRuta = Page.ResolveUrl("~/modulos/administracion/lista_asignaciones.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
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
            catch(Exception ex)
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

        protected void btnEliminarColaborador_Click(object sender, EventArgs e)
        {
            List<EEMPLEADO> lst = (List<EEMPLEADO>)ViewState["Empleados"];

            foreach (GridViewRow grdRow in this.grdColaboradores.Rows)
            {
                if (((CheckBox)grdRow.FindControl("chkSeleccionar")).Checked)
                {
                    foreach (EEMPLEADO obj in lst)
                    {
                        if (obj.RUTCOMPLETO == ((Label)grdRow.FindControl("lblRut")).Text)
                        {
                            lst.Remove(obj);
                            break;
                        }
                    }
                }
            }
            ViewState["Empleados"] = lst;
            objWEB.LlenaGrilla(ref this.grdColaboradores, lst.Cast<DomainObject>().ToList(), 25);
            if (this.grdColaboradores.Rows.Count > 0)
            {
                btnEliminarColaborador.Visible = true;
            }
            else
            {
                btnEliminarColaborador.Visible = false;
            }
        }

        protected void lnkEvaluar_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            string lblCodInstrumentoEmpleado = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodInstrumentoEmpleado")).Value);
            string lblRelacion = "Super Usuario";

            string strRuta = Page.ResolveUrl("~/modulos/evaluacion/evaluacion.aspx?CodInstrumentoEmpleado=" + lblCodInstrumentoEmpleado + "&Relacion=" + lblRelacion + "&Modo=SU");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
        }
    }
}