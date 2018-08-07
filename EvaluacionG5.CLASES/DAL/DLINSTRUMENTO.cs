
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLINSTRUMENTO.
	/// </summary>
	public class DLINSTRUMENTO : DLBase
	{
		public DLINSTRUMENTO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_INSTRUMENTO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_INSTRUMENTO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_INSTRUMENTO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_INSTRUMENTO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_INSTRUMENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EINSTRUMENTO objINSTRUMENTO = obj as EINSTRUMENTO;

            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTO.CODINSTRUMENTO;
            prms[0].ParameterName = "@COD_INSTRUMENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(14);
            EINSTRUMENTO objINSTRUMENTO = obj as EINSTRUMENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTO.FLAG_APELACION;
            prms[0].ParameterName = "@FLAG_APELACION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objINSTRUMENTO.CODESCALA;
            prms[1].ParameterName = "@CODESCALA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objINSTRUMENTO.FLAGCALIBRACION;
            prms[2].ParameterName = "@FLAG_CALIBRACION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objINSTRUMENTO.NOMBREINSTRUMENTO;
            prms[3].ParameterName = "@NOMBRE_INSTRUMENTO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objINSTRUMENTO.DESCRIPCION;
            prms[4].ParameterName = "@DESCRIPCION";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objINSTRUMENTO.OBSERVACION;
            prms[5].ParameterName = "@OBSERVACION";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objINSTRUMENTO.FLAGAUTOEVALUACION;
            prms[6].ParameterName = "@FLAG_AUTOEVALUACION";

            prms[7] = db.GetParameter();
            prms[7].Value = objINSTRUMENTO.FLAG_VISACION;
            prms[7].ParameterName = "@FLAG_VISACION";

            prms[8] = db.GetParameter();
            prms[8].Value = objINSTRUMENTO.RUT_EMPRESA;
            prms[8].ParameterName = "@RUT_EMPRESA";

            prms[9] = db.GetParameter();
            prms[9].Value = objINSTRUMENTO.FLAGINGRESOOBJETIVOS;
            prms[9].ParameterName = "@FLAG_INGRESO_OBJETIVOS"; 

            prms[10] = db.GetParameter();
            prms[10].Value = objINSTRUMENTO.PONDAUTOEVALUACION;
            prms[10].ParameterName = "@POND_AUTO_EVALUACION";

            prms[11] = db.GetParameter();
            prms[11].Value = objINSTRUMENTO.PONDPARES;
            prms[11].ParameterName = "@POND_PARES";

            prms[12] = db.GetParameter();
            prms[12].Value = objINSTRUMENTO.PONDJEFATURAS;
            prms[12].ParameterName = "@POND_JEFATURAS";

            prms[13] = db.GetParameter();
            prms[13].Value = objINSTRUMENTO.PONDCOLABORADORES;
            prms[13].ParameterName = "@POND_COLABORADORES";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(15);
            EINSTRUMENTO objINSTRUMENTO = obj as EINSTRUMENTO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTO.CODINSTRUMENTO;
            prms[0].ParameterName = "@COD_INSTRUMENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objINSTRUMENTO.CODESCALA;
            prms[1].ParameterName = "@CODESCALA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objINSTRUMENTO.FLAGCALIBRACION;
            prms[2].ParameterName = "@FLAG_CALIBRACION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objINSTRUMENTO.NOMBREINSTRUMENTO;
            prms[3].ParameterName = "@NOMBRE_INSTRUMENTO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objINSTRUMENTO.DESCRIPCION;
            prms[4].ParameterName = "@DESCRIPCION";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objINSTRUMENTO.OBSERVACION;
            prms[5].ParameterName = "@OBSERVACION";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objINSTRUMENTO.FLAGAUTOEVALUACION;
            prms[6].ParameterName = "@FLAG_AUTOEVALUACION";


            prms[7] = db.GetParameter();
            prms[7].Value = objINSTRUMENTO.FLAG_VISACION;
            prms[7].ParameterName = "@FLAG_VISACION";


            prms[8] = db.GetParameter();
            prms[8].Value = objINSTRUMENTO.FLAG_APELACION;
            prms[8].ParameterName = "@FLAG_APELACION";

            prms[9] = db.GetParameter();
            prms[9].Value = objINSTRUMENTO.RUT_EMPRESA;
            prms[9].ParameterName = "@RUT_EMPRESA";

            prms[10] = db.GetParameter();
            prms[10].Value = objINSTRUMENTO.FLAGINGRESOOBJETIVOS;
            prms[10].ParameterName = "@FLAG_INGRESO_OBJETIVOS";

            prms[11] = db.GetParameter();
            prms[11].Value = objINSTRUMENTO.PONDAUTOEVALUACION;
            prms[11].ParameterName = "@POND_AUTO_EVALUACION";

            prms[12] = db.GetParameter();
            prms[12].Value = objINSTRUMENTO.PONDJEFATURAS;
            prms[12].ParameterName = "@POND_JEFATURAS";

            prms[13] = db.GetParameter();
            prms[13].Value = objINSTRUMENTO.PONDCOLABORADORES;
            prms[13].ParameterName = "@POND_COLABORADORES";

            prms[14] = db.GetParameter();
            prms[14].Value = objINSTRUMENTO.PONDPARES;
            prms[14].ParameterName = "@POND_PARES"; 

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EINSTRUMENTO objRoot = obj as EINSTRUMENTO;

            objRoot.CODINSTRUMENTO = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EINSTRUMENTO objINSTRUMENTO = obj as EINSTRUMENTO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objINSTRUMENTO.CODINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO"]);
            
            objINSTRUMENTO.CODESCALA = Utiles.ConvertToDecimal(dr["CODESCALA"]); 
            
            objINSTRUMENTO.NOMBREINSTRUMENTO = Utiles.ConvertToString(dr["NOMBRE_INSTRUMENTO"]);
            
            objINSTRUMENTO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);
            
            objINSTRUMENTO.OBSERVACION = Utiles.ConvertToString(dr["OBSERVACION"]);
            
            objINSTRUMENTO.FLAGAUTOEVALUACION = Utiles.ConvertToBoolean(dr["FLAG_AUTOEVALUACION"]);

            objINSTRUMENTO.FLAG_APELACION = Utiles.ConvertToBoolean(dr["FLAG_APELACION"]);

            objINSTRUMENTO.FLAG_VISACION = Utiles.ConvertToBoolean(dr["FLAG_VISACION"]);

            objINSTRUMENTO.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

            objINSTRUMENTO.FLAGCALIBRACION = Utiles.ConvertToBoolean(dr["FLAG_CALIBRACION"]);

            objINSTRUMENTO.FLAGINGRESOOBJETIVOS = Utiles.ConvertToBoolean(dr["FLAG_INGRESO_OBJETIVOS"]);

            objINSTRUMENTO.PONDAUTOEVALUACION = Utiles.ConvertToDouble(dr["POND_AUTO_EVALUACION"]);

            objINSTRUMENTO.PONDJEFATURAS = Utiles.ConvertToDouble(dr["POND_JEFATURAS"]);

            objINSTRUMENTO.PONDCOLABORADORES = Utiles.ConvertToDouble(dr["POND_COLABORADORES"]);

            objINSTRUMENTO.PONDPARES = Utiles.ConvertToDouble(dr["POND_PARES"]);

            DLSECCIONList objDLSE = new DLSECCIONList();
            List<ESECCION> lstSE = objDLSE.GetSeccionesInstrumento(objINSTRUMENTO.CODINSTRUMENTO);
            if (lstSE.Count > 0)
            {
                objINSTRUMENTO.SECCIONES = lstSE;
            }
            else
            {
                ESECCION objSE = new ESECCION();
                objINSTRUMENTO.SECCIONES.Add(objSE);
            }
            DLCURSOList objDLCU = new DLCURSOList();
            List<ECURSO> lstCU = objDLCU.GetCursosByInstrumento(objINSTRUMENTO.CODINSTRUMENTO);
            if (lstCU.Count > 0)
            {
                objINSTRUMENTO.CURSOS = lstCU;
            }
            else
            {
                ECURSO objCU = new ECURSO();
                objINSTRUMENTO.CURSOS.Add(objCU);
            }
        }

        #endregion

	}
}
