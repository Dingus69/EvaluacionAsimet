
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLSECCIONList.
	/// </summary>
    public class DLSECCIONList : DLGenericBaseList<ESECCION>
	{
		public DLSECCIONList()
		{
            this._proc_select_all = "proc_select_SECCION_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ESECCION> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataSet SelectPreguntasByExcel(string newFile)
        {
            string connectionString = DbProviderHelper.GetExcelConn(newFile);
            var ds = new DataSet();
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [Hoja1$]", conn);
                dadp.TableMappings.Add("tbl", "Table");
                dadp.Fill(ds);
            }
            return ds;
        }
        public List<ESECCION> GetSeccionesInstrumento(Decimal CodInstrumento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_SECCIONES_POR_INSTRUMENTO", prms);

            return GetCollection(dr);
        }
    }

    #endregion
}
