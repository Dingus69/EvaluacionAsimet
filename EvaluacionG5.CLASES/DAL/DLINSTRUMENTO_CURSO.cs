
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLINSTRUMENTOCURSO.
	/// </summary>
	public class DLINSTRUMENTOCURSO : DLBase
	{
		public DLINSTRUMENTOCURSO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_INSTRUMENTO_CURSO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_INSTRUMENTO_CURSO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_INSTRUMENTO_CURSO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_INSTRUMENTO_CURSO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_INSTRUMENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EINSTRUMENTOCURSO objINSTRUMENTOCURSO = obj as EINSTRUMENTOCURSO;

            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOCURSO.CODINSTRUMENTO;
            prms[0].ParameterName = "@COD_INSTRUMENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EINSTRUMENTOCURSO objINSTRUMENTOCURSO = obj as EINSTRUMENTOCURSO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOCURSO.CODINSTRUMENTO;
            prms[0].ParameterName = "@COD_INSTRUMENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objINSTRUMENTOCURSO.CODCURSO;
            prms[1].ParameterName = "@COD_CURSO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EINSTRUMENTOCURSO objINSTRUMENTOCURSO = obj as EINSTRUMENTOCURSO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOCURSO.CODINSTRUMENTO;
            prms[0].ParameterName = "@COD_INSTRUMENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objINSTRUMENTOCURSO.CODCURSO;
            prms[1].ParameterName = "@COD_CURSO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EINSTRUMENTOCURSO objRoot = obj as EINSTRUMENTOCURSO;

            objRoot.CODINSTRUMENTO = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EINSTRUMENTOCURSO objINSTRUMENTOCURSO = obj as EINSTRUMENTOCURSO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objINSTRUMENTOCURSO.CODINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO"]);
            
            objINSTRUMENTOCURSO.CODCURSO = Utiles.ConvertToString(dr["COD_CURSO"]);
            
        }

        #endregion

	}
}
