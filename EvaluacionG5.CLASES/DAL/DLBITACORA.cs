
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLBITACORA.
	/// </summary>
	public class DLBITACORA : DLBase
	{
		public DLBITACORA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_BITACORA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_BITACORA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_BITACORA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_BITACORA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@CODBITACORA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EBITACORA objBITACORA = obj as EBITACORA;

            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORA.CODBITACORA;
            prms[0].ParameterName = "@CODBITACORA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EBITACORA objBITACORA = obj as EBITACORA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORA.CODBITACORA;
            prms[0].ParameterName = "@CODBITACORA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORA.CODACCION;
            prms[1].ParameterName = "@COD_ACCION";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORA.RUTUSUARIO;
            prms[2].ParameterName = "@RUT_USUARIO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORA.FECHA;
            prms[3].ParameterName = "@FECHA";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORA.DESCRIPCION;
            prms[4].ParameterName = "@DESCRIPCION";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EBITACORA objBITACORA = obj as EBITACORA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objBITACORA.CODBITACORA;
            prms[0].ParameterName = "@CODBITACORA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objBITACORA.CODACCION;
            prms[1].ParameterName = "@COD_ACCION";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objBITACORA.RUTUSUARIO;
            prms[2].ParameterName = "@RUT_USUARIO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objBITACORA.FECHA;
            prms[3].ParameterName = "@FECHA";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objBITACORA.DESCRIPCION;
            prms[4].ParameterName = "@DESCRIPCION";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EBITACORA objRoot = obj as EBITACORA;

            objRoot.CODBITACORA = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EBITACORA objBITACORA = obj as EBITACORA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objBITACORA.CODBITACORA = Utiles.ConvertToDecimal(dr["CODBITACORA"]);
            
            objBITACORA.CODACCION = Utiles.ConvertToInt16(dr["COD_ACCION"]);
            
            objBITACORA.RUTUSUARIO = Utiles.ConvertToInt64(dr["RUT_USUARIO"]);
            
            objBITACORA.FECHA = Utiles.ConvertToDateTime(dr["FECHA"]);
            
            objBITACORA.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);
            
        }

        #endregion

	}
}
