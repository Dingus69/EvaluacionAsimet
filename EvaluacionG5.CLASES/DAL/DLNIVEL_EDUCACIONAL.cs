
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLNIVELEDUCACIONAL.
	/// </summary>
	public class DLNIVELEDUCACIONAL : DLBase
	{
		public DLNIVELEDUCACIONAL()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_NIVEL_EDUCACIONAL";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_NIVEL_EDUCACIONAL";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_NIVEL_EDUCACIONAL";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_NIVEL_EDUCACIONAL";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_NIVEL_EDUCACIONAL";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ENIVELEDUCACIONAL objNIVELEDUCACIONAL = obj as ENIVELEDUCACIONAL;

            prms[0] = db.GetParameter();
            prms[0].Value = objNIVELEDUCACIONAL.CODNIVELEDUCACIONAL;
            prms[0].ParameterName = "@COD_NIVEL_EDUCACIONAL";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ENIVELEDUCACIONAL objNIVELEDUCACIONAL = obj as ENIVELEDUCACIONAL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objNIVELEDUCACIONAL.CODNIVELEDUCACIONAL;
            prms[0].ParameterName = "@COD_NIVEL_EDUCACIONAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objNIVELEDUCACIONAL.NOMNIVELEDUCACIONAL;
            prms[1].ParameterName = "@NOM_NIVEL_EDUCACIONAL";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ENIVELEDUCACIONAL objNIVELEDUCACIONAL = obj as ENIVELEDUCACIONAL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objNIVELEDUCACIONAL.CODNIVELEDUCACIONAL;
            prms[0].ParameterName = "@COD_NIVEL_EDUCACIONAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objNIVELEDUCACIONAL.NOMNIVELEDUCACIONAL;
            prms[1].ParameterName = "@NOM_NIVEL_EDUCACIONAL";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ENIVELEDUCACIONAL objRoot = obj as ENIVELEDUCACIONAL;

            objRoot.CODNIVELEDUCACIONAL = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ENIVELEDUCACIONAL objNIVELEDUCACIONAL = obj as ENIVELEDUCACIONAL;
    
            //Poner las rutinas del Tools que se necesiten
            
            objNIVELEDUCACIONAL.CODNIVELEDUCACIONAL = Utiles.ConvertToInt16(dr["COD_NIVEL_EDUCACIONAL"]);
            
            objNIVELEDUCACIONAL.NOMNIVELEDUCACIONAL = Utiles.ConvertToString(dr["NOM_NIVEL_EDUCACIONAL"]);
            
        }

        #endregion

	}
}
