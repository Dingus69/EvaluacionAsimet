
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLROL.
	/// </summary>
	public class DLROL : DLBase
	{
		public DLROL()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ROL";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ROL";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ROL";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ROL";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_ROL";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EROL objROL = obj as EROL;

            prms[0] = db.GetParameter();
            prms[0].Value = objROL.CODROL;
            prms[0].ParameterName = "@COD_ROL";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EROL objROL = obj as EROL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objROL.CODROL;
            prms[0].ParameterName = "@COD_ROL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objROL.NOMBREROL;
            prms[1].ParameterName = "@NOMBRE_ROL";

            prms[2] = db.GetParameter();
            prms[2].Value = objROL.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EROL objROL = obj as EROL;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objROL.CODROL;
            prms[0].ParameterName = "@COD_ROL";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objROL.NOMBREROL;
            prms[1].ParameterName = "@NOMBRE_ROL";

            prms[2] = db.GetParameter();
            prms[2].Value = objROL.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EROL objRoot = obj as EROL;

            objRoot.CODROL = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EROL objROL = obj as EROL;
    
            //Poner las rutinas del Tools que se necesiten
            
            objROL.CODROL = Utiles.ConvertToString(dr["COD_ROL"]);
            
            objROL.NOMBREROL = Utiles.ConvertToString(dr["NOMBRE_ROL"]);

            objROL.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

        }

        #endregion

	}
}
