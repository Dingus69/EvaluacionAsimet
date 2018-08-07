
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLINSTRUMENTOEMPLEADO.
	/// </summary>
	public class DLINSTRUMENTOEMPLEADO : DLBase
	{
		public DLINSTRUMENTOEMPLEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_INSTRUMENTO_EMPLEADO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO = obj as EINSTRUMENTOEMPLEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(25);
            EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO = obj as EINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOEMPLEADO.FLAGVISADO;
            prms[0].ParameterName = "@FLAG_VISADO";

            prms[1] = db.GetParameter();
            prms[1].Value = objINSTRUMENTOEMPLEADO.CODINSTRUMENTO;
            prms[1].ParameterName = "@COD_INSTRUMENTO";

            prms[2] = db.GetParameter();
            prms[2].Value = objINSTRUMENTOEMPLEADO.NOMINSTRUMENTOEMPLEADO;
            prms[2].ParameterName = "@NOM_INSTRUMENTO_EMPLEADO";

            prms[3] = db.GetParameter();
            prms[3].Value = objINSTRUMENTOEMPLEADO.RUTEMPLEADO;
            prms[3].ParameterName = "@RUT_EMPLEADO";

            prms[4] = db.GetParameter();
            prms[4].Value = objINSTRUMENTOEMPLEADO.RUTEVALUADOR;
            prms[4].ParameterName = "@RUT_EVALUADOR";

            prms[5] = db.GetParameter();
            prms[5].Value = objINSTRUMENTOEMPLEADO.RUTVISADOR;
            prms[5].ParameterName = "@RUT_VISADOR";

            prms[6] = db.GetParameter();
            prms[6].Value = objINSTRUMENTOEMPLEADO.CODTIPOEVAL;
            prms[6].ParameterName = "@COD_TIPO_EVAL";

            prms[7] = db.GetParameter();
            prms[7].Value = objINSTRUMENTOEMPLEADO.CODESTADOEVAL;
            prms[7].ParameterName = "@CODESTADOEVAL";

            prms[8] = db.GetParameter();
            prms[8].Value = objINSTRUMENTOEMPLEADO.INICIOEVALUACION;
            prms[8].ParameterName = "@INICIO_EVALUACION";

            prms[9] = db.GetParameter();
            prms[9].Value = objINSTRUMENTOEMPLEADO.FINEVALUACION;
            prms[9].ParameterName = "@FIN_EVALUACION";

            prms[10] = db.GetParameter();
            prms[10].Value = objINSTRUMENTOEMPLEADO.FECHAEVALUACION;
            prms[10].ParameterName = "@FECHA_EVALUACION";

            prms[11] = db.GetParameter();
            prms[11].Value = objINSTRUMENTOEMPLEADO.RESULTADO;
            prms[11].ParameterName = "@RESULTADO";

            prms[12] = db.GetParameter();
            prms[12].Value = objINSTRUMENTOEMPLEADO.DESCRIPCION;
            prms[12].ParameterName = "@DESCRIPCION";

            prms[13] = db.GetParameter();
            prms[13].Value = objINSTRUMENTOEMPLEADO.OBSERVACION;
            prms[13].ParameterName = "@OBSERVACION";

            prms[14] = db.GetParameter();
            prms[14].Value = objINSTRUMENTOEMPLEADO.RUT_EMPRESA;
            prms[14].ParameterName = "@RUT_EMPRESA";

            prms[15] = db.GetParameter();
            prms[15].Value = objINSTRUMENTOEMPLEADO.FLAG_ACUERDO;
            prms[15].ParameterName = "@FLAG_ACUERDO";

            prms[16] = db.GetParameter();
            prms[16].Value = objINSTRUMENTOEMPLEADO.PLAN_ACCION;
            prms[16].ParameterName = "@PLAN_ACCION";

            prms[17] = db.GetParameter();
            prms[17].Value = objINSTRUMENTOEMPLEADO.COMPROMISO;
            prms[17].ParameterName = "@COMPROMISO";

            prms[18] = db.GetParameter();
            prms[18].Value = objINSTRUMENTOEMPLEADO.COMENTARIOS_CURSO;
            prms[18].ParameterName = "@COMENTARIO_CURSOS";

            prms[19] = db.GetParameter();
            prms[19].Value = objINSTRUMENTOEMPLEADO.FLAG_APELACION;
            prms[19].ParameterName = "@FLAG_APELADO";

            prms[20] = db.GetParameter();
            prms[20].Value = objINSTRUMENTOEMPLEADO.MOTIVO_APELACION;
            prms[20].ParameterName = "@MOTIVO_APELACION";

            prms[21] = db.GetParameter();
            prms[21].Value = objINSTRUMENTOEMPLEADO.DETALLE_VIZACION;
            prms[21].ParameterName = "@DETALLE_VISACION";

            prms[22] = db.GetParameter();
            prms[22].Value = objINSTRUMENTOEMPLEADO.FLAG_ANULADA;
            prms[22].ParameterName = "@FLAG_ANULADA";

            prms[23] = db.GetParameter();
            prms[23].Value = objINSTRUMENTOEMPLEADO.PLAN_DESARROLLO;
            prms[23].ParameterName = "@PLAN_DESARROLLO";

            prms[24] = db.GetParameter();
            prms[24].Value = objINSTRUMENTOEMPLEADO.COMENTARIO_FEEDBACK;
            prms[24].ParameterName = "@COMENTARIO_FEEDBACK";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(26);
            EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO = obj as EINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOEMPLEADO.FLAGVISADO;
            prms[0].ParameterName = "@FLAG_VISADO";

            prms[1] = db.GetParameter();
            prms[1].Value = objINSTRUMENTOEMPLEADO.CODINSTRUMENTO;
            prms[1].ParameterName = "@COD_INSTRUMENTO";

            prms[2] = db.GetParameter();
            prms[2].Value = objINSTRUMENTOEMPLEADO.NOMINSTRUMENTOEMPLEADO;
            prms[2].ParameterName = "@NOM_INSTRUMENTO_EMPLEADO";

            prms[3] = db.GetParameter();
            prms[3].Value = objINSTRUMENTOEMPLEADO.RUTEMPLEADO;
            prms[3].ParameterName = "@RUT_EMPLEADO";

            prms[4] = db.GetParameter();
            prms[4].Value = objINSTRUMENTOEMPLEADO.RUTEVALUADOR;
            prms[4].ParameterName = "@RUT_EVALUADOR";

            prms[5] = db.GetParameter();
            prms[5].Value = objINSTRUMENTOEMPLEADO.RUTVISADOR;
            prms[5].ParameterName = "@RUT_VISADOR";

            prms[6] = db.GetParameter();
            prms[6].Value = objINSTRUMENTOEMPLEADO.CODTIPOEVAL;
            prms[6].ParameterName = "@COD_TIPO_EVAL";

            prms[7] = db.GetParameter();
            prms[7].Value = objINSTRUMENTOEMPLEADO.CODESTADOEVAL;
            prms[7].ParameterName = "@CODESTADOEVAL";

            prms[8] = db.GetParameter();
            prms[8].Value = objINSTRUMENTOEMPLEADO.INICIOEVALUACION;
            prms[8].ParameterName = "@INICIO_EVALUACION";

            prms[9] = db.GetParameter();
            prms[9].Value = objINSTRUMENTOEMPLEADO.FINEVALUACION;
            prms[9].ParameterName = "@FIN_EVALUACION";

            prms[10] = db.GetParameter();
            prms[10].Value = objINSTRUMENTOEMPLEADO.FECHAEVALUACION;
            prms[10].ParameterName = "@FECHA_EVALUACION";

            prms[11] = db.GetParameter();
            prms[11].Value = objINSTRUMENTOEMPLEADO.RESULTADO;
            prms[11].ParameterName = "@RESULTADO";

            prms[12] = db.GetParameter();
            prms[12].Value = objINSTRUMENTOEMPLEADO.DESCRIPCION;
            prms[12].ParameterName = "@DESCRIPCION";

            prms[13] = db.GetParameter();
            prms[13].Value = objINSTRUMENTOEMPLEADO.OBSERVACION;
            prms[13].ParameterName = "@OBSERVACION";

            prms[14] = db.GetParameter();
            prms[14].Value = objINSTRUMENTOEMPLEADO.RUT_EMPRESA;
            prms[14].ParameterName = "@RUT_EMPRESA";

            prms[15] = db.GetParameter();
            prms[15].Value = objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[15].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            prms[16] = db.GetParameter();
            prms[16].Value = objINSTRUMENTOEMPLEADO.PLAN_ACCION;
            prms[16].ParameterName = "@PLAN_ACCION";

            prms[17] = db.GetParameter();
            prms[17].Value = objINSTRUMENTOEMPLEADO.COMPROMISO;
            prms[17].ParameterName = "@COMPROMISO";

            prms[18] = db.GetParameter();
            prms[18].Value = objINSTRUMENTOEMPLEADO.COMENTARIOS_CURSO;
            prms[18].ParameterName = "@COMENTARIO_CURSOS";

            prms[19] = db.GetParameter();
            prms[19].Value = objINSTRUMENTOEMPLEADO.FLAG_APELACION;
            prms[19].ParameterName = "@FLAG_APELADO";

            prms[20] = db.GetParameter();
            prms[20].Value = objINSTRUMENTOEMPLEADO.MOTIVO_APELACION;
            prms[20].ParameterName = "@MOTIVO_APELACION";

            prms[21] = db.GetParameter();
            prms[21].Value = objINSTRUMENTOEMPLEADO.DETALLE_VIZACION;
            prms[21].ParameterName = "@DETALLE_VISACION";

            prms[22] = db.GetParameter();
            prms[22].Value = objINSTRUMENTOEMPLEADO.FLAG_ANULADA;
            prms[22].ParameterName = "@FLAG_ANULADA";

            prms[23] = db.GetParameter();
            prms[23].Value = objINSTRUMENTOEMPLEADO.PLAN_DESARROLLO;
            prms[23].ParameterName = "@PLAN_DESARROLLO";

            prms[24] = db.GetParameter();
            prms[24].Value = objINSTRUMENTOEMPLEADO.COMENTARIO_FEEDBACK;
            prms[24].ParameterName = "@COMENTARIO_FEEDBACK";

            prms[25] = db.GetParameter();
            prms[25].Value = objINSTRUMENTOEMPLEADO.FLAG_ACUERDO;
            prms[25].ParameterName = "@FLAG_ACUERDO";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EINSTRUMENTOEMPLEADO objRoot = obj as EINSTRUMENTOEMPLEADO;

            objRoot.CODINSTRUMENTOEMPLEADO = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO = obj as EINSTRUMENTOEMPLEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO_EMPLEADO"]);
            
            objINSTRUMENTOEMPLEADO.CODINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO"]);
            
            objINSTRUMENTOEMPLEADO.NOMINSTRUMENTOEMPLEADO = Utiles.ConvertToString(dr["NOM_INSTRUMENTO_EMPLEADO"]);

            objINSTRUMENTOEMPLEADO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);

            objINSTRUMENTOEMPLEADO.OBSERVACION = Utiles.ConvertToString(dr["OBSERVACION"]);

            objINSTRUMENTOEMPLEADO.RUTEMPLEADO = Utiles.ConvertToInt64(dr["RUT_EMPLEADO"]);

            objINSTRUMENTOEMPLEADO.RUTEVALUADOR = Utiles.ConvertToInt64(dr["RUT_EVALUADOR"]);
            
            objINSTRUMENTOEMPLEADO.RUTVISADOR = Utiles.ConvertToInt64(dr["RUT_VISADOR"]);
            
            objINSTRUMENTOEMPLEADO.CODTIPOEVAL = Utiles.ConvertToInt16(dr["COD_TIPO_EVAL"]);
            
            objINSTRUMENTOEMPLEADO.CODESTADOEVAL = Utiles.ConvertToDecimal(dr["CODESTADOEVAL"]);
            
            objINSTRUMENTOEMPLEADO.INICIOEVALUACION = Utiles.ConvertToDateTime(dr["INICIO_EVALUACION"]);
            
            objINSTRUMENTOEMPLEADO.FINEVALUACION = Utiles.ConvertToDateTime(dr["FIN_EVALUACION"]);
            
            objINSTRUMENTOEMPLEADO.FECHAEVALUACION = Utiles.ConvertToDateTime(dr["FECHA_EVALUACION"]);
            
            objINSTRUMENTOEMPLEADO.RESULTADO = Utiles.ConvertToDouble(dr["RESULTADO"]);
            
            objINSTRUMENTOEMPLEADO.FLAG_AGREGAR_PREGUNTA = Utiles.ConvertToBoolean(dr["FLAG_AGREGAR_PREGUNTA"]);

            objINSTRUMENTOEMPLEADO.FLAG_VISACION = Utiles.ConvertToBoolean(dr["FLAG_VISACION"]);

            objINSTRUMENTOEMPLEADO.FLAG_APELACION = Utiles.ConvertToBoolean(dr["FLAG_APELACION"]);

            objINSTRUMENTOEMPLEADO.FLAG_AUTOEVALUACION = Utiles.ConvertToBoolean(dr["FLAG_AUTOEVALUACION"]);

            objINSTRUMENTOEMPLEADO.FLAGVISADO = Utiles.ConvertToBoolean(dr["FLAG_VISADO"]);

            objINSTRUMENTOEMPLEADO.NOMBRE_EVALUADO = Utiles.ConvertToString(dr["EVALUADO"]);

            objINSTRUMENTOEMPLEADO.NOMBRE_EVALUADOR = Utiles.ConvertToString(dr["EVALUADOR"]);

            objINSTRUMENTOEMPLEADO.NOMBRE_VISADOR = Utiles.ConvertToString(dr["VISADOR"]);

            objINSTRUMENTOEMPLEADO.COD_TIPO_INTRUMENTO = Utiles.ConvertToInt16(dr["COD_TIPO_INSTRUMENTO"]);

            objINSTRUMENTOEMPLEADO.PLAN_DESARROLLO = Utiles.ConvertToString(dr["PLAN_DESARROLLO"]);

            objINSTRUMENTOEMPLEADO.FLAG_ACUERDO = Utiles.ConvertToBoolean(dr["FLAG_ACUERDO"]);

            objINSTRUMENTOEMPLEADO.COMENTARIO_FEEDBACK = Utiles.ConvertToString(dr["COMENTARIO_FEEDBACK"]);

            DLSECCIONINSTRUMENTOEMPLEADOList objDLSE = new DLSECCIONINSTRUMENTOEMPLEADOList();
            List<ESECCIONINSTRUMENTOEMPLEADO> lstSE = objDLSE.GetSeccionesInstrumentoEmpleado(objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO);
            if (lstSE.Count > 0)
            {
                objINSTRUMENTOEMPLEADO.SECCIONES = lstSE;
            } 

            DLCURSOList objDLCU = new DLCURSOList();
            List<ECURSO> lstCU = objDLCU.GetCursosByInstrumentoEmpleado(objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO);
            if (lstCU.Count > 0)
            {
                objINSTRUMENTOEMPLEADO.CURSOS = lstCU;
            } 

            DLOBJETIVOPROXIMOList objDLOP = new DLOBJETIVOPROXIMOList();
            List<EOBJETIVOPROXIMO> lstOP = objDLOP.GetObjetivosProximos(objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO);
            if (lstOP.Count > 0)
            {
                objINSTRUMENTOEMPLEADO.OBJETIVOSPROXIMOS = lstOP;
            } 

            List<EOBJETIVOPROXIMO> lstOA = objDLOP.GetObjetivosActuales(objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO);
            if (lstOA.Count > 0)
            {
                objINSTRUMENTOEMPLEADO.OBJETIVOSACTUALES = lstOA;
            } 

        }

        #endregion

	}
}
