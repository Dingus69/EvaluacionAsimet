
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
	/// Summary description for DLINSTRUMENTOEMPLEADOList.
	/// </summary>
    public class DLINSTRUMENTOEMPLEADOList : DLGenericBaseList<EINSTRUMENTOEMPLEADO>
	{
		public DLINSTRUMENTOEMPLEADOList()
		{
            this._proc_select_all = "proc_select_INSTRUMENTO_EMPLEADO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EINSTRUMENTOEMPLEADO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<EINSTRUMENTOEMPLEADO> GetAsignaciones(String NombreAsignacion)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = NombreAsignacion;
            prms[0].ParameterName = "@NOMBREASIGNACION";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_NOMBREASIGNACION", prms);

            return GetCollection(dr);
        }
        public List<EINSTRUMENTOEMPLEADO> GetAsignaciones(String NombreAsignacion, DateTime Inicio, DateTime Fin)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = NombreAsignacion;
            prms[0].ParameterName = "@NOMBREASIGNACION";

            prms[1] = db.GetParameter();
            prms[1].Value = Inicio;
            prms[1].ParameterName = "@INICIO";

            prms[2] = db.GetParameter();
            prms[2].Value = Fin;
            prms[2].ParameterName = "@FIN";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_NOMBREASIGNACION_FECHAS", prms);

            return GetCollection(dr);
        }

        public List<EINSTRUMENTOEMPLEADO> GetAsignaciones(string CodInstrumento, String NombreAsignacion, DateTime Inicio, DateTime Fin)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            prms[1] = db.GetParameter();
            prms[1].Value = NombreAsignacion;
            prms[1].ParameterName = "@NOMBREASIGNACION";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_COD_NOMBREASIGNACION_FECHAS", prms);

            return GetCollection(dr);
        }

        public List<EINSTRUMENTOEMPLEADO> GetAsignaciones(string CodInstrumento, String NombreAsignacion, DateTime Inicio, DateTime Fin, Int16 Tipo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            prms[1] = db.GetParameter();
            prms[1].Value = NombreAsignacion;
            prms[1].ParameterName = "@NOMBREASIGNACION";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            prms[4] = db.GetParameter();
            prms[4].Value = Tipo;
            prms[4].ParameterName = "@TIPO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_COD_NOMBREASIGNACION_FECHAS_TIPO", prms);

            return GetCollection(dr);
        }

        public DataTable GetInstrumentosPorEstado(Int64 Rut, string Nombre, Decimal CodEstado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUTEVALUADOR";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBREINSTRUMENTO";

            //prms[2] = db.GetParameter();
            //prms[2].Value = Inicio;
            //prms[2].ParameterName = "@INICIO";

            //prms[3] = db.GetParameter();
            //prms[3].Value = Fin;
            //prms[3].ParameterName = "@FIN";

            prms[2] = db.GetParameter();
            prms[2].Value = CodEstado;
            prms[2].ParameterName = "@CODESTADO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_POR_ESTAD0", prms);

        }
        public DataTable GetInstrumentosPorEstado(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador, Decimal CodEstado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(13);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Evaluador;
            prms[10].ParameterName = "@EVALUADOR";

            prms[11] = db.GetParameter();
            prms[11].Value = Visador;
            prms[11].ParameterName = "@VISADOR";

            prms[12] = db.GetParameter();
            prms[12].Value = CodEstado;
            prms[12].ParameterName = "@CODESTADO";            

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_POR_ESTAD0_ALL", prms);

        }
        public DataTable GetInstrumentosPorEstado(Int64 Rut, string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2, Decimal CodEstado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(12);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Rut;
            prms[10].ParameterName = "@RUTEVALUADOR";

            prms[11] = db.GetParameter();
            prms[11].Value = CodEstado;
            prms[11].ParameterName = "@CODESTADO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_POR_ESTAD0", prms);

        }
        public DataTable GetInstrumentosPorTipo(Int64 Rut, string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2, Decimal CodTipo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(12);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Rut;
            prms[10].ParameterName = "@RUTEVALUADOR";

            prms[11] = db.GetParameter();
            prms[11].Value = CodTipo;
            prms[11].ParameterName = "@CODTIPO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_POR_TIPO", prms);

        }

        public DataTable BuscarAsignaciones(Decimal CodInstrumento, string Nombre, DateTime Inicio, DateTime Fin)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBREINSTRUMENTO";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_BUSCADOR_ASIGNACIONES", prms);
        }

        public DataTable BuscarAsignacionesPartners(Decimal CodInstrumento, string Nombre, DateTime Inicio, DateTime Fin)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBREINSTRUMENTO";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_BUSCADOR_ASIGNACIONES", prms);
        }

        public DataTable BuscarAsignacionesPartners(Decimal CodInstrumento, string Nombre, DateTime Inicio, DateTime Fin, Int16 Tipo, Int64 RutEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(6);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBREINSTRUMENTO";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            prms[4] = db.GetParameter();
            prms[4].Value = Tipo;
            prms[4].ParameterName = "@TIPO";

            prms[5] = db.GetParameter();
            prms[5].Value = RutEmpresa;
            prms[5].ParameterName = "@RUT_EMPRESA";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_BUSCADOR_ASIGNACIONES_TIPO", prms);
        }

        public DataTable CantidadEvalPorEstado(Int64 Rut, string Nombre)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUTEVALUADOR";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMINSTRUMENTO";

            //prms[2] = db.GetParameter();
            //prms[2].Value = Inicio;
            //prms[2].ParameterName = "@INICIO";

            //prms[3] = db.GetParameter();
            //prms[3].Value = Fin;
            //prms[3].ParameterName = "@FIN";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CANTIDAD_EVAL_POR_ESTADO", prms);
        }

        public DataTable CantidadEvalPorEstado(Int64 Rut, string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(11);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Rut;
            prms[10].ParameterName = "@RUTEVALUADOR";

            //prms[2] = db.GetParameter();
            //prms[2].Value = Inicio;
            //prms[2].ParameterName = "@INICIO";

            //prms[3] = db.GetParameter();
            //prms[3].Value = Fin;
            //prms[3].ParameterName = "@FIN";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CANTIDAD_EVAL_POR_ESTADO", prms);
        }

        public DataTable CantidadEvalPorTipo(Int64 Rut, string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(11);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Rut;
            prms[10].ParameterName = "@RUTEVALUADOR";

            //prms[2] = db.GetParameter();
            //prms[2].Value = Inicio;
            //prms[2].ParameterName = "@INICIO";

            //prms[3] = db.GetParameter();
            //prms[3].Value = Fin;
            //prms[3].ParameterName = "@FIN";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CANTIDAD_EVAL_POR_TIPO", prms);
        }


        public DataTable CantidadEvalPorEstado(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(12);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Evaluador;
            prms[10].ParameterName = "@EVALUADOR";

            prms[11] = db.GetParameter();
            prms[11].Value = Visador;
            prms[11].ParameterName = "@VISADOR";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CANTIDAD_EVAL_POR_ESTADO_ALL", prms);
        }

        public DataTable DistribucionPorCategorias(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(12);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Evaluador;
            prms[10].ParameterName = "@EVALUADOR";

            prms[11] = db.GetParameter();
            prms[11].Value = Visador;
            prms[11].ParameterName = "@VISADOR";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_DISTRIBUCION_POR_CATEGORIA_NOTA", prms);
        }

        public DataTable EvaluacionesPorEvaluador(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUTEVALUADOR";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_EVALUACIONES_POR_EVALUADOR", prms);
        }

        public DataTable Evaluaciones()
        {
            DB db = DatabaseFactory.Instance.GetDatabase(); 

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_EVALUACIONES", null);
        }

        public DataTable GetMisEvaluaciones(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_MIS_EVALUACIONES", prms);
        }

        public DataTable GetHistorial(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_MI_HISTORIAL_EVALUACIONES", prms);
        }

        public DataTable GetDetalleHistorial(Int64 Rut, string NombreInstrumento, DateTime Inicio, DateTime Fin)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUTEMPLEADO";

            prms[1] = db.GetParameter();
            prms[1].Value = NombreInstrumento;
            prms[1].ParameterName = "@NOMBREINSTRUMENTO";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_MI_DETALLE_DE_HISTORIAL", prms);
        }

        public DataTable GetMisKPI(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_MIS_KPI", prms);
        }

        public List<EINSTRUMENTOEMPLEADO> GetMiKPIVigente(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_KPI_VIGENTE", prms);

            return GetCollection(dr);
        }

        public List<EINSTRUMENTOEMPLEADO> GetMiEvaluacionVigente(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_VIGENTE", prms);

            return GetCollection(dr);
        }

        public DataTable GetMisKPIVigente(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_MIS_KPI_VIGENTES", prms);
        }

        public DataTable GetMisVisaciones(Int64 Rut)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_MIS_VISACIONES", prms);

            return dt;
        }

        public DataTable GetResumenGrafico01(Int64 Rut, string NombreEval, DateTime Inicio, DateTime Fin)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT";

            prms[1] = db.GetParameter();
            prms[1].Value = NombreEval;
            prms[1].ParameterName = "@NOMBREINSTRUMENTO";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_INFORME_GRAFICO_01", prms);
        }

        public DataTable GetResumenGrafico02Y03(Int64 Rut, string NombreEval, DateTime Inicio, DateTime Fin, int Tipo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(5);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT";

            prms[1] = db.GetParameter();
            prms[1].Value = NombreEval;
            prms[1].ParameterName = "@NOMBREINSTRUMENTO";

            prms[2] = db.GetParameter();
            prms[2].Value = Inicio;
            prms[2].ParameterName = "@INICIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Fin;
            prms[3].ParameterName = "@FIN";

            prms[4] = db.GetParameter();
            prms[4].Value = Tipo;
            prms[4].ParameterName = "@TIPO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_INFORME_GRAFICO_02_Y_03", prms);
        }

        public DataTable GetResumenSeccionesGrafico02Y03(Int64 Rut, string NombreEval, int Tipo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT";

            prms[1] = db.GetParameter();
            prms[1].Value = NombreEval;
            prms[1].ParameterName = "@NOMBREINSTRUMENTO"; 

            prms[2] = db.GetParameter();
            prms[2].Value = Tipo;
            prms[2].ParameterName = "@TIPO";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_SECCIONES_INFORME_GRAFICO_02_Y_03", prms);
        }

        //public DataTable UpdateEvaluacionRealizada(List<EINSTRUMENTOEMPLEADO> obj)
        //{
        //    DB db = DatabaseFactory.Instance.GetDatabase();
        //    IDbDataParameter[] prms = db.GetArrayParameter(2);

        //    prms[0] = db.GetParameter();
        //    prms[0].Value = obj.CODINSTRUMENTOEMPLEADO;
        //    prms[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

        //    prms[1] = db.GetParameter();
        //    prms[1].Value = obj.CODESTADOEVAL;
        //    prms[1].ParameterName = "@TIPO";

        //    return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_UPDATE_ACTUALIZAR", prms);
        //}

        public void Apelar(Decimal CodInstrumentoEmpleado, string Motivo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            prms[1] = db.GetParameter();
            prms[1].Value = Motivo;
            prms[1].ParameterName = "@MOTIVO";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_APELAR", prms);
        }

        public void Visar(Decimal CodInstrumentoEmpleado, string Motivo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            prms[1] = db.GetParameter();
            prms[1].Value = Motivo;
            prms[1].ParameterName = "@DETALLE";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_VISAR", prms);
        }

        public void AgregarComentario(Decimal CodInstrumentoEmpleado, string Comentario, Int64 RutUsuario, string Modo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(4);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            prms[1] = db.GetParameter();
            prms[1].Value = Comentario;
            prms[1].ParameterName = "@COMENTARIO";

            prms[2] = db.GetParameter();
            prms[2].Value = RutUsuario;
            prms[2].ParameterName = "@RUTUSUARIO";

            prms[3] = db.GetParameter();
            prms[3].Value = Modo;
            prms[3].ParameterName = "@MODO";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_insert_COMENTARIO_BITACORA", prms);
        }

        public void ActualizarPlanDesarrollo(Decimal CodInstrumentoEmpleado, string PlanDesarrollo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            prms[1] = db.GetParameter();
            prms[1].Value = PlanDesarrollo;
            prms[1].ParameterName = "@PLAN_DESARROLLO"; 

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_PLAN_DESARROLLO", prms);
        }

        public void Informar(Decimal CodInstrumentoEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_INFORMAR", prms);
        }

        public void AcuerdoyComentariosFeedback(Decimal CodInstrumentoEmpleado, Boolean Acuerdo, string ComentarioFeedback)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(3);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

            prms[1] = db.GetParameter();
            prms[1].Value = Acuerdo;
            prms[1].ParameterName = "@FLAGACUERDO";

            prms[2] = db.GetParameter();
            prms[2].Value = ComentarioFeedback;
            prms[2].ParameterName = "@COMENTARIOFEEDBACK";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_update_ACUERDO", prms);
        }

        public DataTable GetReporteSabanaDetalle(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(12);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Evaluador;
            prms[10].ParameterName = "@EVALUADOR";

            prms[11] = db.GetParameter();
            prms[11].Value = Visador;
            prms[11].ParameterName = "@VISADOR";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_REPORTE_SABANA_DETALLE", prms);
        }

        public DataTable GetReporteSabanaConsolidado(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(12);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

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

            prms[10] = db.GetParameter();
            prms[10].Value = Evaluador;
            prms[10].ParameterName = "@EVALUADOR";

            prms[11] = db.GetParameter();
            prms[11].Value = Visador;
            prms[11].ParameterName = "@VISADOR";

            return db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_REPORTE_SABANA_CONSOLIDADO", prms);
        }

        public List<EINSTRUMENTOEMPLEADO> GetInstrumentosEstado(string NomInstrumentoEmpleado, string NomEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(12);

            prms[0] = db.GetParameter();
            prms[0].Value = NomInstrumentoEmpleado;
            prms[0].ParameterName = "@NOMBREINSTRUMENTOEMPLEADO";

            prms[1] = db.GetParameter();
            prms[1].Value = NomEmpleado;
            prms[1].ParameterName = "@NOMBREEMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_INSTRUMENTO_EMPLEADO_ESTADOS", prms);

            return GetCollection(dr);
        }

        public DataSet SelectAsignacionesByExcel(string newFile)
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
