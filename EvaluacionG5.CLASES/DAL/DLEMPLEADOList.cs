
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
	/// Summary description for DLEMPLEADOList.
	/// </summary>
    public class DLEMPLEADOList : DLGenericBaseList<EEMPLEADO>
	{
		public DLEMPLEADOList()
		{
            this._proc_select_all = "proc_select_EMPLEADO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EEMPLEADO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EEMPLEADO> GetEmpleados(Int64 Rut, string Nombre)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBRE";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_EMPLEADO_BY_RUT_NOMBRE", prms);

            return GetCollection(dr);
        }

        public DataTable GetEvaluadoresPorEvaluacion(string NombreInstrumento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = NombreInstrumento;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_EVALUADORES_POR_EVALUACION", prms);
            
        }

        public DataTable GetVisadoresPorEvaluacion(string NombreInstrumento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = NombreInstrumento;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_VISADORES_POR_EVALUACION", prms);
            
        }

        public DataTable SelectCargados(string ListaRuts)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = ListaRuts;
            prms[0].ParameterName = "@LISTARUT";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_EMPLEADOS_CARGADOS", prms);

            return dt;
        }
        public List<EEMPLEADO> GetEmpleadosByCargoAndNombre(string CodCargo, string Nombre)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodCargo;
            prms[0].ParameterName = "@CODCARGO";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBRE";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_EMPLEADO_BY_CARGO_NOMBRE", prms);

            return GetCollection(dr);
        }
        public List<EEMPLEADO> GetEmpleadosByRutJefe(Int64 RutJefe)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutJefe;
            prms[0].ParameterName = "@RUTJEFE"; 

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_EMPLEADO_BY_RUT_JEFE", prms);

            return GetCollection(dr);
        }
        public List<EEMPLEADO> GetEmpleadosPorFiltros(string Nombre, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(10);

            prms[0] = db.GetParameter();
            prms[0].Value = Nombre;
            prms[0].ParameterName = "@NOMBRE";

            prms[1] = db.GetParameter();
            prms[1].Value = RutEmpresa;
            prms[1].ParameterName = "@RUTEMPRESA";

            prms[2] = db.GetParameter();
            prms[2].Value = CodGerencia;
            prms[2].ParameterName = "@CODGERENCIA";

            prms[3] = db.GetParameter();
            prms[3].Value = CodCentroCosto;
            prms[3].ParameterName = "@CODCENTROCOSTO";

            prms[4] = db.GetParameter();
            prms[4].Value = CodSucursal;
            prms[4].ParameterName = "@CODSUCURSAL";

            prms[5] = db.GetParameter();
            prms[5].Value = CodArea;
            prms[5].ParameterName = "@CODAREA";

            prms[6] = db.GetParameter();
            prms[6].Value = CodCargo;
            prms[6].ParameterName = "@CODCARGO";

            prms[7] = db.GetParameter();
            prms[7].Value = CodRol;
            prms[7].ParameterName = "@CODROL";

            prms[8] = db.GetParameter();
            prms[8].Value = CodClasificador1;
            prms[8].ParameterName = "@CODCLASIFICADOR1";

            prms[9] = db.GetParameter();
            prms[9].Value = CodClasificador2;
            prms[9].ParameterName = "@CODCLASIFICADOR2";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_EMPLEADO_BY_FILTROS", prms);

            return GetCollection(dr);
        }

        public DataSet SelectEmpleadosByExcel(string newFile)
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

        #endregion
    }
}
