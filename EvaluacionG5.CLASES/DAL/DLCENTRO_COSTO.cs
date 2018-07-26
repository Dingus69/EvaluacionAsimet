
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCENTROCOSTO.
	/// </summary>
	public class DLCENTROCOSTO : DLBase
	{
		public DLCENTROCOSTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CENTRO_COSTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CENTRO_COSTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CENTRO_COSTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CENTRO_COSTO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CENTRO_COSTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECENTROCOSTO objCENTROCOSTO = obj as ECENTROCOSTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCENTROCOSTO.CODCENTROCOSTO;
            prms[0].ParameterName = "@COD_CENTRO_COSTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECENTROCOSTO objCENTROCOSTO = obj as ECENTROCOSTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCENTROCOSTO.CODCENTROCOSTO;
            prms[0].ParameterName = "@COD_CENTRO_COSTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCENTROCOSTO.NOMBRECENTROCOSTO;
            prms[1].ParameterName = "@NOMBRE_CENTRO_COSTO";

            prms[2] = db.GetParameter();
            prms[2].Value = objCENTROCOSTO.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECENTROCOSTO objCENTROCOSTO = obj as ECENTROCOSTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCENTROCOSTO.CODCENTROCOSTO;
            prms[0].ParameterName = "@COD_CENTRO_COSTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCENTROCOSTO.NOMBRECENTROCOSTO;
            prms[1].ParameterName = "@NOMBRE_CENTRO_COSTO";

            prms[2] = db.GetParameter();
            prms[2].Value = objCENTROCOSTO.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECENTROCOSTO objRoot = obj as ECENTROCOSTO;

            objRoot.CODCENTROCOSTO = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECENTROCOSTO objCENTROCOSTO = obj as ECENTROCOSTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCENTROCOSTO.CODCENTROCOSTO = Utiles.ConvertToString(dr["COD_CENTRO_COSTO"]);
            
            objCENTROCOSTO.NOMBRECENTROCOSTO = Utiles.ConvertToString(dr["NOMBRE_CENTRO_COSTO"]);

            objCENTROCOSTO.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

        }

        #endregion

	}
}
