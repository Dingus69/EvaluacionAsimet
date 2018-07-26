
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLESTADOINSTRUMENTO.
	/// </summary>
	public class DLESTADOINSTRUMENTO : DLBase
	{
		public DLESTADOINSTRUMENTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ESTADO_INSTRUMENTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ESTADO_INSTRUMENTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ESTADO_INSTRUMENTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ESTADO_INSTRUMENTO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@CODESTADOEVAL";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EESTADOINSTRUMENTO objESTADOINSTRUMENTO = obj as EESTADOINSTRUMENTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objESTADOINSTRUMENTO.CODESTADOEVAL;
            prms[0].ParameterName = "@CODESTADOEVAL";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EESTADOINSTRUMENTO objESTADOINSTRUMENTO = obj as EESTADOINSTRUMENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objESTADOINSTRUMENTO.CODESTADOEVAL;
            prms[0].ParameterName = "@CODESTADOEVAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objESTADOINSTRUMENTO.NOMESTADOEVAL;
            prms[1].ParameterName = "@NOMESTADOEVAL";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EESTADOINSTRUMENTO objESTADOINSTRUMENTO = obj as EESTADOINSTRUMENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objESTADOINSTRUMENTO.CODESTADOEVAL;
            prms[0].ParameterName = "@CODESTADOEVAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objESTADOINSTRUMENTO.NOMESTADOEVAL;
            prms[1].ParameterName = "@NOMESTADOEVAL";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EESTADOINSTRUMENTO objRoot = obj as EESTADOINSTRUMENTO;

            objRoot.CODESTADOEVAL = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EESTADOINSTRUMENTO objESTADOINSTRUMENTO = obj as EESTADOINSTRUMENTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objESTADOINSTRUMENTO.CODESTADOEVAL = Utiles.ConvertToDecimal(dr["CODESTADOEVAL"]);
            
            objESTADOINSTRUMENTO.NOMESTADOEVAL = Utiles.ConvertToString(dr["NOMESTADOEVAL"]);
            
        }

        #endregion

	}
}
