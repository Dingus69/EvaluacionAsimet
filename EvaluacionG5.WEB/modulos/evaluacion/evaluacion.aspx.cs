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

namespace EvaluacionG5.WEB.modulos.evaluacion
{
    public partial class evaluacion : System.Web.UI.Page
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
                {
                    if (!Page.IsPostBack)
                    {
                        InicializarFormulario();
                        if (Request["CodInstrumentoEmpleado"] != null)
                        {
                            ViewState["CodInstrumentoEmpleado"] = Request["CodInstrumentoEmpleado"];
                            if (Request["Relacion"] != null)
                            {
                                this.txtRelacion.Text = Request["Relacion"].ToString();
                            }
                            Cargar();
                            if (Request["Modo"] != null)
                            {
                                ViewState["Modo"] = Request["Modo"];
                                if (Request["Modo"] == "MisEvaluaciones")
                                {
                                    this.divRelacion.Attributes.Add("style", "display: none");
                                    btnVolver.Visible = true;
                                    btnBorrador.Visible = false;
                                    btnGuardarEvaluacion.Visible = false;
                                    btnVisar.Visible = false;
                                    btnApelar.Visible = false;
                                    btnInformar.Visible = false;
                                }
                                if (Request["Modo"] == "Visar")
                                {
                                    btnVolver.Visible = true;
                                    btnBorrador.Visible = false;
                                    btnGuardarEvaluacion.Visible = false;
                                    btnApelar.Visible = false;
                                    btnInformar.Visible = false;

                                    btnVisar.Visible = true;
                                }
                                if (Request["Modo"] == "SU")
                                {
                                    btnVolver.Visible = true;
                                    btnBorrador.Visible = true;
                                    btnGuardarEvaluacion.Visible = true;
                                    btnApelar.Visible = false;
                                    btnInformar.Visible = false;

                                    btnVisar.Visible = false;
                                }
                            }
                        }
                    }

                    //if (this.Request.Params["__EVENTTARGET"] == "CalculaNota")
                    //{
                    //    NotaTiempoRealAbierta();
                    //}


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
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                EINSTRUMENTOEMPLEADO objIE = objBFIE.GetINSTRUMENTOEMPLEADO(Utiles.ConvertToInt64(ViewState["CodInstrumentoEmpleado"]));

                BFEMPLEADO objBFEM = new BFEMPLEADO();
                EEMPLEADO objEM = objBFEM.GetEMPLEADO(objIE.RUTEMPLEADO);
                this.txtRut.Text = objEM.RUTCOMPLETO;
                this.txtNombreUsuario.Text = objEM.NOMBRECOMPLETO;
                BFGERENCIA objBFGE = new BFGERENCIA();
                this.txtGerencia.Text = objEM.NOMBRE_GERENCIA;
                this.txtCargo.Text = objEM.NOMBRE_CARGO;
                this.txtResultado.Text = Utiles.ConvertToString(objIE.RESULTADO);

                lblNombreFormulario.Text = objIE.NOMINSTRUMENTOEMPLEADO;
                hdfNombreFormulario.Value = objIE.NOMINSTRUMENTOEMPLEADO;
                if (objIE.RESULTADO > 0)
                {
                    lblNombreFormulario.Text = lblNombreFormulario.Text + " - " + Utiles.ConvertToString(objIE.RESULTADO);
                }
                lblDescripcion.Text = objIE.DESCRIPCION;
                lblObservacion.Text = objIE.OBSERVACION;
                if ((lblDescripcion.Text.Trim() == "") && (lblObservacion.Text.Trim() == ""))
                {
                    divDescripcionObservacion.Style.Add("display", "none");
                }
                objWEB.LlenaGrilla(ref this.grdSecciones, objIE.SECCIONES.Cast<DomainObject>().ToList(), 100);
                BFINSTRUMENTO objBFIN = new BFINSTRUMENTO();
                EINSTRUMENTO objIN = objBFIN.GetINSTRUMENTO(Utiles.ConvertToInt64(objIE.CODINSTRUMENTO));
                BFESCALA objBFES = new BFESCALA();
                EESCALA objES = objBFES.GetESCALA(Utiles.ConvertToInt64(objIN.CODESCALA));
                lblInstrucciones.Text = objES.INSTRUCCIONES;
                if (lblInstrucciones.Text.Trim() == "")
                {
                    divDescripcionObservacion.Style.Add("divInstrucciones", "none");
                }
                ViewState["VALORMENOR"] = objES.VALORMENOR;
                ViewState["VALORMAYOR"] = objES.VALORMAYOR;
                hdfFlagRangos.Value = Utiles.ConvertToString(objES.FLAG_RANGOS);
                if (objES.FLAG_RANGOS == true)
                {
                    NotaTiempoRealRangos();
                }
                else
                {
                    NotaTiempoRealAbierta();
                }
                foreach (GridViewRow grdRow in this.grdSecciones.Rows)
                {
                    foreach (GridViewRow grdRowPR in ((GridView)grdRow.FindControl("grdPreguntas")).Rows)
                    {
                        RadioButtonList rdl = (RadioButtonList)grdRowPR.FindControl("rdlRangos");
                        objWEB.LlenaRadioButtonList(ref rdl, objES.RANGOS.Cast<DomainObject>().ToList(), "VALORRANGO", "NOMBRERANGO");
                        if (((TextBox)grdRowPR.FindControl("txtResultado")).Text != "")
                        {
                            rdl.SelectedValue = ((TextBox)grdRowPR.FindControl("txtResultado")).Text;
                        }
                        ((RangeValidator)grdRowPR.FindControl("rvEscala")).MinimumValue = Utiles.ConvertToString(objES.VALORMENOR);
                        ((RangeValidator)grdRowPR.FindControl("rvEscala")).MaximumValue = Utiles.ConvertToString(objES.VALORMAYOR);
                    }
                    if (objES.FLAG_RANGOS)
                    {
                        ((GridView)grdRow.FindControl("grdPreguntas")).Columns[3].Visible = false;
                        ((GridView)grdRow.FindControl("grdPreguntas")).Columns[4].Visible = true;
                    }
                    else
                    {
                        ((GridView)grdRow.FindControl("grdPreguntas")).Columns[3].Visible = true;
                        ((GridView)grdRow.FindControl("grdPreguntas")).Columns[4].Visible = false;
                    }
                }
                
                switch (Utiles.ConvertToString(objIE.CODESTADOEVAL))
                {
                    case "1":
                        btnVolver.Visible = true;
                        btnBorrador.Visible = true;
                        btnGuardarEvaluacion.Visible = true;
                        btnVisar.Visible = false;
                        btnApelar.Visible = false;
                        if (objIE.RUTEVALUADOR == objSession.RutUsuario)
                        {
                            //btnInformar.Visible = true;
                            btnInformar.Visible = false;
                        }
                        else
                        {
                            btnInformar.Visible = false;
                        }
                        break;
                    case "2":
                        btnVolver.Visible = true;
                        btnBorrador.Visible = true;
                        btnGuardarEvaluacion.Visible = true;
                        btnVisar.Visible = false;
                        btnApelar.Visible = false;
                        if (objIE.RUTEVALUADOR == objSession.RutUsuario)
                        {
                            //btnInformar.Visible = true;
                            btnInformar.Visible = false;
                        }
                        else
                        {
                            btnInformar.Visible = false;
                        }
                        break;
                    case "5":
                        btnVolver.Visible = true;
                        btnBorrador.Visible = false;
                        btnGuardarEvaluacion.Visible = false;
                        if (objIE.RUTEVALUADOR == objSession.RutUsuario)
                        {
                            btnTomarConocimiento.Visible = true;
                            btnInformar.Visible = false;
                        }
                        else
                        {
                            btnInformar.Visible = false;
                        }                        
                        if ((objIN.FLAG_APELACION) && (objIE.RUTEMPLEADO == objSession.RutUsuario) && (objIE.RUTEVALUADOR != objSession.RutUsuario))
                        {
                            btnApelar.Visible = true;
                        }
                        else
                        {
                            btnApelar.Visible = false;
                        }
                        if ((objIN.FLAG_VISACION) && (objIE.RUTVISADOR == objSession.RutUsuario))
                        {
                            btnVisar.Visible = true;
                        }
                        else
                        {
                            btnVisar.Visible = false;
                        }
                        break;
                }
                if ((objIE.COD_TIPO_INTRUMENTO == 2) && (objIE.RUTEMPLEADO == objSession.RutUsuario))
                {
                    btnVerBitacora.Visible = false;
                    btnComentario.Visible = false;
                    btnBorrador.Visible = false;
                    btnInformar.Visible = false;
                    btnTomarConocimiento.Visible = false;
                    btnVisar.Visible = false;
                    btnApelar.Visible = false;
                    btnGuardarEvaluacion.Visible = false;
                }
                else if ((objIE.COD_TIPO_INTRUMENTO == 2) && (objIE.RUTEVALUADOR == objSession.RutUsuario))
                {
                    if (objIE.CODESTADOEVAL == 5)
                    { 
                    }
                    else
                    {
                        btnVerBitacora.Visible = false;
                        btnComentario.Visible = false;
                        btnInformar.Visible = false;
                        btnTomarConocimiento.Visible = false;
                        btnVisar.Visible = false;
                        btnApelar.Visible = false;
                        btnBorrador.Visible = true;
                        btnGuardarEvaluacion.Visible = true;
                    }
                }
                NotaTiempoRealRangos();
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void imgVerDetalles_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgEditar = (ImageButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                txtPreguntaMant.Text = ((Label)fila.FindControl("lblPregunta")).Text;
                txtDescripPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfDescripcion")).Value;
                txtAccionPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfAccion")).Value;
                txtCompromisoPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfCompromiso")).Value;
                txtIndicadorPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfIndicador")).Value;
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

        protected void lnkVerDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                txtPreguntaMant.Text = ((Label)fila.FindControl("lblPregunta")).Text;
                txtDescripPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfDescripcion")).Value;
                txtAccionPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfAccion")).Value;
                txtCompromisoPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfCompromiso")).Value;
                txtIndicadorPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfIndicador")).Value;
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

        protected void lnkAgregarComentario_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                txtComentario.Text = ((HiddenField)fila.FindControl("hdfComentario")).Value;
                hdfCodPreguntaEditar.Value = ((HiddenField)fila.FindControl("hdfCodPregunta")).Value;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('5');", true);
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
                string strRuta = Page.ResolveUrl("~/modulos/evaluacion/dashboard.aspx");
                if (ViewState["Modo"] != null)
                {
                    if (Utiles.ConvertToString(ViewState["Modo"]) == "SU")
                    {
                        strRuta = Page.ResolveUrl("~/modulos/administracion/lista_asignaciones.aspx");
                    }
                }
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //GuardarResultados();
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnBorrador_Click(object sender, EventArgs e)
        {
            try
            {
                btnContinuarBorrador.Visible = true;
                btnContinuarCerrarEvaluacion.Visible = false;
                btnContinuarVisar.Visible = false;
                btnContinuarApelar.Visible = false;
                btnContinuarInformar.Visible = false;
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

        protected void btnGuardarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                btnContinuarBorrador.Visible = false;
                btnContinuarCerrarEvaluacion.Visible = true;
                btnContinuarVisar.Visible = false;
                btnContinuarApelar.Visible = false;
                btnContinuarInformar.Visible = false;
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

        protected void btnVisar_Click(object sender, EventArgs e)
        {
            try
            {
                btnContinuarBorrador.Visible = false;
                btnContinuarCerrarEvaluacion.Visible = false;
                btnContinuarVisar.Visible = true;
                btnContinuarApelar.Visible = false;
                btnContinuarInformar.Visible = false;
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

        protected void btnApelar_Click(object sender, EventArgs e)
        {
            try
            {
                btnContinuarBorrador.Visible = false;
                btnContinuarCerrarEvaluacion.Visible = false;
                btnContinuarVisar.Visible = false;
                btnContinuarApelar.Visible = true;
                btnContinuarInformar.Visible = false;
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

        protected void btnInformar_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                EINSTRUMENTOEMPLEADO objIE = objBFIE.GetINSTRUMENTOEMPLEADO(Utiles.ConvertToInt32(ViewState["CodInstrumentoEmpleado"]));

                BFEMPLEADO objBFEM = new BFEMPLEADO();
                EEMPLEADO objEM = objBFEM.GetEMPLEADO(objIE.RUTEMPLEADO);
                hdfEmailEmpleado.Value = objEM.EMAIL;
                hdfNombreEmpleado.Value = objEM.NOMBRECOMPLETO;
                BFPARAMETROSGENERALES objBFPA = new BFPARAMETROSGENERALES();
                hdfURL.Value = objBFPA.GetPARAMETROSGENERALESAll()[0].URL_PLATAFORMA;

                BFCORREO objBFCO = new BFCORREO();
                List<ECORREO> lst = objBFCO.GetCORREOAll();
                objWEB.LlenaDDL(ref this.ddlAsuntoCorreo, lst.Cast<DomainObject>().ToList(), "CODCORREO", "ASUNTO");
                ECORREO objCO = objBFCO.GetCORREO(Utiles.ConvertToInt64(ddlAsuntoCorreo.SelectedValue));
                this.txtCuerpoCorreo.Text = objCO.CUERPO.Replace("_NOMBREUSUARIO", hdfNombreEmpleado.Value).Replace("_URL", hdfURL.Value);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('10');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnContinuarCerrarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarResultados(5);
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

        protected void btnContinuarBorrador_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarResultados(2);
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

        protected void btnContinuarVisar_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('6');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnContinuarApelar_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('7');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnContinuarInformar_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                objBFIE.Informar(Utiles.ConvertToDecimal(ViewState["CodInstrumentoEmpleado"]));
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

        protected void GuardarResultados(Int16 CodEstado)
        {
            try
            {
                if (ValidarDatos())
                {
                    List<EPREGUNTASECCIONEMPLEADO> lstPSE = new List<EPREGUNTASECCIONEMPLEADO>();
                    EPREGUNTASECCIONEMPLEADO objPSE;
                    foreach (GridViewRow grdRowSeccion in this.grdSecciones.Rows)
                    {
                        foreach (GridViewRow grdRowPregunta in ((GridView)grdRowSeccion.FindControl("grdPreguntas")).Rows)
                        {
                            if ((((TextBox)grdRowPregunta.FindControl("txtResultado")).Text == "") && (Utiles.ConvertToBoolean(hdfFlagRangos.Value) != true))
                            {
                                if (CodEstado == 5)
                                {
                                    litErrorVacios.Visible = true;
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
                                    return;
                                }
                            }
                            else
                            {
                                objPSE = new EPREGUNTASECCIONEMPLEADO();
                                objPSE.CODSECCIONINSTRUMENTO = Utiles.ConvertToDecimal(((HiddenField)grdRowSeccion.FindControl("hdfCodSeccion")).Value);
                                objPSE.CODPREGUNTAEMPLEADO = Utiles.ConvertToDecimal(((HiddenField)grdRowPregunta.FindControl("hdfCodPregunta")).Value);
                                objPSE.COMENTARIO = Utiles.ConvertToString(((HiddenField)grdRowPregunta.FindControl("hdfComentario")).Value);
                                if (Utiles.ConvertToBoolean(hdfFlagRangos.Value))
                                {
                                    objPSE.RESULTADO = Utiles.ConvertToDouble(((RadioButtonList)grdRowPregunta.FindControl("rdlRangos")).SelectedValue);
                                }
                                else
                                {
                                    objPSE.RESULTADO = Utiles.ConvertToDouble(((TextBox)grdRowPregunta.FindControl("txtResultado")).Text);
                                }
                                lstPSE.Add(objPSE);
                            }
                        }
                    }
                    string Modo = "";
                    if (ViewState["Modo"] != null)
                    {
                        Modo = Utiles.ConvertToString(ViewState["Modo"]);
                    }
                    BFPREGUNTASECCIONEMPLEADO objBFPSE = new BFPREGUNTASECCIONEMPLEADO();
                    objBFPSE.Evaluar(lstPSE, CodEstado, Utiles.ConvertToDecimal(ViewState["CodInstrumentoEmpleado"]), objSession.RutUsuario, Modo);
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

        protected Boolean ValidarDatos()
        {
            try
            {
                Double Menor = (Double)ViewState["VALORMENOR"];
                Double Mayor = (Double)ViewState["VALORMAYOR"];
                foreach (GridViewRow grdRow in this.grdSecciones.Rows)
                {
                    foreach (GridViewRow grdRowPR in ((GridView)grdRow.FindControl("grdPreguntas")).Rows)
                    {
                        Double Resultado = 0;
                        if (Utiles.ConvertToBoolean(hdfFlagRangos.Value))
                        {
                            Resultado = Utiles.ConvertToDouble(((RadioButtonList)grdRowPR.FindControl("rdlRangos")).SelectedValue);
                        }
                        else
                        {
                            Resultado = Utiles.ConvertToDouble(((TextBox)grdRowPR.FindControl("txtResultado")).Text);
                        }
                        
                        if ((Resultado < Menor) || (Resultado > Mayor))
                        {
                            litErrorRango.Visible = true;
                            litSinComentario.Visible = false;
                            litErrorVacios.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
                            return false;
                        }
                        if (((Resultado == Menor) || (Resultado == Mayor)) && (Utiles.ConvertToString(((HiddenField)grdRowPR.FindControl("hdfComentario")).Value) == ""))
                        {
                            litErrorRango.Visible = false;
                            litSinComentario.Visible = true;
                            litErrorVacios.Visible = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                litErrorRango.Visible = false;
                litSinComentario.Visible = false;
                litErrorVacios.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
                return false;
            }
        }

        protected void btnAgregarComentario_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow grdSE in this.grdSecciones.Rows)
                {
                    foreach (GridViewRow grdPR in ((GridView)grdSE.FindControl("grdPreguntas")).Rows)
                    {
                        if (((HiddenField)grdPR.FindControl("hdfCodPregunta")).Value == hdfCodPreguntaEditar.Value)
                        {
                            ((HiddenField)grdPR.FindControl("hdfComentario")).Value = txtComentario.Text;
                        }
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

        protected void btnApelarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();                
                objBFIE.Apelar(Utiles.ConvertToInt64(ViewState["CodInstrumentoEmpleado"]), Utiles.ConvertToString(this.txtMotivoApelacion.Text));
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

        protected void btnVisarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                objBFIE.Visar(Utiles.ConvertToDecimal(ViewState["CodInstrumentoEmpleado"]), Utiles.ConvertToString(this.txtDetalleApelacion.Text));
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

        protected void btnAgregarComentarioEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                string Modo = "";
                if (ViewState["Modo"] != null)
                {
                    Modo = Utiles.ConvertToString(ViewState["Modo"]);
                }
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                objBFIE.AgregarComentario(Utiles.ConvertToDecimal(ViewState["CodInstrumentoEmpleado"]), Utiles.ConvertToString(this.txtComentarioEvaluacion.Text), objSession.RutUsuario, Modo);
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

        protected void btnComentario_Click(object sender, EventArgs e)
        {
            try
            {
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

        protected void btnVerBitacora_Click(object sender, EventArgs e)
        {
            string CodInstrumentoEmpleado = Utiles.ConvertToString(ViewState["CodInstrumentoEmpleado"]);

            BFBITACORA objBFBI = new BFBITACORA();
            System.Data.DataTable dt = objBFBI.GetBitacoraInstrumentoEmpleado(Utiles.ConvertToDecimal(CodInstrumentoEmpleado));

            objWEB.LlenaGrilladt(ref this.grdBitacora, dt, 100);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('9');", true);
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
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void ddlAsuntoCorreo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BFCORREO objBFCO = new BFCORREO();
            ECORREO objCO = objBFCO.GetCORREO(Utiles.ConvertToInt64(ddlAsuntoCorreo.SelectedValue));
            this.txtCuerpoCorreo.Text = objCO.CUERPO.Replace("_NOMBREUSUARIO", hdfNombreEmpleado.Value).Replace("_URL", hdfURL.Value);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('10');", true);
        }

        protected void btnTomarConocimiento_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('11');", true);
        }

        protected void rdlRangos_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotaTiempoRealRangos();
        }

        protected void txtResultado_TextChanged(object sender, EventArgs e)
        {
            NotaTiempoRealAbierta();
        }

        protected void NotaTiempoRealRangos()
        {
            Double ResultadoFinal = 0.0;
            foreach (GridViewRow grdRowSec in grdSecciones.Rows)
            {
                Double PondSeccion = Utiles.ConvertToDouble(((Label)grdRowSec.FindControl("lblPonderacionSeccion")).Text);
                Double Resultado = 0.0;
                foreach (GridViewRow grdRowPre in ((GridView)grdRowSec.FindControl("grdPreguntas")).Rows)
                {
                    Double PondPregunta = Utiles.ConvertToDouble(((Label)grdRowPre.FindControl("lblPonderacion")).Text);
                    if (((RadioButtonList)grdRowPre.FindControl("rdlRangos")).SelectedIndex > -1)
                    {
                        Double valorAsignado = Utiles.ConvertToDouble(((RadioButtonList)grdRowPre.FindControl("rdlRangos")).SelectedValue);
                        Resultado = Resultado + ((PondPregunta / 100) * valorAsignado);
                    }
                }
                ((Label)grdRowSec.FindControl("lblResultadoSeccion")).Text = Utiles.ConvertToString(Math.Round(Resultado, 2));
                ResultadoFinal = ResultadoFinal + ((PondSeccion / 100) * Resultado);
            }
            txtResultado.Text = Utiles.ConvertToString(Math.Round(ResultadoFinal, 2));
            lblNombreFormulario.Text = hdfNombreFormulario.Value + " - " + Utiles.ConvertToString(Math.Round(ResultadoFinal, 2));
            litNotaCalculada.Text = Utiles.ConvertToString(Math.Round(ResultadoFinal, 2));
        }

        protected void NotaTiempoRealAbierta()
        {
            Double ResultadoFinal = 0.0;
            foreach (GridViewRow grdRowSec in grdSecciones.Rows)
            {
                Double PondSeccion = Utiles.ConvertToDouble(((Label)grdRowSec.FindControl("lblPonderacionSeccion")).Text);
                Double Resultado = 0.0;
                foreach (GridViewRow grdRowPre in ((GridView)grdRowSec.FindControl("grdPreguntas")).Rows)
                {
                    Double PondPregunta = Utiles.ConvertToDouble(((Label)grdRowPre.FindControl("lblPonderacion")).Text);
                    if (((TextBox)grdRowPre.FindControl("txtResultado")).Text != "")
                    {
                        Double valorAsignado = Utiles.ConvertToDouble(((TextBox)grdRowPre.FindControl("txtResultado")).Text);
                        Resultado = Resultado + ((PondPregunta / 100) * valorAsignado);
                    }
                }
                ((Label)grdRowSec.FindControl("lblResultadoSeccion")).Text = Utiles.ConvertToString(Resultado);
                ResultadoFinal = ResultadoFinal + ((PondSeccion / 100) * Resultado);
            }
            txtResultado.Text = Utiles.ConvertToString(ResultadoFinal);
            lblNombreFormulario.Text = hdfNombreFormulario.Value + " - " + Utiles.ConvertToString(ResultadoFinal);
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


                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('13');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void lnkVerMisEvaluaciones_Click(object sender, EventArgs e)
        {

        }

        protected void lnkVerBitacora_Click(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            string CodInstrumentoEmpleado = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodInstrumentoEmpleado")).Value);

            BFBITACORA objBFBI = new BFBITACORA();
            System.Data.DataTable dt = objBFBI.GetBitacoraInstrumentoEmpleado(Utiles.ConvertToDecimal(CodInstrumentoEmpleado));

            objWEB.LlenaGrilladt(ref this.grdBitacora, dt, 100);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('9');", true);
        }

        protected void lnkVerMisEvaluaciones_Click1(object sender, EventArgs e)
        {
            LinkButton imgEditar = (LinkButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

            string lblCodInstrumentoEmpleado = Utiles.ConvertToString(((HiddenField)fila.FindControl("hdfCodInstrumentoEmpleado")).Value);

            string strRuta = Page.ResolveUrl("~/modulos/evaluacion/evaluacion.aspx?CodInstrumentoEmpleado=" + lblCodInstrumentoEmpleado + "&Modo=MisEvaluaciones");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
        }

        protected void lnkDesempenoFicha_Click(object sender, EventArgs e)
        {
            mtvFicha.ActiveViewIndex = 0;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('12');", true);
        }

        protected void lnkKPIFicha_Click(object sender, EventArgs e)
        {
            mtvFicha.ActiveViewIndex = 1;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('12');", true);
        }

        protected void btnVerFicha_Click(object sender, EventArgs e)
        {
            CargarFichaColaborador(Utiles.RutUsrALng(txtRut.Text));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('12');", true);
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
            }
        }

        protected void btnGuardarFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                objBFIE.AcuerdoyComentariosFeedback(Utiles.ConvertToInt64(ViewState["CodInstrumentoEmpleado"]), chkAcuerdo.Checked, Utiles.ConvertToString(this.txtComentarioFeedback.Text));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('4');", true);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }
    }
}