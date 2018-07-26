
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLRANGO.
	/// </summary>
	public class DLRANGO : DLBase
	{
		public DLRANGO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_RANGO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_RANGO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_RANGO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_RANGO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_RANGO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ERANGO objRANGO = obj as ERANGO;

            prms[0] = db.GetParameter();
            prms[0].Value = objRANGO.CODRANGO;
            prms[0].ParameterName = "@COD_RANGO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            ERANGO objRANGO = obj as ERANGO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objRANGO.CODESCALA;
            prms[0].ParameterName = "@CODESCALA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objRANGO.NOMBRERANGO;
            prms[1].ParameterName = "@NOMBRE_RANGO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objRANGO.DESCRIPCIONRANGO;
            prms[2].ParameterName = "@DESCRIPCION_RANGO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objRANGO.VALORRANGO;
            prms[3].ParameterName = "@VALOR_RANGO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            ERANGO objRANGO = obj as ERANGO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objRANGO.CODRANGO;
            prms[0].ParameterName = "@COD_RANGO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objRANGO.CODESCALA;
            prms[1].ParameterName = "@CODESCALA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objRANGO.NOMBRERANGO;
            prms[2].ParameterName = "@NOMBRE_RANGO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objRANGO.DESCRIPCIONRANGO;
            prms[3].ParameterName = "@DESCRIPCION_RANGO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objRANGO.VALORRANGO;
            prms[4].ParameterName = "@VALOR_RANGO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ERANGO objRoot = obj as ERANGO;

            objRoot.CODRANGO = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ERANGO objRANGO = obj as ERANGO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objRANGO.CODRANGO = Utiles.ConvertToDecimal(dr["COD_RANGO"]);
            
            objRANGO.CODESCALA = Utiles.ConvertToDecimal(dr["CODESCALA"]);
            
            objRANGO.NOMBRERANGO = Utiles.ConvertToString(dr["NOMBRE_RANGO"]);
            
            objRANGO.DESCRIPCIONRANGO = Utiles.ConvertToString(dr["DESCRIPCION_RANGO"]);
            
            objRANGO.VALORRANGO = Utiles.ConvertToDouble(dr["VALOR_RANGO"]);
            
        }

        #endregion

	}
}
