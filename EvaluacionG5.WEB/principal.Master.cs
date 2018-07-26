using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvaluacionG5.CLASES.DAO;
using System.Configuration;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.WEB
{
    public partial class principal : System.Web.UI.MasterPage
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
            ValidaSession();
            if (!Page.IsPostBack)
            {
                if (objSession.EsSuperAdministrador)
                {
                    AdminEmpresas.Visible = true;
                }
                lblNombreUsuario.Text = objSession.Nombres + ' ' + objSession.Apellidos;

                bool blnCargoImagen = false;
                string strRuta = "";
                strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "include\\logos_empresas\\" + Utiles.ConvertToString(objSession.RutEmpresa) + ".png";
                if (System.IO.File.Exists(strRuta))
                {
                    imgLogoEMpresa.ImageUrl = "~/include/logos_empresas/" + Utiles.ConvertToString(objSession.RutEmpresa) + ".png";
                    blnCargoImagen = true;
                }
                else
                {
                    strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "include\\logos_empresas\\" + Utiles.ConvertToString(objSession.RutEmpresa) + ".jpg";
                    if (System.IO.File.Exists(strRuta))
                    {
                        imgLogoEMpresa.ImageUrl = "~/include/logos_empresas/" + Utiles.ConvertToString(objSession.RutEmpresa) + ".jpg";
                        blnCargoImagen = true;
                    }
                    else
                    {
                        strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "include\\logos_empresas\\" + Utiles.ConvertToString(objSession.RutEmpresa) + ".svg";
                        if (System.IO.File.Exists(strRuta))
                        {
                            imgLogoEMpresa.ImageUrl = "~/include/logos_empresas/" + Utiles.ConvertToString(objSession.RutEmpresa) + ".svg";
                            blnCargoImagen = true;
                        }
                    }
                }
                if (blnCargoImagen == false)
                {
                    strRuta = System.AppDomain.CurrentDomain.BaseDirectory + "include\\logos_empresas\\default.svg";
                    imgLogoEMpresa.ImageUrl = "~/include/logos_empresas/default.svg";
                }
            }
        }
    }
}