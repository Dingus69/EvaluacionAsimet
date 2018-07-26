
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPARAMETROSGENERALES.
	/// </summary>
	public class DLPARAMETROSGENERALES : DLBase
	{
		public DLPARAMETROSGENERALES()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PARAMETROS_GENERALES";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PARAMETROS_GENERALES";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PARAMETROS_GENERALES";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PARAMETROS_GENERALES";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@DOMINIO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPARAMETROSGENERALES objPARAMETROSGENERALES = obj as EPARAMETROSGENERALES;

            prms[0] = db.GetParameter();
            prms[0].Value = objPARAMETROSGENERALES.DOMINIO;
            prms[0].ParameterName = "@DOMINIO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EPARAMETROSGENERALES objPARAMETROSGENERALES = obj as EPARAMETROSGENERALES;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPARAMETROSGENERALES.DOMINIO;
            prms[0].ParameterName = "@DOMINIO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPARAMETROSGENERALES.EMAIL;
            prms[1].ParameterName = "@EMAIL";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPARAMETROSGENERALES.PASSWORD;
            prms[2].ParameterName = "@PASSWORD";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPARAMETROSGENERALES.PUERTO;
            prms[3].ParameterName = "@PUERTO";

            prms[4] = db.GetParameter();
            prms[4].Value = objPARAMETROSGENERALES.SMTP;
            prms[4].ParameterName = "@SMTP";

            prms[5] = db.GetParameter();
            prms[5].Value = objPARAMETROSGENERALES.NOMBRE_CLASIFICADOR_1;
            prms[5].ParameterName = "@NOMBRECLASIFICADOR1";

            prms[6] = db.GetParameter();
            prms[6].Value = objPARAMETROSGENERALES.NOMBRE_CLASIFICADOR_2;
            prms[6].ParameterName = "@NOMBRECLASIFICADOR2";

            prms[7] = db.GetParameter();
            prms[7].Value = objPARAMETROSGENERALES.URL_PLATAFORMA;
            prms[7].ParameterName = "@URLPLATAFORMA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            EPARAMETROSGENERALES objPARAMETROSGENERALES = obj as EPARAMETROSGENERALES;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPARAMETROSGENERALES.DOMINIO;
            prms[0].ParameterName = "@DOMINIO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPARAMETROSGENERALES.EMAIL;
            prms[1].ParameterName = "@EMAIL";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPARAMETROSGENERALES.PASSWORD;
            prms[2].ParameterName = "@PASSWORD";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPARAMETROSGENERALES.PUERTO;
            prms[3].ParameterName = "@PUERTO";

            prms[4] = db.GetParameter();
            prms[4].Value = objPARAMETROSGENERALES.SMTP;
            prms[4].ParameterName = "@SMTP";

            prms[5] = db.GetParameter();
            prms[5].Value = objPARAMETROSGENERALES.NOMBRE_CLASIFICADOR_1;
            prms[5].ParameterName = "@NOMBRECLASIFICADOR1";

            prms[6] = db.GetParameter();
            prms[6].Value = objPARAMETROSGENERALES.NOMBRE_CLASIFICADOR_2;
            prms[6].ParameterName = "@NOMBRECLASIFICADOR2";

            prms[7] = db.GetParameter();
            prms[7].Value = objPARAMETROSGENERALES.URL_PLATAFORMA;
            prms[7].ParameterName = "@URLPLATAFORMA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPARAMETROSGENERALES objRoot = obj as EPARAMETROSGENERALES;

            objRoot.DOMINIO = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPARAMETROSGENERALES objPARAMETROSGENERALES = obj as EPARAMETROSGENERALES;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPARAMETROSGENERALES.DOMINIO = Utiles.ConvertToString(dr["DOMINIO"]);
            
            objPARAMETROSGENERALES.EMAIL = Utiles.ConvertToString(dr["EMAIL"]);
            
            objPARAMETROSGENERALES.PASSWORD = Utiles.ConvertToString(dr["PASSWORD"]);
            
            objPARAMETROSGENERALES.PUERTO = Utiles.ConvertToString(dr["PUERTO"]);

            objPARAMETROSGENERALES.SMTP = Utiles.ConvertToString(dr["SMTP"]);

            objPARAMETROSGENERALES.NOMBRE_CLASIFICADOR_1 = Utiles.ConvertToString(dr["NOMBRE_CLASIFICADOR_1"]);

            objPARAMETROSGENERALES.NOMBRE_CLASIFICADOR_2 = Utiles.ConvertToString(dr["NOMBRE_CLASIFICADOR_2"]);

            objPARAMETROSGENERALES.URL_PLATAFORMA = Utiles.ConvertToString(dr["URL_PLATAFORMA"]);

        }

        #endregion

	}
}
