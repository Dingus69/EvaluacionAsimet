
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUSUARIO.
	/// </summary>
	public class DLUSUARIO : DLBase
	{
		public DLUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@RUT_USUARIO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RUTUSUARIO;
            prms[0].ParameterName = "@RUT_USUARIO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RUTUSUARIO;
            prms[0].ParameterName = "@RUT_USUARIO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUSUARIO.NOMBREUSUARIO;
            prms[1].ParameterName = "@NOMBRE_USUARIO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUSUARIO.APELLIDOPATERNO;
            prms[2].ParameterName = "@APELLIDO_PATERNO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objUSUARIO.APELLIDOMATERNO;
            prms[3].ParameterName = "@APELLIDO_MATERNO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objUSUARIO.PASSWORD;
            prms[4].ParameterName = "@PASSWORD";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objUSUARIO.EMAIL;
            prms[5].ParameterName = "@EMAIL";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objUSUARIO.FLAGACTIVO;
            prms[6].ParameterName = "@FLAG_ACTIVO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EUSUARIO objUSUARIO = obj as EUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUSUARIO.RUTUSUARIO;
            prms[0].ParameterName = "@RUT_USUARIO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUSUARIO.NOMBREUSUARIO;
            prms[1].ParameterName = "@NOMBRE_USUARIO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUSUARIO.APELLIDOPATERNO;
            prms[2].ParameterName = "@APELLIDO_PATERNO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objUSUARIO.APELLIDOMATERNO;
            prms[3].ParameterName = "@APELLIDO_MATERNO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objUSUARIO.PASSWORD;
            prms[4].ParameterName = "@PASSWORD";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objUSUARIO.EMAIL;
            prms[5].ParameterName = "@EMAIL";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objUSUARIO.FLAGACTIVO;
            prms[6].ParameterName = "@FLAG_ACTIVO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EUSUARIO objRoot = obj as EUSUARIO;

            objRoot.RUTUSUARIO = Utiles.ConvertToInt64(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EUSUARIO objUSUARIO = obj as EUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objUSUARIO.RUTUSUARIO = Utiles.ConvertToInt64(dr["RUT_USUARIO"]);
            
            objUSUARIO.NOMBREUSUARIO = Utiles.ConvertToString(dr["NOMBRE_USUARIO"]);
            
            objUSUARIO.APELLIDOPATERNO = Utiles.ConvertToString(dr["APELLIDO_PATERNO"]);
            
            objUSUARIO.APELLIDOMATERNO = Utiles.ConvertToString(dr["APELLIDO_MATERNO"]);
            
            objUSUARIO.PASSWORD = Utiles.ConvertToString(dr["PASSWORD"]);
            
            objUSUARIO.EMAIL = Utiles.ConvertToString(dr["EMAIL"]);
            
            objUSUARIO.FLAGACTIVO = Utiles.ConvertToBoolean(dr["FLAG_ACTIVO"]);
            
        }

        #endregion

	}
}
