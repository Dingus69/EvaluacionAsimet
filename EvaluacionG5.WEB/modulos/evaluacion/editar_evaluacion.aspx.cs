using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.WEB.modulos.evaluacion
{
    public partial class editar_evaluacion : System.Web.UI.Page
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
                        if (Request["CodInstrumentoEmpleado"] != null)
                        {
                            ViewState["CodInstrumentoEmpleado"] = Request["CodInstrumentoEmpleado"]; if (Request["Relacion"] != null)
                            {
                                this.txtRelacion.Text = Request["Relacion"].ToString();
                            }
                            else
                            {
                                this.divRelacion.Attributes.Add("style", "display: none");
                            }
                            Cargar();
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

        protected void Cargar()
        {
            try
            {
                BFINSTRUMENTOEMPLEADO objBFIE = new BFINSTRUMENTOEMPLEADO();
                EINSTRUMENTOEMPLEADO objIE = objBFIE.GetINSTRUMENTOEMPLEADO(Utiles.ConvertToInt64(ViewState["CodInstrumentoEmpleado"]));
                ViewState["Instrumento"] = objIE;


                BFEMPLEADO objBFEM = new BFEMPLEADO();
                EEMPLEADO objEM = objBFEM.GetEMPLEADO(objIE.RUTEMPLEADO);
                this.txtRut.Text = objEM.RUTCOMPLETO;
                this.txtNombreUsuario.Text = objEM.NOMBRECOMPLETO;
                BFGERENCIA objBFGE = new BFGERENCIA();
                this.txtGerencia.Text = objEM.NOMBRE_GERENCIA;
                this.txtCargo.Text = objEM.NOMBRE_CARGO;
                this.txtResultado.Text = Utiles.ConvertToString(objIE.RESULTADO);

                lblNombreFormulario.Text = objIE.NOMINSTRUMENTOEMPLEADO;
                if (objIE.RESULTADO > 0)
                {
                    lblNombreFormulario.Text = lblNombreFormulario.Text + " - " + Utiles.ConvertToString(objIE.RESULTADO);
                }
                lblDescripcion.Text = objIE.DESCRIPCION;
                lblObservacion.Text = objIE.OBSERVACION;
                objWEB.LlenaGrilla(ref this.grdSecciones, objIE.SECCIONES.Cast<DomainObject>().ToList(), 100);
                BFINSTRUMENTO objBFIN = new BFINSTRUMENTO();
                EINSTRUMENTO objIN = objBFIN.GetINSTRUMENTO(Utiles.ConvertToInt64(objIE.CODINSTRUMENTO));
                BFESCALA objBFES = new BFESCALA();
                EESCALA objES = objBFES.GetESCALA(Utiles.ConvertToInt64(objIN.CODESCALA));
                
                switch (Utiles.ConvertToString(objIE.CODESTADOEVAL))
                {
                    case "1":
                        btnVolver.Visible = true;
                        btnGuardar.Visible = true;
                        break;
                    case "2":
                        btnVolver.Visible = true;
                        btnGuardar.Visible = false;
                        break;
                    case "3":
                        btnVolver.Visible = true;
                        btnGuardar.Visible = false;
                        break;
                    case "4":
                        btnVolver.Visible = true;
                        btnGuardar.Visible = false;
                        break;
                    case "5":
                        btnVolver.Visible = true;
                        btnGuardar.Visible = false;
                        break;
                    case "6":
                        btnVolver.Visible = true;
                        btnGuardar.Visible = false;
                        break;
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

        protected void lnkAgregarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                txtPreguntaMant.Text = "";
                txtDescripPreguntaMant.Text = "";
                txtAccionPreguntaMant.Text = "";
                txtCompromisoPreguntaMant.Text = "";
                txtIndicadorPreguntaMant.Text = "";
                this.hdfCodSeccion.Value = ((HiddenField)fila.FindControl("hdfCodSeccion")).Value;

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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                string strRuta = Page.ResolveUrl("~/modulos/evaluacion/dashboard.aspx"); 
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

        protected void grdSecciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Utiles.ConvertToBoolean(((HiddenField)e.Row.FindControl("hdfPreguntasNuevas")).Value))
                    {
                        ((HtmlGenericControl)e.Row.FindControl("divAgregarPregunta")).Visible = true;
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

        protected void btnGuardarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                EINSTRUMENTOEMPLEADO objIE = (EINSTRUMENTOEMPLEADO)ViewState["Instrumento"];
                int Indice = 0;
                foreach (ESECCIONINSTRUMENTOEMPLEADO objSE in objIE.SECCIONES)
                {
                    if (objSE.CODSECCIONINSTRUMENTO == Utiles.ConvertToDecimal(this.hdfCodSeccion.Value))
                    {
                        EPREGUNTAEMPLEADO objPR = new EPREGUNTAEMPLEADO();
                        objPR.TEXTO = txtPreguntaMant.Text;
                        objPR.DESCRIPCION = txtDescripPreguntaMant.Text;
                        objPR.ACCION = txtAccionPreguntaMant.Text;
                        objPR.COMPROMISO = txtCompromisoPreguntaMant.Text;
                        objPR.INDICADOR = txtIndicadorPreguntaMant.Text;
                        objIE.SECCIONES[Indice].PREGUNTAS.Add(objPR);
                    }
                    Indice = Indice + 1;
                }
                ViewState["Instrumento"] = objIE;
                objWEB.LlenaGrilla(ref this.grdSecciones, objIE.SECCIONES.Cast<DomainObject>().ToList(), 100);
                
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {

                BFINSTRUMENTOEMPLEADO objBF = new BFINSTRUMENTOEMPLEADO();
                EINSTRUMENTOEMPLEADO objIE = (EINSTRUMENTOEMPLEADO)ViewState["Instrumento"];

                foreach (GridViewRow grdRowSE in this.grdSecciones.Rows)
                {
                    Decimal CodSeccion = Utiles.ConvertToDecimal(((HiddenField)grdRowSE.FindControl("hdfCodSeccion")).Value);
                    foreach (ESECCIONINSTRUMENTOEMPLEADO objSIE in objIE.SECCIONES)
                    {
                        if (CodSeccion == objSIE.CODSECCIONINSTRUMENTO)
                        {
                            Double PonderacionTotal = 0.0;
                            int Indice = 0;
                            foreach (GridViewRow grdRowPR in ((GridView)grdRowSE.FindControl("grdPreguntas")).Rows)
                            {
                                PonderacionTotal = PonderacionTotal + Utiles.ConvertToDouble(((TextBox)grdRowPR.FindControl("txtPonderacionPregunta")).Text);
                                objSIE.PREGUNTAS[Indice].PONDERACION = Utiles.ConvertToDouble(((TextBox)grdRowPR.FindControl("txtPonderacionPregunta")).Text);
                                Indice = Indice + 1;
                            }
                            if (PonderacionTotal != 100.0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
                                return;
                            }
                        }
                    }
                }
                objBF.ActualizarPreguntas(objIE);
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
    }
}