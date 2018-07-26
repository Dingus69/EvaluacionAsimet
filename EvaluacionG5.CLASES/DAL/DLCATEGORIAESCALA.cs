
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCATEGORIAESCALA.
	/// </summary>
	public class DLCATEGORIAESCALA : DLBase
	{
		public DLCATEGORIAESCALA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CATEGORIAESCALA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CATEGORIAESCALA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CATEGORIAESCALA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CATEGORIAESCALA";
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
            ECATEGORIAESCALA objCATEGORIAESCALA = obj as ECATEGORIAESCALA;

            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIAESCALA.CODCATEGORIA;
            prms[0].ParameterName = "@CODCATEGORIA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECATEGORIAESCALA objCATEGORIAESCALA = obj as ECATEGORIAESCALA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIAESCALA.CODCATEGORIA;
            prms[0].ParameterName = "@CODCATEGORIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCATEGORIAESCALA.CODESCALA;
            prms[1].ParameterName = "@CODESCALA";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECATEGORIAESCALA objCATEGORIAESCALA = obj as ECATEGORIAESCALA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCATEGORIAESCALA.CODCATEGORIA;
            prms[0].ParameterName = "@CODCATEGORIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCATEGORIAESCALA.CODESCALA;
            prms[1].ParameterName = "@CODESCALA";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECATEGORIAESCALA objRoot = obj as ECATEGORIAESCALA;

            objRoot.CODCATEGORIA = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECATEGORIAESCALA objCATEGORIAESCALA = obj as ECATEGORIAESCALA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCATEGORIAESCALA.CODCATEGORIA = Utiles.ConvertToDecimal(dr["CODCATEGORIA"]);
            
            objCATEGORIAESCALA.CODESCALA = Utiles.ConvertToDecimal(dr["CODESCALA"]);
            
        }

        #endregion

	}
}
