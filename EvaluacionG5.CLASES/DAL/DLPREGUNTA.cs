
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTA.
	/// </summary>
	public class DLPREGUNTA : DLBase
	{
		public DLPREGUNTA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PREGUNTA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PREGUNTA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PREGUNTA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PREGUNTA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_PREGUNTA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPREGUNTA objPREGUNTA = obj as EPREGUNTA;

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTA.CODPREGUNTA;
            prms[0].ParameterName = "@COD_PREGUNTA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EPREGUNTA objPREGUNTA = obj as EPREGUNTA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTA.INDICADOR;
            prms[0].ParameterName = "@INDICADOR";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTA.TEXTO;
            prms[1].ParameterName = "@TEXTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTA.DESCRIPCION;
            prms[2].ParameterName = "@DESCRIPCION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTA.ACCION;
            prms[3].ParameterName = "@ACCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTA.COMPROMISO;
            prms[4].ParameterName = "@COMPROMISO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EPREGUNTA objPREGUNTA = obj as EPREGUNTA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTA.CODPREGUNTA;
            prms[0].ParameterName = "@COD_PREGUNTA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTA.TEXTO;
            prms[1].ParameterName = "@TEXTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTA.DESCRIPCION;
            prms[2].ParameterName = "@DESCRIPCION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTA.ACCION;
            prms[3].ParameterName = "@ACCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTA.COMPROMISO;
            prms[4].ParameterName = "@COMPROMISO";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objPREGUNTA.INDICADOR;
            prms[5].ParameterName = "@INDICADOR";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPREGUNTA objRoot = obj as EPREGUNTA;

            objRoot.CODPREGUNTA = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPREGUNTA objPREGUNTA = obj as EPREGUNTA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPREGUNTA.CODPREGUNTA = Utiles.ConvertToDecimal(dr["COD_PREGUNTA"]);
            
            objPREGUNTA.TEXTO = Utiles.ConvertToString(dr["TEXTO"]);
            
            objPREGUNTA.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);
            
            objPREGUNTA.ACCION = Utiles.ConvertToString(dr["ACCION"]);
            
            objPREGUNTA.COMPROMISO = Utiles.ConvertToString(dr["COMPROMISO"]);
            
            objPREGUNTA.INDICADOR = Utiles.ConvertToString(dr["INDICADOR"]);

            objPREGUNTA.PONDERACION = Utiles.ConvertToDouble(dr["PONDERACION"]);

        }

        #endregion

	}
}
