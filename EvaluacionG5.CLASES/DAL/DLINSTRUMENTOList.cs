
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLINSTRUMENTOList.
	/// </summary>
    public class DLINSTRUMENTOList : DLGenericBaseList<EINSTRUMENTO>
	{
		public DLINSTRUMENTOList()
		{
            this._proc_select_all = "proc_select_INSTRUMENTO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EINSTRUMENTO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<EINSTRUMENTO> SelectAll(Int64 RutEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutEmpresa;
            prms[0].ParameterName = "@RUT_EMPRESA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }
        public EINSTRUMENTO GetINSTRUMENTOEMPRESA(Int64 CodInstrumento, Int64 RutEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@COD_INSTRUMENTO";

            prms[1] = db.GetParameter();
            prms[1].Value = RutEmpresa;
            prms[1].ParameterName = "@RUT_EMPRESA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_INSTRUMENTO", prms);

            EINSTRUMENTO objINSTRUMENTO = new EINSTRUMENTO();

            while (dr.Read())
            { 

                objINSTRUMENTO.CODINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO"]);

                objINSTRUMENTO.CODESCALA = Utiles.ConvertToDecimal(dr["CODESCALA"]);

                objINSTRUMENTO.CODGRADO = Utiles.ConvertToInt16(dr["COD_GRADO"]);

                objINSTRUMENTO.NOMBREINSTRUMENTO = Utiles.ConvertToString(dr["NOMBRE_INSTRUMENTO"]);

                objINSTRUMENTO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);

                objINSTRUMENTO.OBSERVACION = Utiles.ConvertToString(dr["OBSERVACION"]);

                objINSTRUMENTO.FLAGAUTOEVALUACION = Utiles.ConvertToBoolean(dr["FLAG_AUTOEVALUACION"]);

                objINSTRUMENTO.FLAG_APELACION = Utiles.ConvertToBoolean(dr["FLAG_APELACION"]);

                objINSTRUMENTO.FLAG_VISACION = Utiles.ConvertToBoolean(dr["FLAG_VISACION"]);

                objINSTRUMENTO.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

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
            }


            return objINSTRUMENTO;
        }

        public void LimpiarInstrumento(Decimal CodInstrumento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@COD_INSTRUMENTO";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_LIMPIAR_INSTRUMENTO", prms);
            
        }

        #endregion
    }
}
