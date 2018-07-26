
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCURSO.
	/// </summary>
	public class DLCURSO : DLBase
	{
		public DLCURSO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CURSO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CURSO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CURSO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CURSO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CURSO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECURSO objCURSO = obj as ECURSO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSO.CODCURSO;
            prms[0].ParameterName = "@COD_CURSO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(10);
            ECURSO objCURSO = obj as ECURSO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCURSO.CODCURSO;
            prms[0].ParameterName = "@COD_CURSO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCURSO.CODMODALIDAD;
            prms[1].ParameterName = "@COD_MODALIDAD";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCURSO.CODAREACURSO;
            prms[2].ParameterName = "@COD_AREA_CURSO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objCURSO.NOMBRECURSO;
            prms[3].ParameterName = "@NOMBRE_CURSO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objCURSO.PROVEEDOR;
            prms[4].ParameterName = "@PROVEEDOR";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objCURSO.DURACION;
            prms[5].ParameterName = "@DURACION";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objCURSO.CODIGOSENCE;
            prms[6].ParameterName = "@CODIGO_SENCE";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objCURSO.LUGAREJECUCION;
            prms[7].ParameterName = "@LUGAR_EJECUCION";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objCURSO.COSTOPARTICIPANTE;
            prms[8].ParameterName = "@COSTO_PARTICIPANTE";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objCURSO.MAXPARTICIPANTES;
            prms[9].ParameterName = "@MAX_PARTICIPANTES";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(10);
            ECURSO objCURSO = obj as ECURSO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCURSO.CODCURSO;
            prms[0].ParameterName = "@COD_CURSO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCURSO.CODMODALIDAD;
            prms[1].ParameterName = "@COD_MODALIDAD";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCURSO.CODAREACURSO;
            prms[2].ParameterName = "@COD_AREA_CURSO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objCURSO.NOMBRECURSO;
            prms[3].ParameterName = "@NOMBRE_CURSO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objCURSO.PROVEEDOR;
            prms[4].ParameterName = "@PROVEEDOR";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objCURSO.DURACION;
            prms[5].ParameterName = "@DURACION";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objCURSO.CODIGOSENCE;
            prms[6].ParameterName = "@CODIGO_SENCE";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objCURSO.LUGAREJECUCION;
            prms[7].ParameterName = "@LUGAR_EJECUCION";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objCURSO.COSTOPARTICIPANTE;
            prms[8].ParameterName = "@COSTO_PARTICIPANTE";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objCURSO.MAXPARTICIPANTES;
            prms[9].ParameterName = "@MAX_PARTICIPANTES";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECURSO objRoot = obj as ECURSO;

            objRoot.CODCURSO = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECURSO objCURSO = obj as ECURSO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCURSO.CODCURSO = Utiles.ConvertToString(dr["COD_CURSO"]);
            
            objCURSO.CODMODALIDAD = Utiles.ConvertToInt16(dr["COD_MODALIDAD"]);

            objCURSO.NOMMODALIDAD = Utiles.ConvertToString(dr["NOM_MODALIDAD"]);

            objCURSO.CODAREACURSO = Utiles.ConvertToDecimal(dr["COD_AREA_CURSO"]);

            objCURSO.NOMAREACURSO = Utiles.ConvertToString(dr["NOM_AREA_CURSO"]);

            objCURSO.NOMBRECURSO = Utiles.ConvertToString(dr["NOMBRE_CURSO"]);
            
            objCURSO.PROVEEDOR = Utiles.ConvertToString(dr["PROVEEDOR"]);
            
            objCURSO.DURACION = Utiles.ConvertToInt32(dr["DURACION"]);
            
            objCURSO.CODIGOSENCE = Utiles.ConvertToString(dr["CODIGO_SENCE"]);
            
            objCURSO.LUGAREJECUCION = Utiles.ConvertToString(dr["LUGAR_EJECUCION"]);
            
            objCURSO.COSTOPARTICIPANTE = Utiles.ConvertToInt64(dr["COSTO_PARTICIPANTE"]);
            
            objCURSO.MAXPARTICIPANTES = Utiles.ConvertToInt32(dr["MAX_PARTICIPANTES"]);
            
        }

        #endregion

	}
}
