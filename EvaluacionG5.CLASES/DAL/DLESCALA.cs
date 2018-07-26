
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLESCALA.
	/// </summary>
	public class DLESCALA : DLBase
	{
		public DLESCALA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_ESCALA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_ESCALA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_ESCALA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_ESCALA";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@CODESCALA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EESCALA objESCALA = obj as EESCALA;

            prms[0] = db.GetParameter();
            prms[0].Value = objESCALA.CODESCALA;
            prms[0].ParameterName = "@CODESCALA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EESCALA objESCALA = obj as EESCALA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objESCALA.NOMESCALA;
            prms[0].ParameterName = "@NOMESCALA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objESCALA.VALORMENOR;
            prms[1].ParameterName = "@VALORMENOR";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objESCALA.VALORMAYOR;
            prms[2].ParameterName = "@VALORMAYOR";

            prms[3] = db.GetParameter();
            prms[3].Value = objESCALA.INSTRUCCIONES;
            prms[3].ParameterName = "@INSTRUCCIONES";

            prms[4] = db.GetParameter();
            prms[4].Value = objESCALA.FLAG_RANGOS;
            prms[4].ParameterName = "@FLAG_RANGOS";

            prms[5] = db.GetParameter();
            prms[5].Value = objESCALA.RUT_EMPRESA;
            prms[5].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EESCALA objESCALA = obj as EESCALA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objESCALA.CODESCALA;
            prms[0].ParameterName = "@CODESCALA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objESCALA.NOMESCALA;
            prms[1].ParameterName = "@NOMESCALA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objESCALA.VALORMENOR;
            prms[2].ParameterName = "@VALORMENOR";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objESCALA.VALORMAYOR;
            prms[3].ParameterName = "@VALORMAYOR";

            prms[4] = db.GetParameter();
            prms[4].Value = objESCALA.INSTRUCCIONES;
            prms[4].ParameterName = "@INSTRUCCIONES";

            prms[5] = db.GetParameter();
            prms[5].Value = objESCALA.FLAG_RANGOS;
            prms[5].ParameterName = "@FLAG_RANGOS";

            prms[6] = db.GetParameter();
            prms[6].Value = objESCALA.RUT_EMPRESA;
            prms[6].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EESCALA objRoot = obj as EESCALA;

            objRoot.CODESCALA = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EESCALA objESCALA = obj as EESCALA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objESCALA.CODESCALA = Utiles.ConvertToDecimal(dr["CODESCALA"]);
            
            objESCALA.NOMESCALA = Utiles.ConvertToString(dr["NOMESCALA"]);
            
            objESCALA.VALORMENOR = Utiles.ConvertToDouble(dr["VALORMENOR"]);
            
            objESCALA.VALORMAYOR = Utiles.ConvertToDouble(dr["VALORMAYOR"]);

            objESCALA.INSTRUCCIONES = Utiles.ConvertToString(dr["INSTRUCCIONES"]);

            objESCALA.FLAG_RANGOS = Utiles.ConvertToBoolean(dr["FLAG_RANGOS"]);

            objESCALA.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

            DLCATEGORIAList objCA = new DLCATEGORIAList();
            objESCALA.CATEGORIAS = objCA.GetCategoriasPorEscala(objESCALA.CODESCALA);

            DLRANGOList objRA = new DLRANGOList();
            objESCALA.RANGOS = objRA.GetRangosPorEscala(objESCALA.CODESCALA);

        }

        #endregion

	}
}
