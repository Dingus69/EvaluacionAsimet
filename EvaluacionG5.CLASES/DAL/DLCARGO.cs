
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCARGO.
	/// </summary>
	public class DLCARGO : DLBase
	{
		public DLCARGO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CARGO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CARGO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CARGO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CARGO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CARGO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECARGO objCARGO = obj as ECARGO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCARGO.CODCARGO;
            prms[0].ParameterName = "@COD_CARGO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECARGO objCARGO = obj as ECARGO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCARGO.CODCARGO;
            prms[0].ParameterName = "@COD_CARGO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCARGO.NOMBRECARGO;
            prms[1].ParameterName = "@NOMBRE_CARGO";

            prms[2] = db.GetParameter();
            prms[2].Value = objCARGO.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECARGO objCARGO = obj as ECARGO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCARGO.CODCARGO;
            prms[0].ParameterName = "@COD_CARGO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCARGO.NOMBRECARGO;
            prms[1].ParameterName = "@NOMBRE_CARGO";

            prms[2] = db.GetParameter();
            prms[2].Value = objCARGO.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECARGO objRoot = obj as ECARGO;

            objRoot.CODCARGO = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECARGO objCARGO = obj as ECARGO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCARGO.CODCARGO = Utiles.ConvertToString(dr["COD_CARGO"]);
            
            objCARGO.NOMBRECARGO = Utiles.ConvertToString(dr["NOMBRE_CARGO"]);

            objCARGO.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

        }

        #endregion

	}
}
