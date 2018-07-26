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
    public partial class mantenedor_cursos : System.Web.UI.Page
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
                    CargarCombos();
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

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        protected void grdResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdResultados.PageIndex = e.NewPageIndex;
                Consultar();
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
                BFCURSO objBFCU = new BFCURSO();
                objWEB.LlenaGrilla(ref this.grdResultados, objBFCU.GetCursosByNombreAndArea(txtNombre.Text.Trim(), Utiles.ConvertToDecimal(ddlAreaBusqueda.SelectedValue)).Cast<DomainObject>().ToList(), 100);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["Modo"] = "Insertar";  

                this.txtCodigoCurso.Text = "";
                this.txtNombreCurso.Text = "";
                this.txtCodigoSence.Text = "";
                this.txtProveedorCurso.Text = "";
                this.txtDuracionCurso.Text = "0";
                this.txtLugarEjecucionCurso.Text = "";
                this.txtCostoCurso.Text = "0";
                this.txtMaxParticCurso.Text = "0";
                this.ddlAreaCurso.SelectedValue = "1";
                this.ddlModalidadCurso.SelectedValue = "1";

                this.txtCodigoCurso.Enabled = true;

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

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            try
            {

                ViewState["Modo"] = "Actualizar";
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

                this.txtCodigoCurso.Text = ((Label)fila.FindControl("lblCodigo")).Text;
                this.txtNombreCurso.Text = ((Label)fila.FindControl("lblNombre")).Text;
                this.txtCodigoSence.Text = ((HiddenField)fila.FindControl("hdfCodigoSence")).Value;
                this.txtProveedorCurso.Text = ((HiddenField)fila.FindControl("hdfProveedor")).Value;
                this.txtDuracionCurso.Text = ((HiddenField)fila.FindControl("hdfDuracion")).Value;
                this.txtLugarEjecucionCurso.Text = ((HiddenField)fila.FindControl("hdfLugarEjecucion")).Value;
                this.txtCostoCurso.Text = ((HiddenField)fila.FindControl("hdfCostoParticipante")).Value;
                this.txtMaxParticCurso.Text = ((HiddenField)fila.FindControl("hdfMaxParticipantes")).Value;
                this.ddlAreaCurso.SelectedValue = ((HiddenField)fila.FindControl("hdfCodAreaCurso")).Value;
                this.ddlModalidadCurso.SelectedValue = ((HiddenField)fila.FindControl("hdfCodModalidad")).Value;

                this.txtCodigoCurso.Enabled = false;

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
                if (!ValidarFormulario())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
                    return;
                }
                else
                {
                    BFCURSO objBFCU = new BFCURSO();
                    ECURSO objCU = new ECURSO();
                    objCU.CODCURSO = this.txtCodigoCurso.Text;
                    objCU.NOMBRECURSO = this.txtNombreCurso.Text;
                    objCU.CODIGOSENCE = this.txtCodigoSence.Text;
                    objCU.PROVEEDOR = this.txtProveedorCurso.Text;
                    objCU.DURACION = Utiles.ConvertToInt32(this.txtDuracionCurso.Text);
                    objCU.LUGAREJECUCION = this.txtLugarEjecucionCurso.Text;
                    objCU.COSTOPARTICIPANTE = Utiles.ConvertToInt64(this.txtCostoCurso.Text);
                    objCU.MAXPARTICIPANTES = Utiles.ConvertToInt32(this.txtMaxParticCurso.Text);
                    objCU.CODAREACURSO = Utiles.ConvertToDecimal(this.ddlAreaCurso.SelectedValue);
                    objCU.CODMODALIDAD = Utiles.ConvertToInt16(this.ddlModalidadCurso.SelectedValue);
                    if (ViewState["Modo"].ToString() == "Insertar")
                    {
                        objCU.IsPersisted = false;
                    }
                    else
                    {
                        objCU.IsPersisted = true;
                    }
                    objBFCU.Save(objCU);
                    Consultar();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
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

        protected Boolean ValidarFormulario()
        {
            Boolean blnResultado = true;
            try
            {
                if ((this.txtCodigoCurso.Text.Trim() == "") || (this.txtNombreCurso.Text.Trim() == ""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: El código y el nombre del curso son datos de carácter obligatorio.');", true);
                    blnResultado = false;
                }
                if (this.txtDuracionCurso.Text.Trim() == "")
                {
                    this.txtDuracionCurso.Text = "0";
                }
                if (this.txtCostoCurso.Text.Trim() == "")
                {
                    this.txtCostoCurso.Text = "0";
                }
                if (this.txtMaxParticCurso.Text.Trim() == "")
                {
                    this.txtMaxParticCurso.Text = "0";
                }
                return blnResultado; 
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
                return blnResultado;
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

        protected void Cargar()
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

        protected void CargarCombos()
        {
            try
            {
                BFAREACURSO objBFAC = new BFAREACURSO();
                objWEB.LlenaDDL(ref this.ddlAreaBusqueda, objBFAC.GetAREACURSOAll().Cast<DomainObject>().ToList(), "CODAREACURSO", "NOMAREACURSO");
                objWEB.AgregaValorDDL(ref this.ddlAreaBusqueda, "Todas", "0");
                this.ddlAreaBusqueda.SelectedValue = "0";

                objWEB.LlenaDDL(ref this.ddlAreaCurso, objBFAC.GetAREACURSOAll().Cast<DomainObject>().ToList(), "CODAREACURSO", "NOMAREACURSO");

                BFMODALIDAD objBFMO = new BFMODALIDAD();
                objWEB.LlenaDDL(ref this.ddlModalidadCurso, objBFMO.GetMODALIDADAll().Cast<DomainObject>().ToList(), "CODMODALIDAD", "NOMMODALIDAD");
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