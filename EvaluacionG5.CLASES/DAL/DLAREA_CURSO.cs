
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLAREACURSO.
	/// </summary>
	public class DLAREACURSO : DLBase
	{
		public DLAREACURSO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_AREA_CURSO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_AREA_CURSO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_AREA_CURSO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_AREA_CURSO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_AREA_CURSO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EAREACURSO objAREACURSO = obj as EAREACURSO;

            prms[0] = db.GetParameter();
            prms[0].Value = objAREACURSO.CODAREACURSO;
            prms[0].ParameterName = "@COD_AREA_CURSO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EAREACURSO objAREACURSO = obj as EAREACURSO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objAREACURSO.CODAREACURSO;
            prms[0].ParameterName = "@COD_AREA_CURSO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objAREACURSO.NOMAREACURSO;
            prms[1].ParameterName = "@NOM_AREA_CURSO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EAREACURSO objAREACURSO = obj as EAREACURSO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objAREACURSO.CODAREACURSO;
            prms[0].ParameterName = "@COD_AREA_CURSO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objAREACURSO.NOMAREACURSO;
            prms[1].ParameterName = "@NOM_AREA_CURSO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EAREACURSO objRoot = obj as EAREACURSO;

            objRoot.CODAREACURSO = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EAREACURSO objAREACURSO = obj as EAREACURSO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objAREACURSO.CODAREACURSO = Utiles.ConvertToDecimal(dr["COD_AREA_CURSO"]);
            
            objAREACURSO.NOMAREACURSO = Utiles.ConvertToString(dr["NOM_AREA_CURSO"]);
            
        }

        #endregion

	}
}
