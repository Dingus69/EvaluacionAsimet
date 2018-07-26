

using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLHOJADEVIDA.
	/// </summary>
	public class DLHOJADEVIDA : DLBase
	{
		public DLHOJADEVIDA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_HOJA_DE_VIDA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_HOJA_DE_VIDA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_HOJA_DE_VIDA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_HOJA_DE_VIDA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_HOJA_DE_VIDA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EHOJADEVIDA objHOJADEVIDA = obj as EHOJADEVIDA;

            prms[0] = db.GetParameter();
            prms[0].Value = objHOJADEVIDA.CODHOJADEVIDA;
            prms[0].ParameterName = "@COD_HOJA_DE_VIDA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EHOJADEVIDA objHOJADEVIDA = obj as EHOJADEVIDA;

            //Poner las rutinas del Tools que se necesiten 

            prms[0] = db.GetParameter();
            prms[0].Value = objHOJADEVIDA.RUTUSUARIO;
            prms[0].ParameterName = "@RUT_USUARIO";

            prms[1] = db.GetParameter();
            prms[1].Value = objHOJADEVIDA.RUTEMPLEADO;
            prms[1].ParameterName = "@RUT_EMPLEADO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objHOJADEVIDA.OBSERVACION;
            prms[2].ParameterName = "@OBSERVACION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objHOJADEVIDA.FECHAINGRESO;
            prms[3].ParameterName = "@FECHA_INGRESO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EHOJADEVIDA objHOJADEVIDA = obj as EHOJADEVIDA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objHOJADEVIDA.CODHOJADEVIDA;
            prms[0].ParameterName = "@COD_HOJA_DE_VIDA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objHOJADEVIDA.RUTEMPLEADO;
            prms[1].ParameterName = "@RUT_EMPLEADO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objHOJADEVIDA.OBSERVACION;
            prms[2].ParameterName = "@OBSERVACION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objHOJADEVIDA.FECHAINGRESO;
            prms[3].ParameterName = "@FECHA_INGRESO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objHOJADEVIDA.RUTUSUARIO;
            prms[4].ParameterName = "@RUT_USUARIO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EHOJADEVIDA objRoot = obj as EHOJADEVIDA;

            objRoot.CODHOJADEVIDA = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EHOJADEVIDA objHOJADEVIDA = obj as EHOJADEVIDA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objHOJADEVIDA.CODHOJADEVIDA = Utiles.ConvertToDecimal(dr["COD_HOJA_DE_VIDA"]);
            
            objHOJADEVIDA.RUTEMPLEADO = Utiles.ConvertToInt64(dr["RUT_EMPLEADO"]);

            objHOJADEVIDA.OBSERVACION = Utiles.ConvertToString(dr["OBSERVACION"]);

            objHOJADEVIDA.FECHAINGRESO = Utiles.ConvertToDateTime(dr["FECHA_INGRESO"]);

            objHOJADEVIDA.RUTUSUARIO = Utiles.ConvertToInt64(dr["RUT_USUARIO"]);

        }

        #endregion

	}
}
