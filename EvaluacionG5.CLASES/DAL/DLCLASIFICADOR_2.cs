
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCLASIFICADOR2.
	/// </summary>
	public class DLCLASIFICADOR2 : DLBase
	{
		public DLCLASIFICADOR2()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CLASIFICADOR_2";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CLASIFICADOR_2";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CLASIFICADOR_2";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CLASIFICADOR_2";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CLASIFICADOR_2";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECLASIFICADOR2 objCLASIFICADOR2 = obj as ECLASIFICADOR2;

            prms[0] = db.GetParameter();
            prms[0].Value = objCLASIFICADOR2.CODCLASIFICADOR2;
            prms[0].ParameterName = "@COD_CLASIFICADOR_2";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECLASIFICADOR2 objCLASIFICADOR2 = obj as ECLASIFICADOR2;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCLASIFICADOR2.CODCLASIFICADOR2;
            prms[0].ParameterName = "@COD_CLASIFICADOR_2";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCLASIFICADOR2.NOMBRECLASIFICADOR2;
            prms[1].ParameterName = "@NOMBRE_CLASIFICADOR_2";

            prms[2] = db.GetParameter();
            prms[2].Value = objCLASIFICADOR2.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECLASIFICADOR2 objCLASIFICADOR2 = obj as ECLASIFICADOR2;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCLASIFICADOR2.CODCLASIFICADOR2;
            prms[0].ParameterName = "@COD_CLASIFICADOR_2";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCLASIFICADOR2.NOMBRECLASIFICADOR2;
            prms[1].ParameterName = "@NOMBRE_CLASIFICADOR_2";

            prms[2] = db.GetParameter();
            prms[2].Value = objCLASIFICADOR2.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECLASIFICADOR2 objRoot = obj as ECLASIFICADOR2;

            objRoot.CODCLASIFICADOR2 = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECLASIFICADOR2 objCLASIFICADOR2 = obj as ECLASIFICADOR2;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCLASIFICADOR2.CODCLASIFICADOR2 = Utiles.ConvertToString(dr["COD_CLASIFICADOR_2"]);
            
            objCLASIFICADOR2.NOMBRECLASIFICADOR2 = Utiles.ConvertToString(dr["NOMBRE_CLASIFICADOR_2"]);

            objCLASIFICADOR2.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

        }

        #endregion

	}
}
