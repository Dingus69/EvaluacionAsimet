
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCOMUNA.
	/// </summary>
	public class DLCOMUNA : DLBase
	{
		public DLCOMUNA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_COMUNA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_COMUNA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_COMUNA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_COMUNA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_COMUNA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECOMUNA objCOMUNA = obj as ECOMUNA;

            prms[0] = db.GetParameter();
            prms[0].Value = objCOMUNA.CODCOMUNA;
            prms[0].ParameterName = "@COD_COMUNA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECOMUNA objCOMUNA = obj as ECOMUNA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCOMUNA.CODCOMUNA;
            prms[0].ParameterName = "@COD_COMUNA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCOMUNA.CODREGION;
            prms[1].ParameterName = "@COD_REGION";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCOMUNA.NOMCOMUNA;
            prms[2].ParameterName = "@NOM_COMUNA";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECOMUNA objCOMUNA = obj as ECOMUNA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCOMUNA.CODCOMUNA;
            prms[0].ParameterName = "@COD_COMUNA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCOMUNA.CODREGION;
            prms[1].ParameterName = "@COD_REGION";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCOMUNA.NOMCOMUNA;
            prms[2].ParameterName = "@NOM_COMUNA";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECOMUNA objRoot = obj as ECOMUNA;

            objRoot.CODCOMUNA = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECOMUNA objCOMUNA = obj as ECOMUNA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCOMUNA.CODCOMUNA = Utiles.ConvertToString(dr["COD_COMUNA"]);
            
            objCOMUNA.CODREGION = Utiles.ConvertToString(dr["COD_REGION"]);
            
            objCOMUNA.NOMCOMUNA = Utiles.ConvertToString(dr["NOM_COMUNA"]);
            
        }

        #endregion

	}
}
