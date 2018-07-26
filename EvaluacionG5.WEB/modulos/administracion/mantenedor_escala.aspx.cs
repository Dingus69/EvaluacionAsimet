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
    public partial class mantenedor_escala : System.Web.UI.Page
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

        protected void Cargar()
        {
            try
            {
                BFESCALA objBFES = new BFESCALA();
                objWEB.LlenaGrilla(ref grdResultados, objBFES.GetESCALAAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), 20);
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
                this.txtCodEscala.Text = "";
                this.txtNombre.Text = "";
                this.txtValorMenor.Text = "";
                this.txtValorMayor.Text = "";
                this.txtInstruncciones.Text = "";
                this.rbEvaluacionAbierta.Checked = true;
                List<ECATEGORIA> lst = new List<ECATEGORIA>();
                ViewState["Categorias"] = lst;
                List<ERANGO> lstRangos = new List<ERANGO>();
                ViewState["Rangos"] = lstRangos;
                objWEB.LlenaGrilla(ref this.grdCategorias, lst.Cast<DomainObject>().ToList(), 100);
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
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                this.txtCodEscala.Text = ((Label)fila.FindControl("lblCodigo")).Text;
                this.txtNombre.Text = ((Label)fila.FindControl("lblNombre")).Text;
                this.txtValorMenor.Text = ((HiddenField)fila.FindControl("hdfValorMenor")).Value;
                this.txtValorMayor.Text = ((HiddenField)fila.FindControl("hdfValorMayor")).Value;
                this.txtInstruncciones.Text = ((HiddenField)fila.FindControl("hdfInstrucciones")).Value;

                if (Utiles.ConvertToBoolean(((HiddenField)fila.FindControl("hdfFlagRangos")).Value))
                {
                    this.rbPorRangos.Checked = true;
                    this.rbEvaluacionAbierta.Checked = false;

                    BFRANGO objBFRA = new BFRANGO();
                    List<ERANGO> lstRangos = objBFRA.GetRangosPorEscala(Utiles.ConvertToDecimal(((Label)fila.FindControl("lblCodigo")).Text));
                    ViewState["Rangos"] = lstRangos;
                    objWEB.LlenaGrilla(ref this.grdRangos, lstRangos.Cast<DomainObject>().ToList(), 100);
                    divRangos.Visible = true;

                }
                else
                {
                    List<ERANGO> lstRangos = new List<ERANGO>();
                    ViewState["Rangos"] = lstRangos;

                    this.rbPorRangos.Checked = false;
                    this.rbEvaluacionAbierta.Checked = true;
                }

                BFCATEGORIA objBFCA = new BFCATEGORIA();
                List<ECATEGORIA> lst = objBFCA.GetCategoriasPorEscala(Utiles.ConvertToDecimal(((Label)fila.FindControl("lblCodigo")).Text));
                ViewState["Categorias"] = lst;
                objWEB.LlenaGrilla(ref this.grdCategorias, lst.Cast<DomainObject>().ToList(), 100);


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

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

                BFESCALA objBFES = new BFESCALA();
                EESCALA objES = objBFES.GetESCALA(Utiles.ConvertToInt64(((Label)fila.FindControl("lblCodigo")).Text));

                if ((objBFES.PoseeDatosRelacionados(objES.CODESCALA)))
                {
                    this.litErrorDatosRelacionados.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
                }
                else
                {
                    objBFES.Delete(objES);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('4');", true);
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

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            this.txtCodEscala.Text = "";
            this.txtNombre.Text = "";
            this.txtValorMenor.Text = "";
            this.txtValorMayor.Text = "";
            this.txtInstruncciones.Text = "";
            this.rbEvaluacionAbierta.Checked = true;
            List<ECATEGORIA> lst = new List<ECATEGORIA>();
            ViewState["Categorias"] = lst;
            List<ERANGO> lstRangos = new List<ERANGO>();
            ViewState["Rangos"] = lstRangos;
            objWEB.LlenaGrilla(ref this.grdCategorias, lst.Cast<DomainObject>().ToList(), 100);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#modEditar').modal('hide');", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BFESCALA objBFES = new BFESCALA();
                EESCALA objES = new EESCALA();
                objES.CODESCALA = Utiles.ConvertToInt16(this.txtCodEscala.Text);
                objES.NOMESCALA = Utiles.ConvertToString(this.txtNombre.Text);
                objES.VALORMENOR = Utiles.ConvertToDouble(this.txtValorMenor.Text);
                objES.VALORMAYOR = Utiles.ConvertToDouble(this.txtValorMayor.Text);
                objES.INSTRUCCIONES = Utiles.ConvertToString(this.txtInstruncciones.Text);
                objES.RUT_EMPRESA = objSession.RutEmpresa;
                objES.CATEGORIAS = (List<ECATEGORIA>)ViewState["Categorias"];
                if (this.rbPorRangos.Checked)
                {
                    objES.FLAG_RANGOS = true;
                }
                objES.RANGOS = (List<ERANGO>)ViewState["Rangos"];
                objBFES.Save(objES);
                Cargar();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('Los datos han sido ingresados exitosamente.');", true);
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

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                List<ECATEGORIA> lst = (List<ECATEGORIA>)ViewState["Categorias"];
                ECATEGORIA objCA = new ECATEGORIA();
                objCA.NOMBRECATEGORIA = Utiles.ConvertToString(this.txtNombreCategoria.Text);
                objCA.VALORMENOR = Utiles.ConvertToDouble(this.txtValorMenorCategoria.Text);
                objCA.VALORMAYOR = Utiles.ConvertToDouble(this.txtValorMayorCategoria.Text);
                lst.Add(objCA);
                objWEB.LlenaGrilla(ref this.grdCategorias, lst.Cast<DomainObject>().ToList(), 100);
                this.txtNombreCategoria.Text = "";
                this.txtValorMenorCategoria.Text = "";
                this.txtValorMayorCategoria.Text = "";
                ViewState["Categorias"] = lst;
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

        protected void lnkEliminarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

                List<ECATEGORIA> lst = (List<ECATEGORIA>)ViewState["Categorias"];

                foreach (ECATEGORIA objCA in lst)
                {
                    if (objCA.NOMBRECATEGORIA.ToUpper() == ((TextBox)fila.FindControl("txtNombreCategoria")).Text.ToUpper())
                    {
                        lst.Remove(objCA);
                        break;
                    }
                }
                ViewState["Categorias"] = lst;
                objWEB.LlenaGrilla(ref this.grdCategorias, lst.Cast<DomainObject>().ToList(), 100);

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

        protected void rbEvaluacionAbierta_CheckedChanged(object sender, EventArgs e)
        {
            divRangos.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
        }

        protected void rbPorRangos_CheckedChanged(object sender, EventArgs e)
        {
            divRangos.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
        }

        protected void btnAgregarRango_Click(object sender, EventArgs e)
        {
            try
            {
                List<ERANGO> lst = (List<ERANGO>)ViewState["Rangos"];
                ERANGO objRA = new ERANGO();
                objRA.NOMBRERANGO = Utiles.ConvertToString(this.txtNombreRango.Text);
                objRA.DESCRIPCIONRANGO = Utiles.ConvertToString(this.txtDetalleRango.Text);
                objRA.VALORRANGO = Utiles.ConvertToDouble(this.txtValorRango.Text);
                lst.Add(objRA);
                objWEB.LlenaGrilla(ref this.grdRangos, lst.Cast<DomainObject>().ToList(), 100);
                this.txtNombreRango.Text = "";
                this.txtDetalleRango.Text = "";
                this.txtValorRango.Text = "";
                ViewState["Rangos"] = lst;
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

        protected void lnkEliminarRango_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton imgEditar = (LinkButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;

                List<ERANGO> lst = (List<ERANGO>)ViewState["Rangos"];

                foreach (ERANGO objRA in lst)
                {
                    if (objRA.NOMBRERANGO.ToUpper() == ((TextBox)fila.FindControl("txtNombreRango")).Text.ToUpper())
                    {
                        lst.Remove(objRA);
                        break;
                    }
                }
                ViewState["Rangos"] = lst;
                objWEB.LlenaGrilla(ref this.grdRangos, lst.Cast<DomainObject>().ToList(), 100);

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

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Cargar();
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }
    }
}