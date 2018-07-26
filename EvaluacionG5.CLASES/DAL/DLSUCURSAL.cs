
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLSUCURSAL.
	/// </summary>
	public class DLSUCURSAL : DLBase
	{
		public DLSUCURSAL()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_SUCURSAL";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_SUCURSAL";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_SUCURSAL";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_SUCURSAL";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_SUCURSAL";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ESUCURSAL objSUCURSAL = obj as ESUCURSAL;

            prms[0] = db.GetParameter();
            prms[0].Value = objSUCURSAL.CODSUCURSAL;
            prms[0].ParameterName = "@COD_SUCURSAL";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ESUCURSAL objSUCURSAL = obj as ESUCURSAL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSUCURSAL.CODSUCURSAL;
            prms[0].ParameterName = "@COD_SUCURSAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSUCURSAL.NOMBRESUCURSAL;
            prms[1].ParameterName = "@NOMBRE_SUCURSAL";

            prms[2] = db.GetParameter();
            prms[2].Value = objSUCURSAL.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ESUCURSAL objSUCURSAL = obj as ESUCURSAL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSUCURSAL.CODSUCURSAL;
            prms[0].ParameterName = "@COD_SUCURSAL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSUCURSAL.NOMBRESUCURSAL;
            prms[1].ParameterName = "@NOMBRE_SUCURSAL";

            prms[2] = db.GetParameter();
            prms[2].Value = objSUCURSAL.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ESUCURSAL objRoot = obj as ESUCURSAL;

            objRoot.CODSUCURSAL = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ESUCURSAL objSUCURSAL = obj as ESUCURSAL;
    
            //Poner las rutinas del Tools que se necesiten
            
            objSUCURSAL.CODSUCURSAL = Utiles.ConvertToString(dr["COD_SUCURSAL"]);
            
            objSUCURSAL.NOMBRESUCURSAL = Utiles.ConvertToString(dr["NOMBRE_SUCURSAL"]);

            objSUCURSAL.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

        }

        #endregion

	}
}
