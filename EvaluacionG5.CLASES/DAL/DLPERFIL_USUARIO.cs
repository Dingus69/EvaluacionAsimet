
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPERFILUSUARIO.
	/// </summary>
	public class DLPERFILUSUARIO : DLBase
	{
		public DLPERFILUSUARIO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PERFIL_USUARIO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PERFIL_USUARIO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PERFIL_USUARIO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PERFIL_USUARIO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_PERFIL";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPERFILUSUARIO objPERFILUSUARIO = obj as EPERFILUSUARIO;

            prms[0] = db.GetParameter();
            prms[0].Value = objPERFILUSUARIO.CODPERFIL;
            prms[0].ParameterName = "@COD_PERFIL";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPERFILUSUARIO objPERFILUSUARIO = obj as EPERFILUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPERFILUSUARIO.CODPERFIL;
            prms[0].ParameterName = "@COD_PERFIL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPERFILUSUARIO.RUTUSUARIO;
            prms[1].ParameterName = "@RUT_USUARIO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EPERFILUSUARIO objPERFILUSUARIO = obj as EPERFILUSUARIO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPERFILUSUARIO.CODPERFIL;
            prms[0].ParameterName = "@COD_PERFIL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPERFILUSUARIO.RUTUSUARIO;
            prms[1].ParameterName = "@RUT_USUARIO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPERFILUSUARIO objRoot = obj as EPERFILUSUARIO;

            objRoot.CODPERFIL = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPERFILUSUARIO objPERFILUSUARIO = obj as EPERFILUSUARIO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPERFILUSUARIO.CODPERFIL = Utiles.ConvertToInt16(dr["COD_PERFIL"]);
            
            objPERFILUSUARIO.RUTUSUARIO = Utiles.ConvertToInt64(dr["RUT_USUARIO"]);
            
        }

        #endregion

	}
}
