using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.WEB.modulos.administracion
{
    public partial class instrumento : System.Web.UI.Page
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

        private List<ESECCION> lstSeccion = new List<ESECCION>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ValidaSession();
                if (!Page.IsPostBack)
                {
                    ViewState["ListaSecciones"] = lstSeccion;
                    InicializarFormulario();
                    if (Request["CodInstrumento"] != null)
                    {
                        Cargar();
                        CargaCursos(Utiles.ConvertToDecimal(Request["CodInstrumento"].ToString()));
                        ViewState["Modo"] = "Editar";
                    }
                    else
                    {
                        CargaCursos(0);
                        ViewState["Modo"] = "Insertar";
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

        protected void InicializarFormulario()
        {
            try
            {
                BFESCALA objES = new BFESCALA();
                objWEB.LlenaDDL(ref ddlEscalas, objES.GetESCALAAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODESCALA", "NOMESCALA");
                //BFGRADO objGR = new BFGRADO();
                //objWEB.LlenaDDL(ref ddlGrados, objGR.GetGRADOAll().Cast<DomainObject>().ToList(), "CODGRADO", "NOMBREGRADO");
                //this.ddlGrados.SelectedValue = "3";
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
                BFINSTRUMENTO objBFIN = new BFINSTRUMENTO();
                EINSTRUMENTO obj = objBFIN.GetINSTRUMENTO(Utiles.ConvertToInt64(Request["CodInstrumento"].ToString()));
                this.hdfCodInstrumento.Value = Request["CodInstrumento"];
                this.txtNombreInstrumento.Text = obj.NOMBREINSTRUMENTO;
                this.txtDescripcion.Text = obj.DESCRIPCION;
                this.txtObservacion.Text = obj.OBSERVACION;
                this.ddlEscalas.SelectedValue = Utiles.ConvertToString(obj.CODESCALA);
                this.ddlGrados.SelectedValue = Utiles.ConvertToString(obj.CODGRADO);
                this.chkAutoevaluacion.Checked = Utiles.ConvertToBoolean(obj.FLAGAUTOEVALUACION);
                this.chkApelacion.Checked = Utiles.ConvertToBoolean(obj.FLAG_APELACION);
                this.chkVisacion.Checked = Utiles.ConvertToBoolean(obj.FLAG_VISACION);

                this.chkConCalibracion.Checked = Utiles.ConvertToBoolean(obj.FLAGCALIBRACION);
                this.chkObjetivos.Checked = Utiles.ConvertToBoolean(obj.FLAGINGRESOOBJETIVOS);

                this.txtPondAutoEvaluacion.Text = Utiles.ConvertToString(obj.PONDAUTOEVALUACION);
                this.txtPondJefatura.Text = Utiles.ConvertToString(obj.PONDJEFATURAS);
                this.txtPondColaboradores.Text = Utiles.ConvertToString(obj.PONDCOLABORADORES);
                this.txtPondPares.Text = Utiles.ConvertToString(obj.PONDPARES);


                objWEB.LlenaGrilla(ref this.grdSecciones, obj.SECCIONES.Cast<DomainObject>().ToList(), 100);
                ViewState["ListaSecciones"] = obj.SECCIONES;

            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnAgregarSeccion_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarSeccion();
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void AgregarSeccion()
        {
            try
            {
                lstSeccion = (List<ESECCION>)ViewState["ListaSecciones"];
                BFSECCION objBFSE = new BFSECCION();
                ESECCION objSE = new ESECCION();
                objSE.PONDERACION = 100;
                objSE.ORDEN = 1;
                lstSeccion.Add(objSE);
                foreach (ESECCION obj in lstSeccion)
                {
                    if (obj.PREGUNTAS.Count == 0)
                    {
                        EPREGUNTA objPR = new EPREGUNTA();
                        objPR.PONDERACION = 100;
                        obj.PREGUNTAS.Add(objPR);
                    }
                }
                objWEB.LlenaGrilla(ref this.grdSecciones, lstSeccion.Cast<DomainObject>().ToList(), 100);
                ViewState["ListaSecciones"] = lstSeccion;
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
                lstSeccion = (List<ESECCION>)ViewState["ListaSecciones"];

                int i = 0;
                foreach (GridViewRow grdRow in grdSecciones.Rows)
                {
                    lstSeccion[i].NOMBRE = ((TextBox)grdRow.FindControl("txtNombreSeccion")).Text;
                    lstSeccion[i].CODTIPOSECCION = Utiles.ConvertToInt16(((DropDownList)grdRow.FindControl("ddlTipoSeccion")).SelectedValue);
                    lstSeccion[i].CODSECCION = Utiles.ConvertToInt16(((HiddenField)grdRow.FindControl("hdfCodSeccion")).Value);
                    lstSeccion[i].CODINSTRUMENTO = Utiles.ConvertToInt16(((HiddenField)grdRow.FindControl("hdfCodInstrumento")).Value);
                    lstSeccion[i].ORDEN = Utiles.ConvertToInt16(((TextBox)grdRow.FindControl("txtOrden")).Text);
                    lstSeccion[i].PONDERACION = Utiles.ConvertToDouble(((TextBox)grdRow.FindControl("txtPonderacion")).Text);
                    lstSeccion[i].FLAG_AGREGAR_PREGUNTA = Utiles.ConvertToBoolean(((CheckBox)grdRow.FindControl("chkNuevasPreguntas")).Checked);
                    lstSeccion[i].DESCRIPCION = ((TextBox)grdRow.FindControl("txtDescripcionSeccion")).Text;
                    int x = 0;
                    foreach (GridViewRow grdRow2 in ((GridView)grdRow.FindControl("grdPreguntas")).Rows)
                    {
                        lstSeccion[i].PREGUNTAS[x].TEXTO = ((TextBox)grdRow2.FindControl("txtPregunta")).Text;
                        lstSeccion[i].PREGUNTAS[x].DESCRIPCION = ((HiddenField)grdRow2.FindControl("hdfDescripcion")).Value;
                        lstSeccion[i].PREGUNTAS[x].ACCION = ((HiddenField)grdRow2.FindControl("hdfAccion")).Value;
                        lstSeccion[i].PREGUNTAS[x].COMPROMISO = ((HiddenField)grdRow2.FindControl("hdfCompromiso")).Value;
                        lstSeccion[i].PREGUNTAS[x].INDICADOR = ((HiddenField)grdRow2.FindControl("hdfIndicador")).Value;
                        lstSeccion[i].PREGUNTAS[x].PONDERACION = Utiles.ConvertToDouble(((TextBox)grdRow2.FindControl("txtPonderacionPregunta")).Text);
                        lstSeccion[i].PREGUNTAS[x].CODPREGUNTA = Utiles.ConvertToDecimal(((HiddenField)grdRow2.FindControl("hdfCodPregunta")).Value);
                        x++;
                    }
                    i++;
                }


                EPREGUNTA objPR = new EPREGUNTA();
                lstSeccion[fila.RowIndex].PREGUNTAS.Add(objPR);
                objWEB.LlenaGrilla(ref this.grdSecciones, lstSeccion.Cast<DomainObject>().ToList(), 100);
                ViewState["ListaSecciones"] = lstSeccion;
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
                    DropDownList ddl = ((DropDownList)e.Row.FindControl("ddlTipoSeccion"));
                    BFTIPOSECCION objTS = new BFTIPOSECCION();
                    objWEB.LlenaDDL(ref ddl, objTS.GetTIPOSECCIONAll().Cast<DomainObject>().ToList(), "CODTIPOSECCION", "NOMBRETIPOSECCION");
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

        protected void btnCargarSecciones_Click(object sender, EventArgs e)
        {
            try
            {
                string strArchivo = fulPreguntas.FileName;
                string strExtension = strArchivo.Substring(strArchivo.LastIndexOf(".") + 1);
                if (!(strExtension.ToUpper() == "XLS"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: Debe seleccionar un archivo (XLS).');", true);
                    return;
                }

                string strRuta = "";
                strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "tmp\\carga_secciones_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
                if (System.IO.File.Exists(strRuta))
                {
                    System.IO.File.Delete(strRuta);
                }
                this.fulPreguntas.SaveAs(strRuta);

                BFSECCION objBFSE = new BFSECCION();
                lstSeccion = objBFSE.GetSeccionesExcel(strRuta);
                objWEB.LlenaGrilla(ref this.grdSecciones, lstSeccion.Cast<DomainObject>().ToList(), 100);
                ViewState["ListaSecciones"] = lstSeccion;

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
                if (!(ValidarDatos()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('3');", true);
                    return;
                }
                else
                {
                    BFINSTRUMENTO objBFIN = new BFINSTRUMENTO();
                    EINSTRUMENTO objIN = new EINSTRUMENTO();
                    objIN.CODINSTRUMENTO = Utiles.ConvertToDecimal(this.hdfCodInstrumento.Value);
                    objIN.NOMBREINSTRUMENTO = Utiles.ConvertToString(this.txtNombreInstrumento.Text);
                    objIN.DESCRIPCION = Utiles.ConvertToString(this.txtDescripcion.Text);
                    objIN.OBSERVACION = Utiles.ConvertToString(this.txtObservacion.Text);
                    objIN.CODESCALA = Utiles.ConvertToDecimal(ddlEscalas.SelectedValue);
                    objIN.CODGRADO = Utiles.ConvertToInt16(ddlGrados.SelectedValue);
                    objIN.FLAGAUTOEVALUACION = Utiles.ConvertToBoolean(chkAutoevaluacion.Checked);
                    objIN.FLAG_APELACION = Utiles.ConvertToBoolean(chkApelacion.Checked);
                    objIN.FLAG_VISACION = Utiles.ConvertToBoolean(chkVisacion.Checked);
                    objIN.RUT_EMPRESA = objSession.RutEmpresa;



                    objIN.FLAGCALIBRACION = this.chkConCalibracion.Checked;
                    objIN.FLAGINGRESOOBJETIVOS = this.chkObjetivos.Checked;

                    objIN.PONDAUTOEVALUACION = Utiles.ConvertToDouble(this.txtPondAutoEvaluacion.Text);
                    objIN.PONDJEFATURAS = Utiles.ConvertToDouble(this.txtPondJefatura.Text);
                    objIN.PONDCOLABORADORES = Utiles.ConvertToDouble(this.txtPondColaboradores.Text);
                    objIN.PONDPARES = Utiles.ConvertToDouble(this.txtPondPares.Text);

                    List<ESECCION> lstSE = new List<ESECCION>();
                    ESECCION objSE;

                    foreach (GridViewRow grdRowSE in this.grdSecciones.Rows)
                    {
                        List<EPREGUNTA> lstPR = new List<EPREGUNTA>();
                        EPREGUNTA objPR;
                        objSE = new ESECCION();
                        objSE.CODSECCION = Utiles.ConvertToDecimal(((HiddenField)grdRowSE.FindControl("hdfCodSeccion")).Value);
                        objSE.NOMBRE = Utiles.ConvertToString(((TextBox)grdRowSE.FindControl("txtNombreSeccion")).Text);
                        objSE.CODTIPOSECCION = Utiles.ConvertToInt16(((DropDownList)grdRowSE.FindControl("ddlTipoSeccion")).SelectedValue);
                        //objSE.CODTIPOSECCION = Utiles.ConvertToInt16(((HiddenField)grdRowSE.FindControl("hdfCodTipoSeccion")).Value);
                        objSE.CODINSTRUMENTO = Utiles.ConvertToDecimal(((HiddenField)grdRowSE.FindControl("hdfCodInstrumento")).Value);
                        objSE.PONDERACION = Utiles.ConvertToDouble(((TextBox)grdRowSE.FindControl("txtPonderacion")).Text);
                        objSE.ORDEN = Utiles.ConvertToInt16(((TextBox)grdRowSE.FindControl("txtOrden")).Text);
                        objSE.DESCRIPCION = Utiles.ConvertToString(((TextBox)grdRowSE.FindControl("txtDescripcionSeccion")).Text);
                        objSE.FLAG_AGREGAR_PREGUNTA = Utiles.ConvertToBoolean(((CheckBox)grdRowSE.FindControl("chkNuevasPreguntas")).Checked);
                        foreach (GridViewRow grdRowPR in ((GridView)grdRowSE.FindControl("grdPreguntas")).Rows)
                        {
                            objPR = new EPREGUNTA();
                            objPR.CODPREGUNTA = Utiles.ConvertToDecimal(((HiddenField)grdRowPR.FindControl("hdfCodPregunta")).Value);
                            objPR.TEXTO = Utiles.ConvertToString(((TextBox)grdRowPR.FindControl("txtPregunta")).Text);
                            objPR.PONDERACION = Utiles.ConvertToDouble(((TextBox)grdRowPR.FindControl("txtPonderacionPregunta")).Text);
                            objPR.DESCRIPCION = Utiles.ConvertToString(((HiddenField)grdRowPR.FindControl("hdfDescripcion")).Value);
                            objPR.ACCION = Utiles.ConvertToString(((HiddenField)grdRowPR.FindControl("hdfAccion")).Value);
                            objPR.COMPROMISO = Utiles.ConvertToString(((HiddenField)grdRowPR.FindControl("hdfCompromiso")).Value);
                            objPR.INDICADOR = Utiles.ConvertToString(((HiddenField)grdRowPR.FindControl("hdfIndicador")).Value);
                            lstPR.Add(objPR);
                        }
                        objSE.PREGUNTAS = lstPR;
                        lstSE.Add(objSE);
                    }
                    objIN.SECCIONES = lstSE;
                    if (Utiles.ConvertToString(ViewState["Modo"]) == "Editar")
                    {
                        objIN.IsPersisted = true;
                    }
                    objBFIN.Save(objIN);
                    ViewState["Modo"] = "Editar";

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

        protected Boolean ValidarDatos()
        {
            Boolean Resultado = false;
            try
            {
                double SumaPondSeccion = 0.0;
                foreach (GridViewRow grdRowSE in this.grdSecciones.Rows)
                {
                    SumaPondSeccion = SumaPondSeccion + Utiles.ConvertToDouble(((TextBox)grdRowSE.FindControl("txtPonderacion")).Text);
                    double SumaPondPreg = 0.0;
                    foreach (GridViewRow grdRowPR in ((GridView)grdRowSE.FindControl("grdPreguntas")).Rows)
                    {
                        SumaPondPreg = SumaPondPreg + Utiles.ConvertToDouble(((TextBox)grdRowPR.FindControl("txtPonderacionPregunta")).Text);
                    }
                    if (SumaPondPreg != 100)
                    {
                        return false;
                    }
                }
                if (SumaPondSeccion != 100)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
                return Resultado;
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("lista_instrumentos.aspx");
        }

        protected void imgEditar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgEditar = (ImageButton)sender;
            GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
            GridView Grilla = (GridView)fila.NamingContainer;
            GridViewRow filaSeccion = (GridViewRow)Grilla.NamingContainer;
            ViewState["RowIndexSeccion"] = filaSeccion.RowIndex;
            ViewState["RowIndexPreguntas"] = fila.RowIndex;
            txtPreguntaMant.Text = ((TextBox)fila.FindControl("txtPregunta")).Text;
            txtDescripPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfDescripcion")).Value;
            txtAccionPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfAccion")).Value;
            txtCompromisoPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfCompromiso")).Value;
            txtIndicadorPreguntaMant.Text = ((HiddenField)fila.FindControl("hdfIndicador")).Value;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
        }

        protected void btnGuardarPregunta_Click(object sender, EventArgs e)
        {
            GridView grdPreguntas = ((GridView)this.grdSecciones.Rows[Utiles.ConvertToInt16(ViewState["RowIndexSeccion"])].FindControl("grdPreguntas"));
            ((TextBox)grdPreguntas.Rows[Utiles.ConvertToInt16(ViewState["RowIndexPreguntas"])].FindControl("txtPregunta")).Text = txtPreguntaMant.Text;
            ((HiddenField)grdPreguntas.Rows[Utiles.ConvertToInt16(ViewState["RowIndexPreguntas"])].FindControl("hdfDescripcion")).Value = txtDescripPreguntaMant.Text;
            ((HiddenField)grdPreguntas.Rows[Utiles.ConvertToInt16(ViewState["RowIndexPreguntas"])].FindControl("hdfAccion")).Value = txtAccionPreguntaMant.Text;
            ((HiddenField)grdPreguntas.Rows[Utiles.ConvertToInt16(ViewState["RowIndexPreguntas"])].FindControl("hdfCompromiso")).Value = txtCompromisoPreguntaMant.Text;
            ((HiddenField)grdPreguntas.Rows[Utiles.ConvertToInt16(ViewState["RowIndexPreguntas"])].FindControl("hdfIndicador")).Value = txtIndicadorPreguntaMant.Text;
        }

        protected void imgEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgEditar = (ImageButton)sender;
                GridViewRow fila = (GridViewRow)imgEditar.NamingContainer;
                GridView Grilla = (GridView)fila.NamingContainer;
                GridViewRow filaSeccion = (GridViewRow)Grilla.NamingContainer;
                int RowIndexSeccion = filaSeccion.RowIndex;
                int RowIndexPreguntas = fila.RowIndex;
                //lstSeccion = (List<ESECCION>)ViewState["ListaSecciones"];

                List<ESECCION> lstSeccion = new List<ESECCION>();
                ESECCION objSE;
                EPREGUNTA objPR;
                int i = 0;
                foreach (GridViewRow grdRow in grdSecciones.Rows)
                {
                    objSE = new ESECCION();
                    objSE.NOMBRE = ((TextBox)grdRow.FindControl("txtNombreSeccion")).Text;
                    objSE.CODTIPOSECCION = Utiles.ConvertToInt16(((DropDownList)grdRow.FindControl("ddlTipoSeccion")).SelectedValue);
                    objSE.CODSECCION = Utiles.ConvertToInt16(((HiddenField)grdRow.FindControl("hdfCodSeccion")).Value);
                    objSE.CODINSTRUMENTO = Utiles.ConvertToInt16(((HiddenField)grdRow.FindControl("hdfCodInstrumento")).Value);
                    objSE.ORDEN = Utiles.ConvertToInt16(((TextBox)grdRow.FindControl("txtOrden")).Text);
                    objSE.PONDERACION = Utiles.ConvertToDouble(((TextBox)grdRow.FindControl("txtPonderacion")).Text);
                    objSE.FLAG_AGREGAR_PREGUNTA = Utiles.ConvertToBoolean(((CheckBox)grdRow.FindControl("chkNuevasPreguntas")).Checked);
                    objSE.DESCRIPCION = ((TextBox)grdRow.FindControl("txtDescripcionSeccion")).Text;
                    int x = 0;
                    foreach (GridViewRow grdRow2 in ((GridView)grdRow.FindControl("grdPreguntas")).Rows)
                    {
                        objPR = new EPREGUNTA();
                        if ((RowIndexSeccion == i) && (RowIndexPreguntas == x))
                        {
                        }
                        else
                        {
                            objPR.TEXTO = ((TextBox)grdRow2.FindControl("txtPregunta")).Text;
                            objPR.DESCRIPCION = ((HiddenField)grdRow2.FindControl("hdfDescripcion")).Value;
                            objPR.ACCION = ((HiddenField)grdRow2.FindControl("hdfAccion")).Value;
                            objPR.COMPROMISO = ((HiddenField)grdRow2.FindControl("hdfCompromiso")).Value;
                            objPR.INDICADOR = ((HiddenField)grdRow2.FindControl("hdfIndicador")).Value;
                            objPR.PONDERACION = Utiles.ConvertToDouble(((TextBox)grdRow2.FindControl("txtPonderacionPregunta")).Text);
                            objPR.CODPREGUNTA = Utiles.ConvertToDecimal(((HiddenField)grdRow2.FindControl("hdfCodPregunta")).Value);
                            objSE.PREGUNTAS.Add(objPR);
                        }
                        x++;
                    }
                    i++;
                    lstSeccion.Add(objSE);
                }

                objWEB.LlenaGrilla(ref this.grdSecciones, lstSeccion.Cast<DomainObject>().ToList(), 100);
                ViewState["ListaSecciones"] = lstSeccion;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void CargaCursos(Decimal CodInstrumento)
        {
            try
            {
                BFCURSO objBFCU = new BFCURSO();
                objWEB.LlenaListBox(ref this.lstCurDispArea1, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 1), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurDispArea2, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 2), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurDispArea3, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 3), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurDispArea4, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 4), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurDispArea5, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 5), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurDispArea6, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 6), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurDispArea7, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 7), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurDispArea8, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 8), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurDispArea9, objBFCU.GetCursosDisponiblesArea(CodInstrumento, 9), "COD_CURSO", "NOMBRE_CURSO");

                objWEB.LlenaListBox(ref this.lstCurAsigArea1, objBFCU.GetCursosAsignadosArea(CodInstrumento, 1), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurAsigArea2, objBFCU.GetCursosAsignadosArea(CodInstrumento, 2), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurAsigArea3, objBFCU.GetCursosAsignadosArea(CodInstrumento, 3), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurAsigArea4, objBFCU.GetCursosAsignadosArea(CodInstrumento, 4), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurAsigArea5, objBFCU.GetCursosAsignadosArea(CodInstrumento, 5), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurAsigArea6, objBFCU.GetCursosAsignadosArea(CodInstrumento, 6), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurAsigArea7, objBFCU.GetCursosAsignadosArea(CodInstrumento, 7), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurAsigArea8, objBFCU.GetCursosAsignadosArea(CodInstrumento, 8), "COD_CURSO", "NOMBRE_CURSO");
                objWEB.LlenaListBox(ref this.lstCurAsigArea9, objBFCU.GetCursosAsignadosArea(CodInstrumento, 9), "COD_CURSO", "NOMBRE_CURSO");
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                litCatchError.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
            }
        }

        protected void btnIrUnoArea1_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea1_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea1_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea1_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrUnoArea2_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea2_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea2_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea2_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrUnoArea3_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea3_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea3_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea3_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrUnoArea4_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea4_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea4_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea4_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrUnoArea5_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea5_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea5_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea5_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrUnoArea6_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea6_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea6_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea6_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrUnoArea7_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea7_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea7_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea7_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrUnoArea8_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea8_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea8_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea8_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrUnoArea9_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrTodosArea9_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverUnoArea9_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverTodosArea9_Click(object sender, EventArgs e)
        {

        }
    }
}