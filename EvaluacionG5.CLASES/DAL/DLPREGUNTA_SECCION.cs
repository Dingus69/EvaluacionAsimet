
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTASECCION.
	/// </summary>
	public class DLPREGUNTASECCION : DLBase
	{
		public DLPREGUNTASECCION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PREGUNTA_SECCION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PREGUNTA_SECCION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PREGUNTA_SECCION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PREGUNTA_SECCION";
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
            EPREGUNTASECCION objPREGUNTASECCION = obj as EPREGUNTASECCION;

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTASECCION.CODPREGUNTA;
            prms[0].ParameterName = "@COD_PREGUNTA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EPREGUNTASECCION objPREGUNTASECCION = obj as EPREGUNTASECCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTASECCION.CODPREGUNTA;
            prms[0].ParameterName = "@COD_PREGUNTA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTASECCION.CODSECCION;
            prms[1].ParameterName = "@COD_SECCION";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTASECCION.PONDERACION;
            prms[2].ParameterName = "@PONDERACION";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EPREGUNTASECCION objPREGUNTASECCION = obj as EPREGUNTASECCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTASECCION.CODPREGUNTA;
            prms[0].ParameterName = "@COD_PREGUNTA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTASECCION.CODSECCION;
            prms[1].ParameterName = "@COD_SECCION";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTASECCION.PONDERACION;
            prms[2].ParameterName = "@PONDERACION";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPREGUNTASECCION objRoot = obj as EPREGUNTASECCION;

            objRoot.CODPREGUNTA = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPREGUNTASECCION objPREGUNTASECCION = obj as EPREGUNTASECCION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPREGUNTASECCION.CODPREGUNTA = Utiles.ConvertToDecimal(dr["COD_PREGUNTA"]);
            
            objPREGUNTASECCION.CODSECCION = Utiles.ConvertToDecimal(dr["COD_SECCION"]);
            
            objPREGUNTASECCION.PONDERACION = Utiles.ConvertToDouble(dr["PONDERACION"]);
            
        }

        #endregion

	}
}
