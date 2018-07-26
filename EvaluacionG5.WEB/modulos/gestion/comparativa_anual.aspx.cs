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


namespace EvaluacionG5.WEB.modulos.gestion
{
    public partial class comparativa_anual : System.Web.UI.Page
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
                    CargarCombos();
                    Consultar();
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

        protected void CargarCombos()
        {
            BFINSTRUMENTOEMPLEADO objIN = new BFINSTRUMENTOEMPLEADO();
            objWEB.LlenaDDL(ref ddlEvaluaciones, objIN.Asignaciones(), "NOM_INSTRUMENTO_EMPLEADO", "NOM_INSTRUMENTO_EMPLEADO");
            objWEB.LlenaDDL(ref ddlTipoReporte, objWEB.TipoReporte(), "valor", "texto");
            ddlTipoReporte.SelectedValue = "Gerencia";
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {

        }

        protected void Consultar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("NOMBRE");
                dt.Columns.Add("RESULTADO_AGNO1");
                dt.Columns.Add("RESULTADO_AGNO2");
                dt.Columns.Add("RESULTADO_AGNO3");

                DataRow dr;
                dr = dt.NewRow();
                dr["NOMBRE"] = "Gerencia de Productos";
                dr["RESULTADO_AGNO1"] = "3";
                dr["RESULTADO_AGNO2"] = "4";
                dr["RESULTADO_AGNO3"] = "3";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["NOMBRE"] = "Gerencia Comercial";
                dr["RESULTADO_AGNO1"] = "2";
                dr["RESULTADO_AGNO2"] = "5";
                dr["RESULTADO_AGNO3"] = "3";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["NOMBRE"] = "Gerencia de Recursos Humanos";
                dr["RESULTADO_AGNO1"] = "4";
                dr["RESULTADO_AGNO2"] = "4";
                dr["RESULTADO_AGNO3"] = "2";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["NOMBRE"] = "Gerencia de Finanzas";
                dr["RESULTADO_AGNO1"] = "5";
                dr["RESULTADO_AGNO2"] = "2";
                dr["RESULTADO_AGNO3"] = "4";
                dt.Rows.Add(dr);

                grdResultados.Columns[0].HeaderText = this.ddlTipoReporte.SelectedValue;
                grdResultados.Columns[1].HeaderText = "Resultado " + Utiles.ConvertToString(DateTime.Now.Year);
                grdResultados.Columns[2].HeaderText = "Resultado " + Utiles.ConvertToString(DateTime.Now.Year - 1);
                grdResultados.Columns[3].HeaderText = "Resultado " + Utiles.ConvertToString(DateTime.Now.Year - 2);


                objWEB.LlenaGrilladt(ref this.grdResultados, dt, 100);

               
            }
            catch(Exception ex)
            {

            }
        }
    }
}