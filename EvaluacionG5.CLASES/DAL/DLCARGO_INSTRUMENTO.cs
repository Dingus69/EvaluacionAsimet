
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCARGOINSTRUMENTO.
	/// </summary>
	public class DLCARGOINSTRUMENTO : DLBase
	{
		public DLCARGOINSTRUMENTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CARGO_INSTRUMENTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CARGO_INSTRUMENTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CARGO_INSTRUMENTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CARGO_INSTRUMENTO";
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
            ECARGOINSTRUMENTO objCARGOINSTRUMENTO = obj as ECARGOINSTRUMENTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCARGOINSTRUMENTO.CODCARGO;
            prms[0].ParameterName = "@COD_CARGO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECARGOINSTRUMENTO objCARGOINSTRUMENTO = obj as ECARGOINSTRUMENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCARGOINSTRUMENTO.CODCARGO;
            prms[0].ParameterName = "@COD_CARGO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCARGOINSTRUMENTO.CODINSTRUMENTO;
            prms[1].ParameterName = "@COD_INSTRUMENTO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECARGOINSTRUMENTO objCARGOINSTRUMENTO = obj as ECARGOINSTRUMENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCARGOINSTRUMENTO.CODCARGO;
            prms[0].ParameterName = "@COD_CARGO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCARGOINSTRUMENTO.CODINSTRUMENTO;
            prms[1].ParameterName = "@COD_INSTRUMENTO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECARGOINSTRUMENTO objRoot = obj as ECARGOINSTRUMENTO;

            objRoot.CODCARGO = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECARGOINSTRUMENTO objCARGOINSTRUMENTO = obj as ECARGOINSTRUMENTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCARGOINSTRUMENTO.CODCARGO = Utiles.ConvertToDecimal(dr["COD_CARGO"]);
            
            objCARGOINSTRUMENTO.CODINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO"]);
            
        }

        #endregion

	}
}
