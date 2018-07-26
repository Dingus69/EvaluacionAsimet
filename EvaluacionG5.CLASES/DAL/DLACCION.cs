
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLACCION.
	/// </summary>
	public class DLACCION : DLBase
	{
		public DLACCION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ACCION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ACCION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ACCION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ACCION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_ACCION";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACCION objACCION = obj as EACCION;

            prms[0] = db.GetParameter();
            prms[0].Value = objACCION.CODACCION;
            prms[0].ParameterName = "@COD_ACCION";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EACCION objACCION = obj as EACCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACCION.CODACCION;
            prms[0].ParameterName = "@COD_ACCION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACCION.NOMBREACCION;
            prms[1].ParameterName = "@NOMBRE_ACCION";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EACCION objACCION = obj as EACCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objACCION.CODACCION;
            prms[0].ParameterName = "@COD_ACCION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objACCION.NOMBREACCION;
            prms[1].ParameterName = "@NOMBRE_ACCION";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EACCION objRoot = obj as EACCION;

            objRoot.CODACCION = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EACCION objACCION = obj as EACCION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objACCION.CODACCION = Utiles.ConvertToInt16(dr["COD_ACCION"]);
            
            objACCION.NOMBREACCION = Utiles.ConvertToString(dr["NOMBRE_ACCION"]);
            
        }

        #endregion

	}
}
