
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOEVALUACION.
	/// </summary>
	public class DLTIPOEVALUACION : DLBase
	{
		public DLTIPOEVALUACION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_EVALUACION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_EVALUACION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_EVALUACION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_EVALUACION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_TIPO_EVAL";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOEVALUACION objTIPOEVALUACION = obj as ETIPOEVALUACION;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOEVALUACION.CODTIPOEVAL;
            prms[0].ParameterName = "@COD_TIPO_EVAL";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOEVALUACION objTIPOEVALUACION = obj as ETIPOEVALUACION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOEVALUACION.CODTIPOEVAL;
            prms[0].ParameterName = "@COD_TIPO_EVAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOEVALUACION.NOMTIPOEVAL;
            prms[1].ParameterName = "@NOM_TIPO_EVAL";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOEVALUACION objTIPOEVALUACION = obj as ETIPOEVALUACION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOEVALUACION.CODTIPOEVAL;
            prms[0].ParameterName = "@COD_TIPO_EVAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOEVALUACION.NOMTIPOEVAL;
            prms[1].ParameterName = "@NOM_TIPO_EVAL";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOEVALUACION objRoot = obj as ETIPOEVALUACION;

            objRoot.CODTIPOEVAL = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOEVALUACION objTIPOEVALUACION = obj as ETIPOEVALUACION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTIPOEVALUACION.CODTIPOEVAL = Utiles.ConvertToInt16(dr["COD_TIPO_EVAL"]);
            
            objTIPOEVALUACION.NOMTIPOEVAL = Utiles.ConvertToString(dr["NOM_TIPO_EVAL"]);
            
        }

        #endregion

	}
}
