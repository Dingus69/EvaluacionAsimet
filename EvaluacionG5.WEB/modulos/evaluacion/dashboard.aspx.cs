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
using System.Configuration;

namespace EvaluacionG5.WEB.modulos.evaluacion
{
    public partial class dashboard : System.Web.UI.Page
    {
        ESESSIONUSUARIO objSession;
        UtilesWEB objWEB = new UtilesWEB();

        private void ValidaSession()
        {
            if (objWEB.CheckeaSessionUsuario())
            {
                objSession = objWEB.CargaSessionUsuario();
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
                    if (Request["Acceso"] != null)
                    {
                        if (Request["Acceso"] == "No")
                        {
                            this.litSinAcceso.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
                        }
                    }
                    InicializarFormulario();
                    txtCuerpoCorreo.FontFacesMenuList = new string[] { "Arial", "Times" };
                    //txtCuerpoCorreo.
                }
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void InicializarFormulario()
        {
            try
            {

                if (Utiles.ConvertToBoolean(ConfigurationManager.AppSettings["MostrarKPI"]))
                {
                    liKPI.Visible = true;
                    liMiDesempeno.Visible = true;
                    liMisKPI.Visible = true;
                    ulFicha.Visible = true;
                    mtvHistorial.ActiveViewIndex = 0;
                }
                else
                {
                    liKPI.Visible = false;
                    liMiDesempeno.Visible = false;
                    liMisKPI.Visible = false;
                    ulFicha.Visible = false;
                    mtvHistorial.ActiveViewIndex = 0;
                }


                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                objWEB.LlenaDDL(ref ddlEvaluaciones, objIN.AsignacionesPorEvaluador(Utiles.ConvertToInt64(objSession.RutUsuario)), "NOM_INSTRUMENTO_EMPLEADO", "NOM_INSTRUMENTO_EMPLEADO");

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
                objWEB.AgregaValorDDL(ref this.ddlGerencia, "-", "-");
                this.ddlGerencia.SelectedValue = "-";
                //if (ddlGerencia.Items.Count > 1)
                //{
                //    this.divGerencia.Visible = true;
                //}
                BFCENTROCOSTO objBFCC = new BFCENTROCOSTO();
                objWEB.LlenaDDL(ref this.ddlCentroCosto, objBFCC.GetCENTROCOSTOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCENTROCOSTO", "NOMBRECENTROCOSTO");
                objWEB.AgregaValorDDL(ref this.ddlCentroCosto, "-", "-");
                this.ddlCentroCosto.SelectedValue = "-";
                //if (ddlCentroCosto.Items.Count > 1)
                //{
                //    this.divCentroCosto.Visible = true;
                //}
                BFSUCURSAL objBFSU = new BFSUCURSAL();
                objWEB.LlenaDDL(ref this.ddlSucursal, objBFSU.GetSUCURSALAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODSUCURSAL", "NOMBRESUCURSAL");
                objWEB.AgregaValorDDL(ref this.ddlSucursal, "-", "-");
                this.ddlSucursal.SelectedValue = "-";
                //if (ddlSucursal.Items.Count > 1)
                //{
                //    this.divSucursal.Visible = true;
                //}
                BFAREA objBFAR = new BFAREA();
                objWEB.LlenaDDL(ref this.ddlArea, objBFAR.GetAREAAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODAREA", "NOMBREAREA");
                objWEB.AgregaValorDDL(ref this.ddlArea, "-", "-");
                this.ddlArea.SelectedValue = "-";
                //if (ddlArea.Items.Count > 1)
                //{
                //    this.divArea.Visible = true;
                //}
                BFCARGO objBFCA = new BFCARGO();
                objWEB.LlenaDDL(ref this.ddlCargo, objBFCA.GetCARGOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCARGO", "NOMBRECARGO");
                objWEB.AgregaValorDDL(ref this.ddlCargo, "-", "-");
                this.ddlCargo.SelectedValue = "-";
                //if (ddlCargo.Items.Count > 1)
                //{
                //    this.divCargo.Visible = true;
                //}
                BFROL objBFRO = new BFROL();
                objWEB.LlenaDDL(ref this.ddlRol, objBFRO.GetROLAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODROL", "NOMBREROL");
                objWEB.AgregaValorDDL(ref this.ddlRol, "-", "-");
                this.ddlRol.SelectedValue = "-";
                //if (ddlRol.Items.Count > 1)
                //{
                //    this.divRol.Visible = true;
                //}
                BFCLASIFICADOR1 objBFCL1 = new BFCLASIFICADOR1();
                objWEB.LlenaDDL(ref this.ddlClasificador1, objBFCL1.GetCLASIFICADOR1All(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCLASIFICADOR1", "NOMBRECLASIFICADOR1");
                objWEB.AgregaValorDDL(ref this.ddlClasificador1, "", "");
                this.ddlClasificador1.SelectedValue = "";
                //if (ddlClasificador1.Items.Count > 1)
                //{
                //    this.divClasificador1.Visible = true;
                //}
                BFCLASIFICADOR2 objBFCL2 = new BFCLASIFICADOR2();
                objWEB.LlenaDDL(ref this.ddlClasificador2, objBFCL2.GetCLASIFICADOR2All(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCLASIFICADOR2", "NOMBRECLASIFICADOR2");
                objWEB.AgregaValorDDL(ref this.ddlClasificador2, "", "");
                this.ddlClasificador2.SelectedValue = "";
                //if (ddlClasificador2.Items.Count > 1)
                //{
                //    this.divClasificador2.Visible = true;
                //} 

                this.divMisColaboradores.Visible = true;
                this.divMisEvaluaciones.Visible = false;
                this.divVIsar.Visible = false;
                this.liMisColaboradores.Attributes.Remove("class");
                this.liMisEvaluaciones.Attributes.Remove("class"); 
                this.liMisColaboradores.Attributes.Add("class", "active");
                Consultar();
                VerDetalles(4);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
            VerDetalles(4);
        }

        protected void Consultar()
        {
            try
            {
                this.hdfAsignadas.Value = "0";
                this.hdfEnCurso.Value = "0";
                this.hdfFinalizada.Value = "0";
                this.hdfEnFeedback.Value = "0";
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                DataTable dtValores = objIN.CantidadEvalPorEstado(Utiles.ConvertToInt64(objSession.RutUsuario), this.ddlEvaluaciones.SelectedValue,
                                        objSession.RutEmpresa, this.ddlGerencia.SelectedValue,
                                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                                        this.ddlClasificador2.SelectedValue);
                foreach (DataRow dr in dtValores.Rows)
                {
                    switch (dr["CODESTADOEVAL"].ToString())
                    {
                        case "1":
                            this.hdfAsignadas.Value = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "2":
                            this.hdfEnCurso.Value = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "5":
                            this.hdfFinalizada.Value = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "6":
                            this.hdfEnFeedback.Value = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                    }
                }


                this.litValorJefaturas.Text = "0";
                this.litValorColaboradores.Text = "0";
                this.litValorPares.Text = "0";
                this.litValorAutoevaluaciones.Text = "0";
                dtValores = objIN.CantidadEvalPorTipo(Utiles.ConvertToInt64(objSession.RutUsuario), this.ddlEvaluaciones.SelectedValue,
                                        objSession.RutEmpresa, this.ddlGerencia.SelectedValue,
                                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                                        this.ddlClasificador2.SelectedValue);
                foreach (DataRow dr in dtValores.Rows)
                {
                    switch (dr["COD_TIPO_EVAL"].ToString())
                    {
                        case "1":
                            this.litValorJefaturas.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "2":
                            this.litValorColaboradores.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "3":
                            this.litValorPares.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "4":
                            this.litValorAutoevaluaciones.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void lnlMisColaboradores_Click(object sender, EventArgs e)
        {
            try
            {
                this.divMisColaboradores.Visible = true;
                this.divMisEvaluaciones.Visible = false;
                this.divVIsar.Visible = false;
                this.divKPI.Visible = false;
                this.divMiEquipo.Visible = false;
                CambiarCssMenu(1);
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void misEvaluaciones_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                //objWEB.LlenaGrilladt(ref this.grdMisEvaluaciones, objIN.GetMisEvaluaciones(Utiles.ConvertToInt64(objSession.RutUsuario)), 100);
                objWEB.LlenaGrilladt(ref this.grdMisEvaluaciones, objIN.GetHistorial(Utiles.ConvertToInt64(objSession.RutUsuario)), 100);
                objWEB.LlenaGrilladt(ref this.grdMisKPI, objIN.GetMisKPI(Utiles.ConvertToInt64(objSession.RutUsuario)), 100);
                this.divMisColaboradores.Visible = false;
                this.divMisEvaluaciones.Visible = true;
                this.divVIsar.Visible = false;
                this.divKPI.Visible = false;
                this.divMiEquipo.Visible = false;
                CambiarCssMenu(2);
                mtvHistorial.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void lnkKPI_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                objWEB.LlenaGrilladt(ref this.grdMisKPIVigente, objIN.GetMisKPIVigente(Utiles.ConvertToInt64(objSession.RutUsuario)), 100);
               this.divMisColaboradores.Visible = false;
                this.divMisEvaluaciones.Visible = false;
                this.divVIsar.Visible = false;
                this.divKPI.Visible = true;
                this.divMiEquipo.Visible = false;
                CambiarCssMenu(3);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void lnkMiEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                BFEMPLEADO objEM = new BFEMPLEADO();
                List<EEMPLEADO> lst = objEM.GetEMPLEADOSBYRUTJEFE(Utiles.ConvertToInt64(objSession.RutUsuario));
                objWEB.LlenaGrilla(ref this.grdMiEquipo, lst.Cast<DomainObject>().ToList(), 100);
                this.divMisColaboradores.Visible = false;
                this.divMisEvaluaciones.Visible = false;
                this.divVIsar.Visible = false;
                this.divKPI.Visible = false;
                this.divMiEquipo.Visible = true;
                CambiarCssMenu(4);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void misVisaciones_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                DataTable dt = objIN.GetMisVisaciones(Utiles.ConvertToInt64(objSession.RutUsuario));
                objWEB.LlenaGrilladt(ref this.grdVisar, dt, 100);
                this.divMisColaboradores.Visible = false;
                this.divMisEvaluaciones.Visible = false;
                this.divVIsar.Visible = true;
                this.divKPI.Visible = false;
                this.divMiEquipo.Visible = false;
                CambiarCssMenu(5);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void lnkVerAsignadas_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_1 cbp-mc-1column sin_bordes");
            VerDetalles(1);
        }

        protected void lnkVerEnBorrador_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_2 cbp-mc-1column sin_bordes");
            VerDetalles(2);
        }

        protected void lnkVerApeladas_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_3 cbp-mc-1column sin_bordes");
            VerDetalles(3);
        }

        protected void lnkVerVisadas_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_4 cbp-mc-1column sin_bordes");
            VerDetalles(4);
        }

        protected void lnkVerCerradas_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_5 cbp-mc-1column sin_bordes");
            VerDetalles(5);
        }

        protected void lnkVerInformadas_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_7 cbp-mc-1column sin_bordes");
            VerDetalles(6);
        }

        protected void lnkVerEnFeedback_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_7 cbp-mc-1column sin_bordes");
            VerDetalles(6);

        }

        protected void lnkVerAutoevaluaciones_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_1 cbp-mc-1column sin_bordes");
            VerDetalles(4);
        }

        protected void lnkVerColaboradores_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_2 cbp-mc-1column sin_bordes");
            VerDetalles(2);
        }

        protected void lnkVerJefaturas_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_5 cbp-mc-1column sin_bordes");
            VerDetalles(1);
        }

        protected void lnkVerPares_Click(object sender, EventArgs e)
        {
            this.grillaEvaluaciones.Attributes.Remove("class");
            this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_7 cbp-mc-1column sin_bordes");
            VerDetalles(3);
        }

        protected void VerDetalles(decimal CodTipo)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                //objWEB.LlenaGrilladt(ref this.grdResultados, objIN.GetInstrumentosPorEstado(Utiles.ConvertToInt64(objSession.RutUsuario), this.ddlEvaluaciones.SelectedValue,
                //                        Utiles.ConvertToInt64(this.ddlEmpresa.SelectedValue), this.ddlGerencia.SelectedValue,
                //                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                //                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                //                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                //                        this.ddlClasificador2.SelectedValue, CodEstado), 100);
                //objWEB.LlenaRepeaterdt(ref this.repEvaluaciones, objIN.GetInstrumentosPorEstado(Utiles.ConvertToInt64(objSession.RutUsuario), this.ddlEvaluaciones.SelectedValue,
                //                        Utiles.ConvertToInt64(this.ddlEmpresa.SelectedValue), this.ddlGerencia.SelectedValue,
                //                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                //                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                //                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                //                        this.ddlClasificador2.SelectedValue, CodEstado), 100);
                objWEB.LlenaRepeaterdt(ref this.repEvaluaciones, objIN.GetInstrumentosPorTipo(Utiles.ConvertToInt64(objSession.RutUsuario), this.ddlEvaluaciones.SelectedValue,
                                        objSession.RutEmpresa, this.ddlGerencia.SelectedValue,
                                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                                        this.ddlClasificador2.SelectedValue, CodTipo), 100);
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            string lblCodInstrumentoEmpleado = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodInstrumentoEmpleado")).Value);
            string lblRelacion = Utiles.ConvertToString(((Label)fila.FindControl("lblRelacion")).Text);

            string strRuta = Page.ResolveUrl("~/modulos/evaluacion/editar_evaluacion.aspx?CodInstrumentoEmpleado=" + lblCodInstrumentoEmpleado + "&Relacion=" + lblRelacion);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
        }

        protected void lnkVerMisEvaluaciones_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            string NomInstrumento = Utiles.ConvertToString(((Label)fila.FindControl("lblNombreInstrumento")).Text);
            DateTime Inicio = Utiles.ConvertToDateTime(((Label)fila.FindControl("lblInicio")).Text);
            DateTime Fin = Utiles.ConvertToDateTime(((Label)fila.FindControl("lblFin")).Text);

            BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
            DataTable dt = objBFIE.GetDetalleHistorial(objSession.RutUsuario, NomInstrumento, Inicio, Fin);

            List<EDETALLE> lst = new List<EDETALLE>();
            EDETALLE obj; 
            foreach (DataRow dr in dt.Rows)
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Columns.Add("RELACION");
                for (int i = 6; i <= dt.Columns.Count - 1; i++)
                {
                    dtTmp.Columns.Add(dt.Columns[i].ColumnName);
                }

                DataRow drTmp;
                drTmp = dtTmp.NewRow();
                drTmp[0] = dr[1];
                for (int i = 1; i <= dtTmp.Columns.Count - 1; i++)
                {
                    drTmp[i] = dr[i + 5];
                }
                dtTmp.Rows.Add(drTmp);
                obj = new EDETALLE();
                obj.COMENTARIO_FEEDBACK = dr[5].ToString();
                obj.SECCIONES = dtTmp;
                lst.Add(obj); 
            }



            objWEB.LlenaGrilla(ref this.grdDetalleHistorial, lst.Cast<DomainObject>().ToList(), 100);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('11');", true);
             
        }

        protected void lnkEvaluar_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            RepeaterItem fila = (RepeaterItem)imgEditar.NamingContainer;
            //GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            string lblCodInstrumentoEmpleado = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodInstrumentoEmpleado")).Value);
            string lblRelacion = Utiles.ConvertToString(((Label)fila.FindControl("lblRelacion")).Text);
            
            string strRuta = Page.ResolveUrl("~/modulos/evaluacion/evaluacion.aspx?CodInstrumentoEmpleado=" + lblCodInstrumentoEmpleado + "&Relacion=" + lblRelacion);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
        }

        protected void lnkVisar_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            string lblCodInstrumentoEmpleado = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodInstrumentoEmpleado")).Value);
            string lblRelacion = Utiles.ConvertToString(((Label)fila.FindControl("lblRelacion")).Text);

            string strRuta = Page.ResolveUrl("~/modulos/evaluacion/evaluacion.aspx?CodInstrumentoEmpleado=" + lblCodInstrumentoEmpleado + "&Modo=Visar&Relacion=" + lblRelacion);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
        }

        protected void grdResultados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!(Utiles.ConvertToBoolean(((HiddenField)e.Row.FindControl("hdfFlagAgregarPregunta")).Value)))
                {
                    if (((HiddenField)e.Row.FindControl("hdfCodEstado")).Value != "1")
                    {
                        ((LinkButton)e.Row.FindControl("lnkEditar")).Visible = false;
                    }
                }
            }
        }

        protected void lnkVerBitacora_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            string CodInstrumentoEmpleado = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodInstrumentoEmpleado")).Value);

            BFBITACORA objBFBI = new BFBITACORA();
            DataTable dt = objBFBI.GetBitacoraInstrumentoEmpleado(Utiles.ConvertToDecimal(CodInstrumentoEmpleado));

            objWEB.LlenaGrilladt(ref this.grdBitacora, dt, 100);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('5');", true);
        }

        protected void lnkNotificaciones_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            BFEMPLEADO objBFEM = new BFEMPLEADO();
            EEMPLEADO objEM = objBFEM.GetEMPLEADO(Utiles.RutUsrALng(((Label)fila.FindControl("lblRut")).Text));
            hdfEmailEmpleado.Value = objEM.EMAIL;
            hdfNombreEmpleado.Value = objEM.NOMBRECOMPLETO;
            BFPARAMETROSGENERALES objBFPA = new BFPARAMETROSGENERALES();
            hdfURL.Value = objBFPA.GetPARAMETROSGENERALESAll()[0].URL_PLATAFORMA;

            BFCORREO objBFCO = new BFCORREO();
            List<ECORREO> lst = objBFCO.GetCORREOAll();
            objWEB.LlenaDDL(ref this.ddlAsuntoCorreo, lst.Cast<DomainObject>().ToList(), "CODCORREO", "ASUNTO");
            ECORREO objCO = objBFCO.GetCORREO(Utiles.ConvertToInt64(ddlAsuntoCorreo.SelectedValue));
            this.txtCuerpoCorreo.Text = objCO.CUERPO.Replace("_NOMBREUSUARIO", hdfNombreEmpleado.Value).Replace("_URL", hdfURL.Value);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('6');", true);
        }

        protected void btnEnviarNotificacion_Click(object sender, EventArgs e)
        {
            try
            {
                BFPARAMETROSGENERALES objBFPA = new BFPARAMETROSGENERALES();
                EPARAMETROSGENERALES objPA = objBFPA.GetPARAMETROSGENERALESAll()[0];
                Utiles.EnviarCorreo(objPA.DOMINIO, objPA.SMTP, objPA.EMAIL, objPA.PASSWORD, objPA.PUERTO, hdfEmailEmpleado.Value, ddlAsuntoCorreo.SelectedItem.Text, txtCuerpoCorreo.Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('4');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void ddlAsuntoCorreo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BFCORREO objBFCO = new BFCORREO();
            ECORREO objCO = objBFCO.GetCORREO(Utiles.ConvertToInt64(ddlAsuntoCorreo.SelectedValue));
            this.txtCuerpoCorreo.Text = objCO.CUERPO.Replace("_NOMBREUSUARIO", hdfNombreEmpleado.Value).Replace("_URL", hdfURL.Value);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('6');", true);
        }

        protected void grdMiEquipo_RowDataBound(object sender, GridViewRowEventArgs e)
        { 
        }

        protected void lnkVerFicha_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
            Int64 Rut = Utiles.ConvertToInt64(((HiddenField)fila.FindControl("hdfRutEmpleado")).Value);
            CargarFichaColaborador(Rut);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('7');", true);
        }

        protected void CargarFichaColaborador(Int64 Rut)
        {
            try
            {
                BFEMPLEADO objBFEM = new BFEMPLEADO();
                EEMPLEADO obj = objBFEM.GetEMPLEADO(Rut);
                txtFichaRut.Text = obj.RUTCOMPLETO;
                txtFichaNombres.Text = obj.NOMBREEMPLEADO;
                txtFichaApPaterno.Text = obj.APELLIDOPATERNO;
                txtFichaApMaterno.Text = obj.APELLIDOMATERNO;
                txtFichaEmail.Text = obj.EMAIL;
                txtFichaSucursal.Text = obj.NOMBRE_SUCURSAL;
                txtFichaGerencia.Text = obj.NOMBRE_GERENCIA;
                txtFichaArea.Text = obj.NOMBRE_AREA;
                txtFichaCentroCosto.Text = obj.NOMBRE_CENTRO_COSTO;
                txtFichaRol.Text = obj.NOMBRE_ROL;
                txtFichaCargo.Text = obj.NOMBRE_CARGO;
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                objWEB.LlenaGrilladt(ref this.grdEvaluacionesFicha, objIN.GetHistorial(Rut), 100);
                objWEB.LlenaGrilladt(ref this.grdKPI, objIN.GetMisKPI(Rut), 100);
                mtvFicha.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void lnkVer_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

                Int64 Rut = Utiles.RutUsrALng(txtFichaRut.Text);
                string NomInstrumentoEmpleado = Utiles.ConvertToString(((Label)fila.FindControl("lblNombreInstrumento")).Text);
                hdfNombreFormulario.Value = NomInstrumentoEmpleado;

                DateTime Inicio = Utiles.ConvertToDateTime(((Label)fila.FindControl("lblInicio")).Text);
                DateTime Fin = Utiles.ConvertToDateTime(((Label)fila.FindControl("lblFin")).Text);
                hdfResumenTextoGraf01.Value = "";
                hdfResumenColabGraf01.Value = "";
                hdfResumenJefatGraf01.Value = "";
                hdfResumenParesGraf01.Value = "";
                hdfResumenAutoevGraf01.Value = "";

                hdfResumenTextoGraf02.Value = "";
                hdfResumenDataGraf02.Value = "";

                hdfResumenTextoGraf03.Value = "";
                hdfResumenDataGraf03.Value = "";

                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                DataTable dtFicha = objBFIE.GetResumenGrafico01(Rut, NomInstrumentoEmpleado, Inicio, Fin);

                foreach (DataRow drFicha in dtFicha.Rows)
                {
                    hdfResumenTextoGraf01.Value = hdfResumenTextoGraf01.Value + "'" + drFicha[0] + "',";
                    hdfResumenColabGraf01.Value = hdfResumenColabGraf01.Value + drFicha[1] + ",";
                    hdfResumenJefatGraf01.Value = hdfResumenJefatGraf01.Value + drFicha[2] + ",";
                    hdfResumenParesGraf01.Value = hdfResumenParesGraf01.Value + drFicha[3] + ",";
                    hdfResumenAutoevGraf01.Value = hdfResumenAutoevGraf01.Value + drFicha[4] + ",";
                }
                if (hdfResumenTextoGraf01.Value.Length > 0)
                    hdfResumenTextoGraf01.Value = hdfResumenTextoGraf01.Value.Substring(0, hdfResumenTextoGraf01.Value.Length - 1);
                if (hdfResumenColabGraf01.Value.Length > 0)
                    hdfResumenColabGraf01.Value = hdfResumenColabGraf01.Value.Substring(0, hdfResumenColabGraf01.Value.Length - 1);
                if (hdfResumenJefatGraf01.Value.Length > 0)
                    hdfResumenJefatGraf01.Value = hdfResumenJefatGraf01.Value.Substring(0, hdfResumenJefatGraf01.Value.Length - 1);
                if (hdfResumenParesGraf01.Value.Length > 0)
                    hdfResumenParesGraf01.Value = hdfResumenParesGraf01.Value.Substring(0, hdfResumenParesGraf01.Value.Length - 1);
                if (hdfResumenAutoevGraf01.Value.Length > 0)
                    hdfResumenAutoevGraf01.Value = hdfResumenAutoevGraf01.Value.Substring(0, hdfResumenAutoevGraf01.Value.Length - 1);


                DataTable dtColab = objBFIE.GetResumenGrafico02Y03(Rut, NomInstrumentoEmpleado, Inicio, Fin, 1);
                if (dtColab.Rows.Count > 0)
                {
                    int cantSecciones = Utiles.ConvertToInt16(dtColab.Rows[0][0]) - 1;
                    int i = 0;
                    foreach (DataRow drColab in dtColab.Rows)
                    {
                        if (i <= cantSecciones)
                        {
                            hdfResumenTextoGraf02.Value = hdfResumenTextoGraf02.Value + "'" + drColab[1] + "',";
                            i++;
                        }
                    }
                    if (hdfResumenTextoGraf02.Value.Length > 0)
                        hdfResumenTextoGraf02.Value = hdfResumenTextoGraf02.Value.Substring(0, hdfResumenTextoGraf02.Value.Length - 1);

                    hdfResumenDataGraf02.Value = "{ data: [";
                    int x = 0;
                    while (x <= (dtColab.Rows.Count - 1))
                    {
                        for (int z = 0; z <= cantSecciones; z++)
                        {
                            hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value + dtColab.Rows[x][2] + ",";
                            x++;
                        }
                        hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value.Substring(0, hdfResumenDataGraf02.Value.Length - 1) + "]";
                        if (x < (dtColab.Rows.Count - 1))
                        {
                            hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value + "}, { data: [";
                        }
                        else
                        {
                            hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value + "}";
                        }
                    } 
                }
                else
                {
                    DataTable dtSecciones = objBFIE.GetResumenSeccionesGrafico02Y03(Rut, NomInstrumentoEmpleado, 1);
                    hdfResumenDataGraf02.Value = "{ data: [";
                    foreach (DataRow drSecciones in dtSecciones.Rows)
                    {
                        hdfResumenTextoGraf02.Value = hdfResumenTextoGraf02.Value + "'" + drSecciones[0] + "',";
                        hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value  + "0,";
                    }

                    if (hdfResumenTextoGraf02.Value.Length > 0)
                        hdfResumenTextoGraf02.Value = hdfResumenTextoGraf02.Value.Substring(0, hdfResumenTextoGraf02.Value.Length - 1);
                    if (hdfResumenDataGraf02.Value.Length > 0)
                        hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value.Substring(0, hdfResumenDataGraf02.Value.Length - 1) + "]}";

                }



                DataTable dtPares = objBFIE.GetResumenGrafico02Y03(Rut, NomInstrumentoEmpleado, Inicio, Fin, 3);
                if (dtPares.Rows.Count > 0)
                {
                    int cantSecciones = Utiles.ConvertToInt16(dtPares.Rows[0][0]) - 1;
                    int i = 0;
                    foreach (DataRow drPares in dtPares.Rows)
                    {
                        if (i <= cantSecciones)
                        {
                            hdfResumenTextoGraf03.Value = hdfResumenTextoGraf03.Value + "'" + drPares[1] + "',";
                            i++;
                        }
                    }
                    if (hdfResumenTextoGraf03.Value.Length > 0)
                        hdfResumenTextoGraf02.Value = hdfResumenTextoGraf03.Value.Substring(0, hdfResumenTextoGraf03.Value.Length - 1);


                    hdfResumenDataGraf03.Value = "{ data: [";
                    int x = 0;
                    while (x <= (dtPares.Rows.Count - 1))
                    {
                        for (int z = 0; z <= cantSecciones; z++)
                        {
                            hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value + dtPares.Rows[x][2] + ",";
                            x++;
                        }
                        hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value.Substring(0, hdfResumenDataGraf03.Value.Length - 1) + "]";
                        if (x < (dtPares.Rows.Count - 1))
                        {
                            hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value + "}, { data: [";
                        }
                        else
                        {
                            hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value + "}";
                        }
                    }
                }
                else
                {
                    DataTable dtSecciones = objBFIE.GetResumenSeccionesGrafico02Y03(Rut, NomInstrumentoEmpleado, 3);
                    hdfResumenDataGraf03.Value = "{ data: [";
                    foreach (DataRow drSecciones in dtSecciones.Rows)
                    {
                        hdfResumenTextoGraf03.Value = hdfResumenTextoGraf03.Value + "'" + drSecciones[0] + "',";
                        hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value + "0,";
                    }

                    if (hdfResumenTextoGraf03.Value.Length > 0)
                        hdfResumenTextoGraf03.Value = hdfResumenTextoGraf03.Value.Substring(0, hdfResumenTextoGraf03.Value.Length - 1);
                    if (hdfResumenDataGraf03.Value.Length > 0)
                        hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value.Substring(0, hdfResumenDataGraf03.Value.Length - 1) + "]}";

                }


                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('8');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkVer2_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

                Int64 Rut = objSession.RutUsuario;
                string NomInstrumentoEmpleado = Utiles.ConvertToString(((Label)fila.FindControl("lblNombreInstrumento")).Text);
                hdfNombreFormulario.Value = NomInstrumentoEmpleado;

                DateTime Inicio = Utiles.ConvertToDateTime(((Label)fila.FindControl("lblInicio")).Text);
                DateTime Fin = Utiles.ConvertToDateTime(((Label)fila.FindControl("lblFin")).Text);
                hdfResumenTextoGraf01.Value = "";
                hdfResumenColabGraf01.Value = "";
                hdfResumenJefatGraf01.Value = "";
                hdfResumenParesGraf01.Value = "";
                hdfResumenAutoevGraf01.Value = "";

                hdfResumenTextoGraf02.Value = "";
                hdfResumenDataGraf02.Value = "";

                hdfResumenTextoGraf03.Value = "";
                hdfResumenDataGraf03.Value = "";

                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                DataTable dtFicha = objBFIE.GetResumenGrafico01(Rut, NomInstrumentoEmpleado, Inicio, Fin);

                foreach (DataRow drFicha in dtFicha.Rows)
                {
                    hdfResumenTextoGraf01.Value = hdfResumenTextoGraf01.Value + "'" + drFicha[0] + "',";
                    hdfResumenColabGraf01.Value = hdfResumenColabGraf01.Value + drFicha[1] + ",";
                    hdfResumenJefatGraf01.Value = hdfResumenJefatGraf01.Value + drFicha[2] + ",";
                    hdfResumenParesGraf01.Value = hdfResumenParesGraf01.Value + drFicha[3] + ",";
                    hdfResumenAutoevGraf01.Value = hdfResumenAutoevGraf01.Value + drFicha[4] + ",";
                }
                if (hdfResumenTextoGraf01.Value.Length > 0)
                    hdfResumenTextoGraf01.Value = hdfResumenTextoGraf01.Value.Substring(0, hdfResumenTextoGraf01.Value.Length - 1);
                if (hdfResumenColabGraf01.Value.Length > 0)
                    hdfResumenColabGraf01.Value = hdfResumenColabGraf01.Value.Substring(0, hdfResumenColabGraf01.Value.Length - 1);
                if (hdfResumenJefatGraf01.Value.Length > 0)
                    hdfResumenJefatGraf01.Value = hdfResumenJefatGraf01.Value.Substring(0, hdfResumenJefatGraf01.Value.Length - 1);
                if (hdfResumenParesGraf01.Value.Length > 0)
                    hdfResumenParesGraf01.Value = hdfResumenParesGraf01.Value.Substring(0, hdfResumenParesGraf01.Value.Length - 1);
                if (hdfResumenAutoevGraf01.Value.Length > 0)
                    hdfResumenAutoevGraf01.Value = hdfResumenAutoevGraf01.Value.Substring(0, hdfResumenAutoevGraf01.Value.Length - 1);


                DataTable dtColab = objBFIE.GetResumenGrafico02Y03(Rut, NomInstrumentoEmpleado, Inicio, Fin, 1);
                if (dtColab.Rows.Count > 0)
                {
                    int cantSecciones = Utiles.ConvertToInt16(dtColab.Rows[0][0]) - 1;
                    int i = 0;
                    foreach (DataRow drColab in dtColab.Rows)
                    {
                        if (i <= cantSecciones)
                        {
                            hdfResumenTextoGraf02.Value = hdfResumenTextoGraf02.Value + "'" + drColab[1] + "',";
                            i++;
                        }
                    }
                    if (hdfResumenTextoGraf02.Value.Length > 0)
                        hdfResumenTextoGraf02.Value = hdfResumenTextoGraf02.Value.Substring(0, hdfResumenTextoGraf02.Value.Length - 1);

                    hdfResumenDataGraf02.Value = "{ data: [";
                    int x = 0;
                    while (x <= (dtColab.Rows.Count - 1))
                    {
                        for (int z = 0; z <= cantSecciones; z++)
                        {
                            hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value + dtColab.Rows[x][2] + ",";
                            x++;
                        }
                        hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value.Substring(0, hdfResumenDataGraf02.Value.Length - 1) + "]";
                        if (x < (dtColab.Rows.Count - 1))
                        {
                            hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value + "}, { data: [";
                        }
                        else
                        {
                            hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value + "}";
                        }
                    }
                }
                else
                {
                    DataTable dtSecciones = objBFIE.GetResumenSeccionesGrafico02Y03(Rut, NomInstrumentoEmpleado, 1);
                    hdfResumenDataGraf02.Value = "{ data: [";
                    foreach (DataRow drSecciones in dtSecciones.Rows)
                    {
                        hdfResumenTextoGraf02.Value = hdfResumenTextoGraf02.Value + "'" + drSecciones[0] + "',";
                        hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value + "0,";
                    }

                    if (hdfResumenTextoGraf02.Value.Length > 0)
                        hdfResumenTextoGraf02.Value = hdfResumenTextoGraf02.Value.Substring(0, hdfResumenTextoGraf02.Value.Length - 1);
                    if (hdfResumenDataGraf02.Value.Length > 0)
                        hdfResumenDataGraf02.Value = hdfResumenDataGraf02.Value.Substring(0, hdfResumenDataGraf02.Value.Length - 1) + "]}";

                }



                DataTable dtPares = objBFIE.GetResumenGrafico02Y03(Rut, NomInstrumentoEmpleado, Inicio, Fin, 3);
                if (dtPares.Rows.Count > 0)
                {
                    int cantSecciones = Utiles.ConvertToInt16(dtPares.Rows[0][0]) - 1;
                    int i = 0;
                    foreach (DataRow drPares in dtPares.Rows)
                    {
                        if (i <= cantSecciones)
                        {
                            hdfResumenTextoGraf03.Value = hdfResumenTextoGraf03.Value + "'" + drPares[1] + "',";
                            i++;
                        }
                    }
                    if (hdfResumenTextoGraf03.Value.Length > 0)
                        hdfResumenTextoGraf02.Value = hdfResumenTextoGraf03.Value.Substring(0, hdfResumenTextoGraf03.Value.Length - 1);


                    hdfResumenDataGraf03.Value = "{ data: [";
                    int x = 0;
                    while (x <= (dtPares.Rows.Count - 1))
                    {
                        for (int z = 0; z <= cantSecciones; z++)
                        {
                            hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value + dtPares.Rows[x][2] + ",";
                            x++;
                        }
                        hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value.Substring(0, hdfResumenDataGraf03.Value.Length - 1) + "]";
                        if (x < (dtPares.Rows.Count - 1))
                        {
                            hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value + "}, { data: [";
                        }
                        else
                        {
                            hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value + "}";
                        }
                    }
                }
                else
                {
                    DataTable dtSecciones = objBFIE.GetResumenSeccionesGrafico02Y03(Rut, NomInstrumentoEmpleado, 3);
                    hdfResumenDataGraf03.Value = "{ data: [";
                    foreach (DataRow drSecciones in dtSecciones.Rows)
                    {
                        hdfResumenTextoGraf03.Value = hdfResumenTextoGraf03.Value + "'" + drSecciones[0] + "',";
                        hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value + "0,";
                    }

                    if (hdfResumenTextoGraf03.Value.Length > 0)
                        hdfResumenTextoGraf03.Value = hdfResumenTextoGraf03.Value.Substring(0, hdfResumenTextoGraf03.Value.Length - 1);
                    if (hdfResumenDataGraf03.Value.Length > 0)
                        hdfResumenDataGraf03.Value = hdfResumenDataGraf03.Value.Substring(0, hdfResumenDataGraf03.Value.Length - 1) + "]}";

                }


                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('8');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkVerHojaDeVida_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                HiddenField hdfRutEmpleado = (HiddenField)fila.FindControl("hdfRutEmpleado");
                Int64 Rut = Utiles.ConvertToInt64(hdfRutEmpleado.Value);
                ViewState["RutEmpleado"] = Rut;

                ConsultarHojaDeVida(Rut);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('9');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void btnAgregarHojaVida_Click(object sender, EventArgs e)
        {
            try
            { 
                BFHOJADEVIDA objBFHV = new BFHOJADEVIDA();
                EHOJADEVIDA objHV = new EHOJADEVIDA();
                objHV.OBSERVACION = txtAgregarComentario.Text;
                objHV.RUTEMPLEADO = Utiles.ConvertToInt64(ViewState["RutEmpleado"]);
                objHV.RUTUSUARIO = objSession.RutUsuario;
                objHV.IsPersisted = false;
                objHV.FECHAINGRESO = DateTime.Now;
                objBFHV.Save(objHV);
                txtAgregarComentario.Text = "";
                ConsultarHojaDeVida(Utiles.ConvertToInt64(ViewState["RutEmpleado"]));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('9');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void ConsultarHojaDeVida(Int64 Rut)
        {
            DataTable dt = new DataTable();
            BFHOJADEVIDA objBFHV = new BFHOJADEVIDA();

            objWEB.LlenaGrilla(ref this.grdHojaDeVida, objBFHV.GetHOJADEVIDABYRUTEMPLEADO(Rut).Cast<DomainObject>().ToList(), 100);
        }

        protected void lnkKIPVigente_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                HiddenField hdfRutEmpleado = (HiddenField)fila.FindControl("hdfRutEmpleado");
                Int64 Rut = Utiles.ConvertToInt64(hdfRutEmpleado.Value);
                ViewState["RutEmpleado"] = Rut;
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                DataTable dt = objIN.GetMisKPIVigente(Rut);  

                if (dt.Rows.Count > 0)
                {
                    string CodInstrumentoEmpleado = dt.Rows[0]["COD_INSTRUMENTO_EMPLEADO"].ToString();
                    string strRuta = Page.ResolveUrl("~/modulos/evaluacion/evaluacion.aspx?CodInstrumentoEmpleado=" + CodInstrumentoEmpleado); // + "&Modo=MisEvaluaciones");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
                }
                else
                {
                    litSinKPI.Visible = true;
                    litCatchError.Visible = false;
                    litError.Visible = false;
                    litSinAcceso.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
                }

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void lnkPlanDesarrollo_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                HiddenField hdfRutEmpleado = (HiddenField)fila.FindControl("hdfRutEmpleado");
                Int64 Rut = Utiles.ConvertToInt64(hdfRutEmpleado.Value);
                ViewState["RutEmpleado"] = Rut;

                ConsultarPlanDesarrollo(Rut);

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkMiDesempeno_Click(object sender, EventArgs e)
        {
            CambiarCssSubMenu(1);
        }

        protected void lnkMisKPI_Click(object sender, EventArgs e)
        {
            CambiarCssSubMenu(2);
        }

        protected void lnkDesempenoFicha_Click(object sender, EventArgs e)
        {
            CambiarCssSubMenu(3);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('7');", true);
        }

        protected void lnkKPIFicha_Click(object sender, EventArgs e)
        {
            CambiarCssSubMenu(4);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('7');", true);
        }

        protected void CambiarCssMenu(int op)
        {
            this.liMisColaboradores.Attributes.Remove("class");
            this.liMisEvaluaciones.Attributes.Remove("class");
            this.liKPI.Attributes.Remove("class");
            this.liMiEquipo.Attributes.Remove("class");
            this.liMisVisaciones.Attributes.Remove("class");

            switch (op)
            {
                case 1:
                    liMisColaboradores.Attributes.Add("class", "active");
                    break;
                case 2:
                    liMisEvaluaciones.Attributes.Add("class", "active");
                    break;
                case 3:
                    liKPI.Attributes.Add("class", "active");
                    break;
                case 4:
                    liMiEquipo.Attributes.Add("class", "active");
                    break;
                case 5:
                    liMisVisaciones.Attributes.Add("class", "active");
                    break;
            }
        }

        protected void CambiarCssSubMenu(int op)
        {

            switch (op)
            {
                case 1:
                    this.liMiDesempeno.Attributes.Remove("class");
                    this.liMisKPI.Attributes.Remove("class");
                    liMiDesempeno.Attributes.Add("class", "active");
                    mtvHistorial.ActiveViewIndex = 0;
                    CambiarCssMenu(2);
                    break;
                case 2:
                    this.liMiDesempeno.Attributes.Remove("class");
                    this.liMisKPI.Attributes.Remove("class");
                    liMisKPI.Attributes.Add("class", "active");
                    mtvHistorial.ActiveViewIndex = 1;
                    CambiarCssMenu(2);
                    break;
                case 3:
                    this.liDesempenoFicha.Attributes.Remove("class");
                    this.liKPIFicha.Attributes.Remove("class");
                    liDesempenoFicha.Attributes.Add("class", "active");
                    mtvFicha.ActiveViewIndex = 0;
                    CambiarCssMenu(4);
                    break;
                case 4:
                    this.liDesempenoFicha.Attributes.Remove("class");
                    this.liKPIFicha.Attributes.Remove("class");
                    liKPIFicha.Attributes.Add("class", "active");
                    mtvFicha.ActiveViewIndex = 1;
                    CambiarCssMenu(4);
                    break; 
            }
        }

        protected void MostrarError()
        {
            litCatchError.Visible = true;
            litSinKPI.Visible = false;
            litError.Visible = false;
            litSinAcceso.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
        } 

        protected void btnGuardarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO  objBFIE = new BFINSTRUMENTOEMPLEADO();
                objBFIE.ActualizarPlanDesarrollo(Utiles.ConvertToInt64(ViewState["CodInstrumentoEmpleado"]), txtPlanDesarrolloMant.Text);
                txtPlanDesarrolloMant.Text = "";
                ConsultarPlanDesarrollo(Utiles.ConvertToInt64(ViewState["RutEmpleado"]));
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                MostrarError();
            }
        }

        protected void ConsultarPlanDesarrollo(Int64 Rut)
        { 
            BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
            List<EINSTRUMENTOEMPLEADO> lst = objIN.GetMiEvaluacionVigente(Rut);

            if (lst.Count > 0)
            {
                ViewState["CodInstrumentoEmpleado"] = lst[0].CODINSTRUMENTOEMPLEADO;
                txtPlanDesarrolloMant.Text = lst[0].PLAN_DESARROLLO;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('10');", true);
            }
            else
            {
                litSinKPI.Visible = true;
                litCatchError.Visible = false;
                litError.Visible = false;
                litSinAcceso.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }
    }

}