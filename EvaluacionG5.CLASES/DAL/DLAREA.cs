
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLAREA.
	/// </summary>
	public class DLAREA : DLBase
	{
		public DLAREA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_AREA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_AREA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_AREA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_AREA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_AREA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EAREA objAREA = obj as EAREA;

            prms[0] = db.GetParameter();
            prms[0].Value = objAREA.CODAREA;
            prms[0].ParameterName = "@COD_AREA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EAREA objAREA = obj as EAREA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objAREA.CODAREA;
            prms[0].ParameterName = "@COD_AREA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objAREA.NOMBREAREA;
            prms[1].ParameterName = "@NOMBRE_AREA";

            prms[2] = db.GetParameter();
            prms[2].Value = objAREA.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EAREA objAREA = obj as EAREA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objAREA.CODAREA;
            prms[0].ParameterName = "@COD_AREA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objAREA.NOMBREAREA;
            prms[1].ParameterName = "@NOMBRE_AREA";

            prms[2] = db.GetParameter();
            prms[2].Value = objAREA.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EAREA objRoot = obj as EAREA;

            objRoot.CODAREA = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EAREA objAREA = obj as EAREA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objAREA.CODAREA = Utiles.ConvertToString(dr["COD_AREA"]);
            
            objAREA.NOMBREAREA = Utiles.ConvertToString(dr["NOMBRE_AREA"]);

            objAREA.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

        }

        #endregion

	}
}
