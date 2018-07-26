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
    public partial class mantenedor_usuarios : System.Web.UI.Page
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
                if (Request.Params["__EVENTTARGET"] == "CargarFoto")
                {
                    CargarFoto();
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
                this.txtPassword.Attributes.Add("value", txtPassword.Text);
                this.txtRepPassword.Attributes.Add("value", txtRepPassword.Text);
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
                BFUSUARIO objBFUS = new BFUSUARIO();
                objWEB.LlenaGrilladt(ref grdResultados, objBFUS.GetUsuariosDT(Utiles.RutUsrALng(this.txtRutUsuario.Text), Utiles.ConvertToString(this.txtNombreUsuario.Text)), 20);
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
                this.txtRut.Text = "";
                this.txtNombre.Text = "";
                this.txtApPaterno.Text = "";
                this.txtApMaterno.Text = "";
                this.txtEmail.Text = "";
                this.chkActivo.Checked = true;

                this.chkEsEmpleado.Checked = false;
                HabilitarDatosEmpleado();

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

                this.txtRut.Text = ((Label)fila.FindControl("lblRut")).Text;
                this.txtNombre.Text = ((Label)fila.FindControl("lblNombre")).Text;
                this.txtApPaterno.Text = ((Label)fila.FindControl("lblApPaterno")).Text;
                this.txtApMaterno.Text = ((Label)fila.FindControl("lblApMaterno")).Text;
                this.txtEmail.Text = ((HiddenField)fila.FindControl("hdfEmail")).Value;
                this.txtPassword.Text = CCryptografia.Desencriptar(((HiddenField)fila.FindControl("hdfPassword")).Value);
                this.txtRepPassword.Text = CCryptografia.Desencriptar(((HiddenField)fila.FindControl("hdfPassword")).Value);
                this.chkActivo.Checked = Utiles.ConvertToBoolean(((HiddenField)fila.FindControl("hdfFlagActivo")).Value);
                this.chkEsEmpleado.Checked = Utiles.ConvertToBoolean(((HiddenField)fila.FindControl("hdfEsEmpleado")).Value);

                CargarAvatar();
                HabilitarDatosEmpleado();

                if (Utiles.ConvertToBoolean(((HiddenField)fila.FindControl("hdfEsEmpleado")).Value))
                { 
                    txtFechaNacimiento.Text = ((HiddenField)fila.FindControl("hdfFechaNacimiento")).Value;
                    ddlSexo.SelectedValue = ((HiddenField)fila.FindControl("hdfCodSexo")).Value;
                    ddlEmpresa.SelectedValue = ((HiddenField)fila.FindControl("hdfRutEmpresa")).Value;
                    txtEmpresa.Text = Utiles.RutLngAUsr(Utiles.ConvertToInt64(((HiddenField)fila.FindControl("hdfRutEmpresa")).Value));
                    if (!ddlDireccion.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodDireccion")).Value)))
                    {
                        ddlDireccion.SelectedValue = "-";
                    }
                    else
                    {
                        ddlDireccion.SelectedValue = ((HiddenField)fila.FindControl("hdfCodDireccion")).Value;
                    }
                    if (!ddlGerencia.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodGerencia")).Value)))
                    {
                        ddlGerencia.SelectedValue = "-";
                    }
                    else
                    {
                        ddlGerencia.SelectedValue = ((HiddenField)fila.FindControl("hdfCodGerencia")).Value;
                    }
                    if (!ddlArea.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodArea")).Value)))
                    {
                        ddlArea.SelectedValue = "-";
                    }
                    else
                    {
                        ddlArea.SelectedValue = ((HiddenField)fila.FindControl("hdfCodArea")).Value;
                    }
                    if (!ddlUnidad.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodUnidad")).Value)))
                    {
                        ddlUnidad.SelectedValue = "-";
                    }
                    else
                    {
                        ddlUnidad.SelectedValue = ((HiddenField)fila.FindControl("hdfCodUnidad")).Value;
                    }
                    if (!ddlFamiliaCargo.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfFamiliaCargo")).Value)))
                    {
                        ddlFamiliaCargo.SelectedValue = "-";
                    }
                    else
                    {
                        ddlFamiliaCargo.SelectedValue = ((HiddenField)fila.FindControl("hdfFamiliaCargo")).Value;
                    }
                    if (!ddlCargo.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodCargo")).Value)))
                    {
                        ddlCargo.SelectedValue = "-";
                    }
                    else
                    {
                        ddlCargo.SelectedValue = ((HiddenField)fila.FindControl("hdfCodCargo")).Value;
                    }
                    if (!ddlCentroCosto.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodCentroCosto")).Value)))
                    {
                        ddlCentroCosto.SelectedValue = "-";
                    }
                    else
                    {
                        ddlCentroCosto.SelectedValue = ((HiddenField)fila.FindControl("hdfCodCentroCosto")).Value;
                    }
                    if (!ddlClasif1.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodClasificador1")).Value)))
                    {
                        ddlClasif1.SelectedValue = "-";
                    }
                    else
                    {
                        ddlClasif1.SelectedValue = ((HiddenField)fila.FindControl("hdfCodClasificador1")).Value;
                    }
                    if (!ddlClasif2.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodClasificador2")).Value)))
                    {
                        ddlClasif2.SelectedValue = "-";
                    }
                    else
                    {
                        ddlClasif2.SelectedValue = ((HiddenField)fila.FindControl("hdfCodClasificador2")).Value;
                    }
                    if (!ddlSucursal.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodSucursal")).Value)))
                    {
                        ddlSucursal.SelectedValue = "-";
                    }
                    else
                    {
                        ddlSucursal.SelectedValue = ((HiddenField)fila.FindControl("hdfCodSucursal")).Value;
                    }
                    if (!ddlRol.Items.Contains(new ListItem(((HiddenField)fila.FindControl("hdfCodRol")).Value)))
                    {
                        ddlRol.SelectedValue = "-";
                    }
                    else
                    {
                        ddlRol.SelectedValue = ((HiddenField)fila.FindControl("hdfCodRol")).Value;
                    }
                    ddlNivEscolaridad.SelectedValue = ((HiddenField)fila.FindControl("hdfCodNivelEducacional")).Value;
                    ddlNivOcupacional.SelectedValue = ((HiddenField)fila.FindControl("hdfCodNivelOcupacional")).Value;
                    txtRutJefe.Text = ((HiddenField)fila.FindControl("hdfRutJefe")).Value;
                    txtFechaContrato.Text = ((HiddenField)fila.FindControl("hdfFechaIngreso")).Value;
                    ddlComuna.SelectedValue = ((HiddenField)fila.FindControl("hdfCodComuna")).Value;

                } 

                SeteaSuperAdministrador();

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

        protected void CargarAvatar()
        { 
            string strRutUsuario = Utiles.RutUsrALng(txtRut.Text.Trim()).ToString();
            string strRuta = "";
            strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "include\\usuarios\\" + strRutUsuario;

            if (System.IO.File.Exists(strRuta + ".jpg"))
            {
                imgAvatar.ImageUrl = "../../include/usuarios/" + strRutUsuario + ".jpg";
            }
            else if (System.IO.File.Exists(strRuta + ".png"))
            {
                imgAvatar.ImageUrl = "../../include/usuarios/" + strRutUsuario + ".png";
            }
            else
            {
                imgAvatar.ImageUrl = "../../include/usuarios/avatar-usuario-generico.png";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {  
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('2');", true); 
        }

        protected Boolean ValidarFormulario()
        {
            Boolean blnResultado = false;
            try
            {
                if ((this.txtRut.Text == "") || (this.txtNombre.Text == "") || (this.txtApPaterno.Text == "")  || (this.txtPassword.Text == "") || (this.txtRepPassword.Text == ""))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: Debe ingresar todos los datos solicitados.');", true);
                    return false;
                }
                else
                {
                    if (!Utiles.ValidarRut(this.txtRut.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: El Rut ingresado no es valido.');", true);
                        return false;
                    }
                    if (!Utiles.ValidarMail(this.txtEmail.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: El Email ingresado no es valido.');", true);
                        return false;
                    }
                    if (this.txtPassword.Text != this.txtRepPassword.Text)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: Las Passwords ingresadas no coinciden.');", true);
                        return false;
                    }

                    if (this.chkEsEmpleado.Checked)
                    {
                        if (!Utiles.ValidarFecha(this.txtFechaNacimiento.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: La fecha ingresada no es valida.');", true);
                            return false;
                        }
                        if (!Utiles.ValidarFecha(this.txtFechaContrato.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: La fecha ingresada no es valida.');", true);
                            return false;
                        }
                        if (!Utiles.ValidarRut(this.txtRutJefe.Text.Trim()))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: El Rut de jefe no es valido.');", true);
                            return false;
                        }
                    }

                    return true;
                }
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

        protected void btnIrUno_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["PerfilesAsignados"] == null)
                {
                    List<DomainObject> lst = new List<DomainObject>();
                    ViewState["PerfilesAsignados"] = lst.ToList<DomainObject>();
                }
                BFPERFIL objBFPerfil = new BFPERFIL();
                List<DomainObject> objLstPerfAsig = (List<DomainObject>)ViewState["PerfilesAsignados"];
                var lstPerfDisp = ViewState["PerfilesDisponibles"] as List<DomainObject>;
                for (int i = 0; i <= this.lstDisponibles.Items.Count - 1; i++)
                {
                    if (this.lstDisponibles.Items[i].Selected == true)
                    {
                        for (int x = 0; x <= lstPerfDisp.Count - 1; x++)
                        {
                            DomainObject it;
                            it = lstPerfDisp[x];
                            if (((EPERFIL)(it)).CODPERFIL == Utiles.ConvertToInt16(this.lstDisponibles.Items[i].Value))
                            {
                                lstPerfDisp.Remove(it);
                            }
                        }
                        objLstPerfAsig.Add(objBFPerfil.GetPERFIL(Utiles.ConvertToInt16(this.lstDisponibles.Items[i].Value)));
                    }
                }
                List<DomainObject> lista = new List<DomainObject>();
                lista = objLstPerfAsig.Cast<DomainObject>().ToList();
                ViewState["PerfilesAsignados"] = lista.ToList<DomainObject>();
                objWEB.LlenaListBox(ref this.lstAsignados, lista, "CODPERFIL", "NOMBREPERFIL");
                ViewState["PerfilesDisponibles"] = lstPerfDisp.ToList<DomainObject>();
                objWEB.LlenaListBox(ref this.lstDisponibles, lstPerfDisp, "CODPERFIL", "NOMBREPERFIL");

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

        protected void btnVolverUno_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["PerfilesAsignados"] == null)
                {
                    List<DomainObject> lst = new List<DomainObject>();
                    ViewState["PerfilesAsignados"] = lst.ToList<DomainObject>();
                }
                BFPERFIL objBFPerfil = new BFPERFIL();
                List<DomainObject> objLstPerfAsig = (List<DomainObject>)ViewState["PerfilesAsignados"];
                var lstPerfDisp = ViewState["PerfilesDisponibles"] as List<DomainObject>;
                for (int i = 0; i <= this.lstAsignados.Items.Count - 1; i++)
                {
                    if (this.lstAsignados.Items[i].Selected == true)
                    {
                        for (int x = 0; x <= objLstPerfAsig.Count - 1; x++)
                        {
                            DomainObject it;
                            it = objLstPerfAsig[x];
                            if (((EPERFIL)(it)).CODPERFIL == Utiles.ConvertToInt16(this.lstAsignados.Items[i].Value))
                            {
                                objLstPerfAsig.Remove(it);
                            }
                        }
                        lstPerfDisp.Add(objBFPerfil.GetPERFIL(Utiles.ConvertToInt16(this.lstAsignados.Items[i].Value)));
                    }
                }
                List<DomainObject> lista = new List<DomainObject>();
                lista = objLstPerfAsig.Cast<DomainObject>().ToList();
                ViewState["PerfilesAsignados"] = lista.ToList<DomainObject>();
                objWEB.LlenaListBox(ref this.lstAsignados, lista, "CODPERFIL", "NOMBREPERFIL");
                ViewState["PerfilesDisponibles"] = lstPerfDisp.ToList<DomainObject>();
                objWEB.LlenaListBox(ref this.lstDisponibles, lstPerfDisp, "CODPERFIL", "NOMBREPERFIL");

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

        protected void btnIrTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["PerfilesAsignados"] == null)
                {
                    List<DomainObject> lst = new List<DomainObject>();
                    ViewState["PerfilesAsignados"] = lst.ToList<DomainObject>();
                }
                BFPERFIL objBFPerfil = new BFPERFIL();
                List<DomainObject> objLstPerfAsig = (List<DomainObject>)ViewState["PerfilesAsignados"];
                var lstPerfDisp = ViewState["PerfilesDisponibles"] as List<DomainObject>;
                for (int i = 0; i <= this.lstDisponibles.Items.Count - 1; i++)
                {
                    for (int x = 0; x <= lstPerfDisp.Count - 1; x++)
                    {
                        DomainObject it;
                        it = lstPerfDisp[x];
                        if (((EPERFIL)(it)).CODPERFIL == Utiles.ConvertToInt16(this.lstDisponibles.Items[i].Value))
                        {
                            lstPerfDisp.Remove(it);
                        }
                    }
                    objLstPerfAsig.Add(objBFPerfil.GetPERFIL(Utiles.ConvertToInt16(this.lstDisponibles.Items[i].Value)));
                }
                List<DomainObject> lista = new List<DomainObject>();
                lista = objLstPerfAsig.Cast<DomainObject>().ToList();
                ViewState["PerfilesAsignados"] = lista.ToList<DomainObject>();
                objWEB.LlenaListBox(ref this.lstAsignados, lista, "CODPERFIL", "NOMBREPERFIL");
                ViewState["PerfilesDisponibles"] = lstPerfDisp.ToList<DomainObject>();
                objWEB.LlenaListBox(ref this.lstDisponibles, lstPerfDisp, "CODPERFIL", "NOMBREPERFIL");

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

        protected void btnVolverTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["PerfilesAsignados"] == null)
                {
                    List<DomainObject> lst = new List<DomainObject>();
                    ViewState["PerfilesAsignados"] = lst.ToList<DomainObject>();
                }
                BFPERFIL objBFPerfil = new BFPERFIL();
                List<DomainObject> objLstPerfAsig = (List<DomainObject>)ViewState["PerfilesAsignados"];
                var lstPerfDisp = ViewState["PerfilesDisponibles"] as List<DomainObject>;
                for (int i = 0; i <= this.lstAsignados.Items.Count - 1; i++)
                {
                    for (int x = 0; x <= objLstPerfAsig.Count - 1; x++)
                    {
                        DomainObject it;
                        it = objLstPerfAsig[x];
                        if (((EPERFIL)(it)).CODPERFIL == Utiles.ConvertToInt16(this.lstAsignados.Items[i].Value))
                        {
                            objLstPerfAsig.Remove(it);
                        }
                    }
                    lstPerfDisp.Add(objBFPerfil.GetPERFIL(Utiles.ConvertToInt16(this.lstAsignados.Items[i].Value)));
                }
                List<DomainObject> lista = new List<DomainObject>();
                lista = objLstPerfAsig.Cast<DomainObject>().ToList();
                ViewState["PerfilesAsignados"] = lista.ToList<DomainObject>();
                objWEB.LlenaListBox(ref this.lstAsignados, lista, "CODPERFIL", "NOMBREPERFIL");
                ViewState["PerfilesDisponibles"] = lstPerfDisp.ToList<DomainObject>();
                objWEB.LlenaListBox(ref this.lstDisponibles, lstPerfDisp, "CODPERFIL", "NOMBREPERFIL");

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

        protected void btnContinuarGuardar_Click(object sender, EventArgs e)
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

                    if (chkEsEmpleado.Checked)
                    {

                        BFEMPLEADO objBFEM = new BFEMPLEADO();
                        EEMPLEADO objEM = new EEMPLEADO();
                        objEM.RUTEMPLEADO = Utiles.RutUsrALng(this.txtRut.Text);
                        objEM.NOMBREEMPLEADO = this.txtNombre.Text;
                        objEM.APELLIDOPATERNO = this.txtApPaterno.Text;
                        objEM.APELLIDOMATERNO = this.txtApMaterno.Text;
                        objEM.EMAIL = this.txtEmail.Text;
                        objEM.FECHAINGRESO = Utiles.ConvertToDateTime(this.txtFechaContrato.Text);
                        objEM.RUTEMPRESA = Utiles.ConvertToInt64(this.ddlEmpresa.SelectedValue);
                        objEM.CODSUCURSAL = this.ddlSucursal.SelectedValue;
                        objEM.CODAREA = this.ddlArea.SelectedValue;
                        objEM.CODCARGO = this.ddlCargo.SelectedValue;
                        objEM.CODROL = this.ddlRol.SelectedValue;
                        objEM.COD_GERENCIA = this.ddlGerencia.SelectedValue;
                        objEM.COD_CENTRO_COSTO = this.ddlCentroCosto.SelectedValue;
                        objEM.COD_CLASIFICADOR_1 = this.ddlClasif1.SelectedValue;
                        objEM.COD_CLASIFICADOR_2 = this.ddlClasif2.SelectedValue;
                        objEM.RUTJEFE = Utiles.RutUsrALng(this.txtRutJefe.Text);
                        //objEM.RUTVISADOR = this.txt
                        objEM.FECHA_NACIMIENTO = Utiles.ConvertToDateTime(this.txtFechaNacimiento.Text);
                        objEM.COD_SEXO = this.ddlSexo.SelectedValue;
                        objEM.COD_NIVEL_EDUCACIONAL = Utiles.ConvertToInt16(this.ddlNivEscolaridad.SelectedValue);
                        objEM.COD_NIVEL_OCUPACIONAL = Utiles.ConvertToInt16(this.ddlNivOcupacional.SelectedValue);
                        objEM.COD_UNIDAD = this.ddlUnidad.SelectedValue;
                        objEM.COD_DIRECCION = this.ddlDireccion.SelectedValue;
                        objEM.COD_COMUNA = this.ddlComuna.SelectedValue;
                        objEM.FLAG_ACTIVO = this.chkActivo.Checked;
                        if (ViewState["Modo"].ToString() == "Insertar")
                        {
                            objEM.IsPersisted = false;
                        }
                        else
                        {
                            objEM.IsPersisted = true;
                        }
                        objBFEM.Save(objEM);
                    }

                    BFUSUARIO objBFUS = new BFUSUARIO();
                    EUSUARIO objUS = new EUSUARIO();
                    objUS.RUTUSUARIO = Utiles.RutUsrALng(this.txtRut.Text);
                    objUS.NOMBREUSUARIO = this.txtNombre.Text;
                    objUS.APELLIDOPATERNO = this.txtApPaterno.Text;
                    objUS.APELLIDOMATERNO = this.txtApMaterno.Text;
                    objUS.EMAIL = this.txtEmail.Text;
                    objUS.PASSWORD = CCryptografia.Encriptar(this.txtPassword.Text);
                    objUS.FLAGACTIVO = this.chkActivo.Checked;
                    if (ViewState["Modo"].ToString() == "Insertar")
                    {
                        objUS.IsPersisted = false;
                    }
                    else
                    {
                        objUS.IsPersisted = true;
                    }
                    objBFUS.Save(objUS);

                    BFPERFILUSUARIO objBFPU = new BFPERFILUSUARIO();
                    EPERFILUSUARIO objPU = new EPERFILUSUARIO();
                    objPU.CODPERFIL = 1;
                    objPU.RUTUSUARIO = Utiles.RutUsrALng(this.txtRut.Text);
                    objBFPU.Delete(objPU);
                    objPU = new EPERFILUSUARIO();
                    objPU.CODPERFIL = 2;
                    objPU.RUTUSUARIO = Utiles.RutUsrALng(this.txtRut.Text);
                    objBFPU.Delete(objPU);

                    foreach (ListItem item in this.lstAsignados.Items)
                    {
                        objPU = new EPERFILUSUARIO();
                        objPU.CODPERFIL = Utiles.ConvertToInt16(item.Value);
                        objPU.RUTUSUARIO = Utiles.RutUsrALng(this.txtRut.Text);
                        objBFPU.Save(objPU);
                    } 
                    //objWEB.LlenaGrilla(ref grdResultados, objBFUS.GetUsuarios(Utiles.RutUsrALng(this.txtRutUsuario.Text), Utiles.ConvertToString(this.txtNombreUsuario.Text)).Cast<DomainObject>().ToList(), 20);
                    objWEB.LlenaGrilladt(ref grdResultados, objBFUS.GetUsuariosDT(Utiles.RutUsrALng(this.txtRutUsuario.Text), Utiles.ConvertToString(this.txtNombreUsuario.Text)), 20);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SessionUsuario", "alert('ATENCION: Los datos han sido almacenados exitosamente.');", true);
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

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void CargarCombos()
        {
            objWEB.LlenaDDL(ref this.ddlSexo, objWEB.Sexo(), "texto", "valor");
            this.ddlSexo.SelectedValue = "M";

            BFEMPRESA objBFEM = new BFEMPRESA();
            objWEB.LlenaDDL(ref this.ddlEmpresa, objBFEM.GetEMPRESAAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "RUTEMPRESA", "NOMBREFANTASIA");
            this.ddlEmpresa.SelectedValue = Utiles.ConvertToString(objSession.RutEmpresa);

            BFDIRECCION objBFDI = new BFDIRECCION();
            objWEB.LlenaDDL(ref this.ddlDireccion, objBFDI.GetDIRECCIONAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODDIRECCION", "NOMDIRECCION");
            this.ddlDireccion.SelectedValue = "-";

            BFGERENCIA objBFGE = new BFGERENCIA();
            objWEB.LlenaDDL(ref this.ddlGerencia, objBFGE.GetGERENCIAAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODGERENCIA", "NOMBREGERENCIA");
            this.ddlGerencia.SelectedValue = "-";

            BFAREA objBFAR = new BFAREA();
            objWEB.LlenaDDL(ref this.ddlArea, objBFAR.GetAREAAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODAREA", "NOMBREAREA");
            this.ddlArea.SelectedValue = "-";

            BFUNIDAD objBFUN = new BFUNIDAD();
            objWEB.LlenaDDL(ref this.ddlUnidad, objBFUN.GetUNIDADAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODUNIDAD", "NOMUNIDAD");
            this.ddlUnidad.SelectedValue = "-";

            BFFAMILIACARGO objBFFC = new BFFAMILIACARGO();
            objWEB.LlenaDDL(ref this.ddlFamiliaCargo, objBFFC.GetFAMILIACARGOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODFAMILIACARGO", "NOMFAMILIACARGO");
            this.ddlFamiliaCargo.SelectedValue = "-";

            BFCARGO objBFCA = new BFCARGO();
            objWEB.LlenaDDL(ref this.ddlCargo, objBFCA.GetCARGOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCARGO", "NOMBRECARGO");
            this.ddlCargo.SelectedValue = "-";

            BFSUCURSAL objBFSU = new BFSUCURSAL();
            objWEB.LlenaDDL(ref this.ddlSucursal, objBFSU.GetSUCURSALAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODSUCURSAL", "NOMBRESUCURSAL");
            this.ddlSucursal.SelectedValue = "-";

            BFCENTROCOSTO objBFCC = new BFCENTROCOSTO();
            objWEB.LlenaDDL(ref this.ddlCentroCosto, objBFCC.GetCENTROCOSTOAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCENTROCOSTO", "NOMBRECENTROCOSTO");
            this.ddlCentroCosto.SelectedValue = "-";

            BFROL objBFRO = new BFROL();
            objWEB.LlenaDDL(ref this.ddlRol, objBFRO.GetROLAll(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODROL", "NOMBREROL");
            this.ddlRol.SelectedValue = "-";

            BFCLASIFICADOR1 objCL1 = new BFCLASIFICADOR1();
            objWEB.LlenaDDL(ref this.ddlClasif1, objCL1.GetCLASIFICADOR1All(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCLASIFICADOR1", "NOMBRECLASIFICADOR1");
            this.ddlClasif1.SelectedValue = "-";

            BFCLASIFICADOR2 objCL2 = new BFCLASIFICADOR2();
            objWEB.LlenaDDL(ref this.ddlClasif2, objCL2.GetCLASIFICADOR2All(objSession.RutEmpresa).Cast<DomainObject>().ToList(), "CODCLASIFICADOR2", "NOMBRECLASIFICADOR2");
            this.ddlClasif2.SelectedValue = "-";

            BFNIVELEDUCACIONAL objBFNE = new BFNIVELEDUCACIONAL();
            objWEB.LlenaDDL(ref this.ddlNivEscolaridad, objBFNE.GetNIVELEDUCACIONALAll().Cast<DomainObject>().ToList(), "CODNIVELEDUCACIONAL", "NOMNIVELEDUCACIONAL");
            this.ddlNivEscolaridad.SelectedValue = "5";

            BFNIVELOCUPACIONAL objBFNO = new BFNIVELOCUPACIONAL();
            objWEB.LlenaDDL(ref this.ddlNivOcupacional, objBFNO.GetNIVELOCUPACIONALAll().Cast<DomainObject>().ToList(), "CODNIVELOCUPACIONAL", "NOMNIVELOCUPACIONAL");
            this.ddlNivOcupacional.SelectedValue = "2";

            BFREGION objBFRE = new BFREGION();
            objWEB.LlenaDDL(ref this.ddlRegion, objBFRE.GetREGIONAll().Cast<DomainObject>().ToList(), "CODREGION", "NOMREGION");
            this.ddlRegion.SelectedValue = "13";

            BFCOMUNA objBFCO = new BFCOMUNA();
            objWEB.LlenaDDL(ref this.ddlComuna, objBFCO.GetCOMUNAAll(Utiles.ConvertToInt32(ddlRegion.SelectedValue)).Cast<DomainObject>().ToList(), "CODCOMUNA", "NOMCOMUNA");
            this.ddlComuna.SelectedValue = "132101";

            BFPERFIL objBFPE = new BFPERFIL();
            ViewState["PerfilesDisponibles"] = objBFPE.GetPERFILAll().Cast<DomainObject>().ToList();
            objWEB.LlenaListBox(ref this.lstDisponibles, objBFPE.GetPERFILAll().Cast<DomainObject>().ToList(), "CODPERFIL", "NOMBREPERFIL");

            List<EPERFIL> lstAsig = new List<EPERFIL>();
            ViewState["PerfilesAsignados"] = lstAsig.Cast<DomainObject>().ToList();
            objWEB.LlenaListBox(ref this.lstAsignados, lstAsig.Cast<DomainObject>().ToList(), "CODPERFIL", "NOMBREPERFIL");


            SeteaSuperAdministrador();

        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BFCOMUNA objBFCO = new BFCOMUNA();
                objWEB.LlenaDDL(ref this.ddlComuna, objBFCO.GetCOMUNAAll(Utiles.ConvertToInt32(ddlRegion.SelectedValue)).Cast<DomainObject>().ToList(), "CODCOMUNA", "NOMCOMUNA");
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

        protected void SeteaSuperAdministrador()
        {
            if (objSession.EsSuperAdministrador)
            {
                this.ddlEmpresa.Enabled = true;
                this.ddlEmpresa.Visible = true;
                txtEmpresa.Text = "";
                txtEmpresa.Visible = false;
            }
            else
            {
                this.ddlEmpresa.Enabled = false;
                this.ddlEmpresa.Visible = false;
                txtEmpresa.Text = ddlEmpresa.SelectedItem.Text;
                txtEmpresa.Visible = true;
                foreach (ListItem item in this.lstAsignados.Items)
                {
                    if (item.Value == "0")
                    {
                        lstAsignados.Items.Remove(item);
                        break;
                    }
                }
                foreach (ListItem item in this.lstDisponibles.Items)
                {
                    if (item.Value == "0")
                    {
                        lstDisponibles.Items.Remove(item);
                        break;
                    }
                }
            }
        }

        protected void chkEsEmpleado_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarDatosEmpleado();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
        }

        protected void HabilitarDatosEmpleado()
        {
            if (chkEsEmpleado.Checked)
            {
                divDatosEmpleado.Attributes.Remove("class");
                divDatosEmpleado.Attributes.Add("class", "divEnable");
                txtFechaNacimiento.Enabled = true;
                ddlSexo.Enabled = true;
                ddlEmpresa.Enabled = true;
                txtEmpresa.Enabled = true;
                ddlDireccion.Enabled = true;
                ddlGerencia.Enabled = true;
                ddlArea.Enabled = true;
                ddlUnidad.Enabled = true;
                ddlFamiliaCargo.Enabled = true;
                ddlCargo.Enabled = true;
                ddlCentroCosto.Enabled = true;
                ddlClasif1.Enabled = true;
                ddlClasif2.Enabled = true;
                ddlNivEscolaridad.Enabled = true;
                ddlNivOcupacional.Enabled = true;
                ddlSucursal.Enabled = true;
                ddlRol.Enabled = true;
                txtRutJefe.Enabled = true;
                txtFechaContrato.Enabled = true;
                ddlRegion.Enabled = true;
                ddlComuna.Enabled = true;
            }
            else
            {
                divDatosEmpleado.Attributes.Remove("class");
                divDatosEmpleado.Attributes.Add("class", "divDisable");
                txtFechaNacimiento.Enabled = false;
                ddlSexo.Enabled = false;
                ddlEmpresa.Enabled = false;
                txtEmpresa.Enabled = false;
                ddlDireccion.Enabled = false;
                ddlGerencia.Enabled = false;
                ddlArea.Enabled = false;
                ddlUnidad.Enabled = false;
                ddlFamiliaCargo.Enabled = false;
                ddlCargo.Enabled = false;
                ddlCentroCosto.Enabled = false;
                ddlClasif1.Enabled = false;
                ddlClasif2.Enabled = false;
                ddlNivEscolaridad.Enabled = false;
                ddlNivOcupacional.Enabled = false;
                ddlSucursal.Enabled = false;
                ddlRol.Enabled = false;
                txtRutJefe.Enabled = false;
                txtFechaContrato.Enabled = false;
                ddlRegion.Enabled = false;
                ddlComuna.Enabled = false;
            }
        }

        protected void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            string strRuta = HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace("mantenedor_usuarios.aspx", "carga_nomina.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mantenedor", "document.location.href = '" + strRuta + "';", true);
        }

        protected void grdResultados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdResultados.PageIndex = e.NewPageIndex;
        }

        protected void CargarFoto()
        {
            if (this.txtRut.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('ATENCION: La imagen no se puede cargar hasta que el usuario se encuentre creado.');", true);
            }
            else
            {

                string strArchivo = fulFoto.FileName;
                string strExtension = strArchivo.Substring(strArchivo.LastIndexOf(".") + 1);

                if (!(strExtension.ToUpper() == "JPG"))
                {
                    if (!(strExtension.ToUpper() == "PNG"))
                    {
                        litError.Text = "ATENCION: Debe seleccionar imagen en formato JPG o PNG.";
                        litError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('0');", true);
                        return;
                    }
                }

                string strRuta = "";
                strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "include\\usuarios\\" + Utiles.RutUsrALng(this.txtRut.Text).ToString() + "." + strExtension;
                if (System.IO.File.Exists(strRuta))
                {
                    System.IO.File.Delete(strRuta);
                }
                this.fulFoto.SaveAs(strRuta);

                CargarAvatar();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "Menu('1');", true);
            }

        }
    }

}