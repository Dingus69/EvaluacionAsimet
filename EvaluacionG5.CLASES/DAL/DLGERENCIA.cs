
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLGERENCIA.
	/// </summary>
	public class DLGERENCIA : DLBase
	{
		public DLGERENCIA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_GERENCIA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_GERENCIA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_GERENCIA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_GERENCIA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_GERENCIA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EGERENCIA objGERENCIA = obj as EGERENCIA;

            prms[0] = db.GetParameter();
            prms[0].Value = objGERENCIA.CODGERENCIA;
            prms[0].ParameterName = "@COD_GERENCIA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EGERENCIA objGERENCIA = obj as EGERENCIA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objGERENCIA.CODGERENCIA;
            prms[0].ParameterName = "@COD_GERENCIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objGERENCIA.NOMBREGERENCIA;
            prms[1].ParameterName = "@NOMBRE_GERENCIA";

            prms[2] = db.GetParameter();
            prms[2].Value = objGERENCIA.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EGERENCIA objGERENCIA = obj as EGERENCIA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objGERENCIA.CODGERENCIA;
            prms[0].ParameterName = "@COD_GERENCIA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objGERENCIA.NOMBREGERENCIA;
            prms[1].ParameterName = "@NOMBRE_GERENCIA";

            prms[2] = db.GetParameter();
            prms[2].Value = objGERENCIA.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EGERENCIA objRoot = obj as EGERENCIA;

            objRoot.CODGERENCIA = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EGERENCIA objGERENCIA = obj as EGERENCIA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objGERENCIA.CODGERENCIA = Utiles.ConvertToString(dr["COD_GERENCIA"]);
            
            objGERENCIA.NOMBREGERENCIA = Utiles.ConvertToString(dr["NOMBRE_GERENCIA"]);

            objGERENCIA.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

        }

        #endregion

	}
}
