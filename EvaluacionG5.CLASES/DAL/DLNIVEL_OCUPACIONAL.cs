
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLNIVELOCUPACIONAL.
	/// </summary>
	public class DLNIVELOCUPACIONAL : DLBase
	{
		public DLNIVELOCUPACIONAL()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_NIVEL_OCUPACIONAL";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_NIVEL_OCUPACIONAL";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_NIVEL_OCUPACIONAL";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_NIVEL_OCUPACIONAL";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_NIVEL_OCUPACIONAL";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ENIVELOCUPACIONAL objNIVELOCUPACIONAL = obj as ENIVELOCUPACIONAL;

            prms[0] = db.GetParameter();
            prms[0].Value = objNIVELOCUPACIONAL.CODNIVELOCUPACIONAL;
            prms[0].ParameterName = "@COD_NIVEL_OCUPACIONAL";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ENIVELOCUPACIONAL objNIVELOCUPACIONAL = obj as ENIVELOCUPACIONAL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objNIVELOCUPACIONAL.CODNIVELOCUPACIONAL;
            prms[0].ParameterName = "@COD_NIVEL_OCUPACIONAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objNIVELOCUPACIONAL.NOMNIVELOCUPACIONAL;
            prms[1].ParameterName = "@NOMNIVEL_OCUPACIONAL";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ENIVELOCUPACIONAL objNIVELOCUPACIONAL = obj as ENIVELOCUPACIONAL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objNIVELOCUPACIONAL.CODNIVELOCUPACIONAL;
            prms[0].ParameterName = "@COD_NIVEL_OCUPACIONAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objNIVELOCUPACIONAL.NOMNIVELOCUPACIONAL;
            prms[1].ParameterName = "@NOMNIVEL_OCUPACIONAL";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ENIVELOCUPACIONAL objRoot = obj as ENIVELOCUPACIONAL;

            objRoot.CODNIVELOCUPACIONAL = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ENIVELOCUPACIONAL objNIVELOCUPACIONAL = obj as ENIVELOCUPACIONAL;
    
            //Poner las rutinas del Tools que se necesiten
            
            objNIVELOCUPACIONAL.CODNIVELOCUPACIONAL = Utiles.ConvertToInt16(dr["COD_NIVEL_OCUPACIONAL"]);
            
            objNIVELOCUPACIONAL.NOMNIVELOCUPACIONAL = Utiles.ConvertToString(dr["NOMNIVEL_OCUPACIONAL"]);
            
        }

        #endregion

	}
}
