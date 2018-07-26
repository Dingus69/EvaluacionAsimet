
using System;
using System.Collections.Generic;
using System.Data;
using EvaluacionG5.COMMON;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.BUSINESS
{
	/// <summary>
	/// BFPREGUNTASECCIONEMPLEADO.
	/// </summary>
	public class BFPREGUNTASECCIONEMPLEADO
	{
		private DLPREGUNTASECCIONEMPLEADO _objDAL;
		private DLPREGUNTASECCIONEMPLEADOList _objDALList;
		
		public BFPREGUNTASECCIONEMPLEADO()
		{
			_objDAL = new DLPREGUNTASECCIONEMPLEADO();
			_objDALList = new DLPREGUNTASECCIONEMPLEADOList();
		}

		public EPREGUNTASECCIONEMPLEADO GetPREGUNTASECCIONEMPLEADO()
		{
			return new EPREGUNTASECCIONEMPLEADO();
		}

		public EPREGUNTASECCIONEMPLEADO GetPREGUNTASECCIONEMPLEADO(long id)
		{
            return new EPREGUNTASECCIONEMPLEADO(id);
		}

		public bool Save(EPREGUNTASECCIONEMPLEADO objPREGUNTASECCIONEMPLEADO)
		{
			try
			{
				objPREGUNTASECCIONEMPLEADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
        }

        public bool Evaluar(List<EPREGUNTASECCIONEMPLEADO> lst, Int16 CodEstado, Decimal CodInstrumentoEmpleado, Int64 RutUsuario, string Modo)
        {
            try
            {
                _objDALList.Evaluar(lst, CodEstado, CodInstrumentoEmpleado, RutUsuario, Modo);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool Evaluar(EPREGUNTASECCIONEMPLEADO objPREGUNTASECCIONEMPLEADO, Int64 RutUsuario, string Modo)
        {
            try
            {
                objPREGUNTASECCIONEMPLEADO.Save();
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<EPREGUNTASECCIONEMPLEADO> GetPREGUNTASECCIONEMPLEADOAll()
		{
			return _objDALList.SelectAll();
		}

        public void LimpiarPreguntaSeccionEmp(Decimal CodSeccionInstrumento)
        {
            _objDALList.LimpiarPreguntaSeccionEmp(CodSeccionInstrumento);
        }

        public bool Delete(EPREGUNTASECCIONEMPLEADO objPREGUNTASECCIONEMPLEADO)
		{
			try
			{
                _objDAL.Delete(objPREGUNTASECCIONEMPLEADO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPREGUNTASECCIONEMPLEADO objPREGUNTASECCIONEMPLEADO)
        {
            try
            {
                _objDAL.Update(objPREGUNTASECCIONEMPLEADO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

	}
}

