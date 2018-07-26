
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCATEGORIA.
	/// </summary>
	public class DLCATEGORIA : DLBase
	{
		public DLCATEGORIA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CATEGORIA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CATEGORIA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CATEGORIA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CATEGORIA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@CODCATEGORIA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECATEGORIA objCATEGORIA = obj as ECATEGORIA;

            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIA.CODCATEGORIA;
            prms[0].ParameterName = "@CODCATEGORIA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECATEGORIA objCATEGORIA = obj as ECATEGORIA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIA.NOMBRECATEGORIA;
            prms[0].ParameterName = "@NOMBRECATEGORIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCATEGORIA.VALORMENOR;
            prms[1].ParameterName = "@VALORMENOR";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCATEGORIA.VALORMAYOR;
            prms[2].ParameterName = "@VALORMAYOR";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            ECATEGORIA objCATEGORIA = obj as ECATEGORIA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIA.CODCATEGORIA;
            prms[0].ParameterName = "@CODCATEGORIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCATEGORIA.NOMBRECATEGORIA;
            prms[1].ParameterName = "@NOMBRECATEGORIA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCATEGORIA.VALORMENOR;
            prms[2].ParameterName = "@VALORMENOR";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objCATEGORIA.VALORMAYOR;
            prms[3].ParameterName = "@VALORMAYOR";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECATEGORIA objRoot = obj as ECATEGORIA;

            objRoot.CODCATEGORIA = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECATEGORIA objCATEGORIA = obj as ECATEGORIA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCATEGORIA.CODCATEGORIA = Utiles.ConvertToDecimal(dr["CODCATEGORIA"]);
            
            objCATEGORIA.NOMBRECATEGORIA = Utiles.ConvertToString(dr["NOMBRECATEGORIA"]);
            
            objCATEGORIA.VALORMENOR = Utiles.ConvertToDouble(dr["VALORMENOR"]);
            
            objCATEGORIA.VALORMAYOR = Utiles.ConvertToDouble(dr["VALORMAYOR"]);
            
        }

        #endregion

	}
}
