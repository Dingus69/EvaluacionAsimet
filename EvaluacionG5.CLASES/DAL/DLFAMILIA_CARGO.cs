
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{ 
    /// <summary>
    /// Summary description for DLFAMILIACARGO.
    /// </summary>
public class DLFAMILIACARGO : DLBase
	{
		public DLFAMILIACARGO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_FAMILIA_CARGO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_FAMILIA_CARGO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_FAMILIA_CARGO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_FAMILIA_CARGO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EFAMILIACARGO objFAMILIACARGO = obj as EFAMILIACARGO;

            prms[0] = db.GetParameter();
            prms[0].Value = objFAMILIACARGO.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EFAMILIACARGO objFAMILIACARGO = obj as EFAMILIACARGO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objFAMILIACARGO.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objFAMILIACARGO.CODFAMILIACARGO;
            prms[1].ParameterName = "@COD_FAMILIA_CARGO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objFAMILIACARGO.NOMFAMILIACARGO;
            prms[2].ParameterName = "@NOM_FAMILIA_CARGO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EFAMILIACARGO objFAMILIACARGO = obj as EFAMILIACARGO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objFAMILIACARGO.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objFAMILIACARGO.CODFAMILIACARGO;
            prms[1].ParameterName = "@COD_FAMILIA_CARGO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objFAMILIACARGO.NOMFAMILIACARGO;
            prms[2].ParameterName = "@NOM_FAMILIA_CARGO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EFAMILIACARGO objRoot = obj as EFAMILIACARGO;

            objRoot.RUTEMPRESA = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EFAMILIACARGO objFAMILIACARGO = obj as EFAMILIACARGO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objFAMILIACARGO.RUTEMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);
            
            objFAMILIACARGO.CODFAMILIACARGO = Utiles.ConvertToString(dr["COD_FAMILIA_CARGO"]);
            
            objFAMILIACARGO.NOMFAMILIACARGO = Utiles.ConvertToString(dr["NOM_FAMILIA_CARGO"]);
            
        }

        #endregion

	}
}
