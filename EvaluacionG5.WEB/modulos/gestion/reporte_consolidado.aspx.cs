﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.WEB.modulos.gestion
{
    public partial class reporte_consolidado : System.Web.UI.Page
    {
        ESESSIONUSUARIO objSession;
        UtilesWEB objWEB = new UtilesWEB();

        private void ValidaSession()
        {
            if (objWEB.CheckeaSessionUsuario())
            {
                objSession = objWEB.CargaSessionUsuario();
                if (!objSession.EsGestion)
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
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                objWEB.LlenaDDL(ref ddlEvaluaciones, objIN.Asignaciones(), "NOM_INSTRUMENTO_EMPLEADO", "NOM_INSTRUMENTO_EMPLEADO");

                BFEMPRESA objBFEMP = new BFEMPRESA();
                objWEB.LlenaDDL(ref this.ddlEmpresa, objBFEMP.GetEMPRESAAll().Cast<DomainObject>().ToList(), "RUTEMPRESA", "NOMBREFANTASIA");
                objWEB.AgregaValorDDL(ref this.ddlEmpresa, "Sin Información", "0");
                this.ddlEmpresa.SelectedValue = "0";
                if (ddlEmpresa.Items.Count > 1)
                {
                    this.divEmpresa.Visible = true;
                }

                if (objSession.EsSuperAdministrador)
                {
                    this.divEmpresa.Visible = true;
                }
                else
                {
                    this.divEmpresa.Visible = false;
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
                BFEMPLEADO objBFEM = new BFEMPLEADO();
                objWEB.LlenaDDL(ref this.ddlEvaluador, objBFEM.GetEvaluadoresPorEvaluacion(this.ddlEvaluaciones.SelectedValue), "RUT_EMPLEADO", "NOMBRE");
                objWEB.AgregaValorDDL(ref this.ddlEvaluador, "Todos", "0");
                this.ddlEvaluador.SelectedValue = "0";
                if (ddlEvaluador.Items.Count > 1)
                {
                    this.divEvaluador.Visible = true;
                }
                objWEB.LlenaDDL(ref this.ddlVisador, objBFEM.GetVisadoresPorEvaluacion(this.ddlEvaluaciones.SelectedValue), "RUT_EMPLEADO", "NOMBRE");
                objWEB.AgregaValorDDL(ref this.ddlVisador, "Todos", "0");
                this.ddlVisador.SelectedValue = "0";
                if (ddlVisador.Items.Count > 1)
                {
                    this.ddlVisador.Visible = true;
                }


                Consultar();
                VerDetalles(1);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Consultar();
                VerDetalles(1);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void Consultar()
        {
            try
            {
                this.litValorAsignadas.Text = "0";
                this.litValorEnBorrador.Text = "0";
                this.litValorCerradas.Text = "0";
                Int64 RutEmpresa;
                if (objSession.EsSuperAdministrador)
                {
                    RutEmpresa = Utiles.ConvertToInt64(this.ddlEmpresa.SelectedValue);
                }
                else
                {
                    RutEmpresa = objSession.RutEmpresa;
                }
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                DataTable dtValores = objIN.CantidadEvalPorEstado(this.ddlEvaluaciones.SelectedValue,
                                        RutEmpresa, this.ddlGerencia.SelectedValue,
                                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                                        this.ddlClasificador2.SelectedValue, Utiles.ConvertToInt64(this.ddlEvaluador.SelectedValue),
                                        Utiles.ConvertToInt64(this.ddlVisador.SelectedValue));
                foreach (DataRow dr in dtValores.Rows)
                {
                    switch (dr["CODESTADOEVAL"].ToString())
                    {
                        case "1":
                            this.litValorAsignadas.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "2":
                            this.litValorEnBorrador.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "3":
                            //this.litValorEnApelacion.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "4":
                            //this.litValorVisadas.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "5":
                            this.litValorCerradas.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
                        case "6":
                            //this.litValorInformadas.Text = Utiles.ConvertToString(dr["CANTIDAD"]);
                            break;
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

        protected void lnkVerAsignadas_Click(object sender, EventArgs e)
        {
            try
            {
                this.grillaEvaluaciones.Attributes.Remove("class");
                this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_1 cbp-mc-1column");
                VerDetalles(1);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkVerEnBorrador_Click(object sender, EventArgs e)
        {
            try
            {
                this.grillaEvaluaciones.Attributes.Remove("class");
                this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_2 cbp-mc-1column");
                VerDetalles(2);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkVerApeladas_Click(object sender, EventArgs e)
        {
            try
            {
                this.grillaEvaluaciones.Attributes.Remove("class");
                this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_3 cbp-mc-1column");
                VerDetalles(3);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkVerVisadas_Click(object sender, EventArgs e)
        {
            try
            {
                this.grillaEvaluaciones.Attributes.Remove("class");
                this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_4 cbp-mc-1column");
                VerDetalles(4);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkVerCerradas_Click(object sender, EventArgs e)
        {
            try
            {
                this.grillaEvaluaciones.Attributes.Remove("class");
                this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_5 cbp-mc-1column");
                VerDetalles(5);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkVerInformadas_Click(object sender, EventArgs e)
        {
            try
            {
                this.grillaEvaluaciones.Attributes.Remove("class");
                this.grillaEvaluaciones.Attributes.Add("class", "table-wrapper_6 cbp-mc-1column");
                VerDetalles(6);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void VerDetalles(decimal CodEstado)
        {
            try
            {
                Int64 RutEmpresa;
                if (objSession.EsSuperAdministrador)
                {
                    RutEmpresa = Utiles.ConvertToInt64(this.ddlEmpresa.SelectedValue);
                }
                else
                {
                    RutEmpresa = objSession.RutEmpresa;
                }
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                objWEB.LlenaGrilladt(ref this.grdResultados, objIN.GetInstrumentosPorEstado(this.ddlEvaluaciones.SelectedValue,
                                        RutEmpresa, this.ddlGerencia.SelectedValue,
                                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                                        this.ddlClasificador2.SelectedValue, Utiles.ConvertToInt64(this.ddlEvaluador.SelectedValue),
                                        Utiles.ConvertToInt64(this.ddlVisador.SelectedValue),  CodEstado), 100);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnDescargarConsolidado_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 RutEmpresa;
                if (objSession.EsSuperAdministrador)
                {
                    RutEmpresa = Utiles.ConvertToInt64(this.ddlEmpresa.SelectedValue);
                }
                else
                {
                    RutEmpresa = objSession.RutEmpresa;
                }
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                objIN.GetReporteSabanaDetalle(this.ddlEvaluaciones.SelectedValue,
                                        RutEmpresa, this.ddlGerencia.SelectedValue,
                                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                                        this.ddlClasificador2.SelectedValue, Utiles.ConvertToInt64(this.ddlEvaluador.SelectedValue),
                                        Utiles.ConvertToInt64(this.ddlVisador.SelectedValue));
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnDescargarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 RutEmpresa;
                if (objSession.EsSuperAdministrador)
                {
                    RutEmpresa = Utiles.ConvertToInt64(this.ddlEmpresa.SelectedValue);
                }
                else
                {
                    RutEmpresa = objSession.RutEmpresa;
                }
                BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
                objIN.GetReporteSabanaDetalle(this.ddlEvaluaciones.SelectedValue,
                                        RutEmpresa, this.ddlGerencia.SelectedValue,
                                        this.ddlCentroCosto.SelectedValue, this.ddlSucursal.SelectedValue,
                                        this.ddlArea.SelectedValue, this.ddlCargo.SelectedValue,
                                        this.ddlRol.SelectedValue, this.ddlClasificador1.SelectedValue,
                                        this.ddlClasificador2.SelectedValue, Utiles.ConvertToInt64(this.ddlEvaluador.SelectedValue),
                                        Utiles.ConvertToInt64(this.ddlVisador.SelectedValue));
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