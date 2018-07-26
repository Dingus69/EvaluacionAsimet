
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTASECCIONEMPLEADOList.
	/// </summary>
    public class DLPREGUNTASECCIONEMPLEADOList : DLGenericBaseList<EPREGUNTASECCIONEMPLEADO>
	{
		public DLPREGUNTASECCIONEMPLEADOList()
		{
            this._proc_select_all = "proc_select_PREGUNTA_SECCION_EMPLEADO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPREGUNTASECCIONEMPLEADO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public void LimpiarPreguntaSeccionEmp(Decimal CodSeccionInstrumento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodSeccionInstrumento;
            prms[0].ParameterName = "@CODSECCIONINSTRUMENTO";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "pro_LIMPIAR_PREGUNTAS_SECCION_EMPLEADO", prms);

        }

        public void Evaluar(List<EPREGUNTASECCIONEMPLEADO> lst, Int16 CodEstado, Decimal CodInstrumentoEmpleado, Int64 RutUsuario, string Modo)
        {
            foreach (EPREGUNTASECCIONEMPLEADO obj in lst)
            {
                DB db = DatabaseFactory.Instance.GetDatabase();

                IDbDataParameter[] prms = db.GetArrayParameter(4);

                prms[0] = db.GetParameter();
                prms[0].Value = obj.CODSECCIONINSTRUMENTO;
                prms[0].ParameterName = "@CODSECCIONINSTRUMENTO";

                prms[1] = db.GetParameter();
                prms[1].Value = obj.CODPREGUNTAEMPLEADO;
                prms[1].ParameterName = "@CODPREGUNTAEMPLEADO";

                prms[2] = db.GetParameter();
                prms[2].Value = obj.RESULTADO;
                prms[2].ParameterName = "@RESULTADO";

                prms[3] = db.GetParameter();
                prms[3].Value = obj.COMENTARIO;
                prms[3].ParameterName = "@COMENTARIO"; 

                db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_EVALUAR", prms);
            }


            DB db2 = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms2 = db2.GetArrayParameter(4);

            prms2[0] = db2.GetParameter();
            prms2[0].Value = CodInstrumentoEmpleado;
            prms2[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

            prms2[1] = db2.GetParameter();
            prms2[1].Value = CodEstado;
            prms2[1].ParameterName = "@CODESTADO";

            prms2[2] = db2.GetParameter();
            prms2[2].Value = RutUsuario;
            prms2[2].ParameterName = "@RUTUSUARIO";

            prms2[3] = db2.GetParameter();
            prms2[3].Value = Modo;
            prms2[3].ParameterName = "@MODO";

            db2.ExecuteNonQuery(CommandType.StoredProcedure, "proc_CALCULAR_NOTA", prms2);

        }

		#endregion
	}
}
