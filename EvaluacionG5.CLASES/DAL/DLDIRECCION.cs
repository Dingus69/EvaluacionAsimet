
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLDIRECCION.
	/// </summary>
	public class DLDIRECCION : DLBase
	{
		public DLDIRECCION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_DIRECCION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_DIRECCION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_DIRECCION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_DIRECCION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EDIRECCION objDIRECCION = obj as EDIRECCION;

            prms[0] = db.GetParameter();
            prms[0].Value = objDIRECCION.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EDIRECCION objDIRECCION = obj as EDIRECCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objDIRECCION.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objDIRECCION.CODDIRECCION;
            prms[1].ParameterName = "@COD_DIRECCION";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objDIRECCION.NOMDIRECCION;
            prms[2].ParameterName = "@NOM_DIRECCION";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EDIRECCION objDIRECCION = obj as EDIRECCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objDIRECCION.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objDIRECCION.CODDIRECCION;
            prms[1].ParameterName = "@COD_DIRECCION";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objDIRECCION.NOMDIRECCION;
            prms[2].ParameterName = "@NOM_DIRECCION";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EDIRECCION objRoot = obj as EDIRECCION;

            objRoot.RUTEMPRESA = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EDIRECCION objDIRECCION = obj as EDIRECCION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objDIRECCION.RUTEMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

            objDIRECCION.CODDIRECCION = Utiles.ConvertToString(dr["COD_DIRECCION"]);

            objDIRECCION.NOMDIRECCION = Utiles.ConvertToString(dr["NOM_DIRECCION"]);

        }

        #endregion

	}
}
