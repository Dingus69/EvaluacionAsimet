
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
	/// BFPREGUNTAEMPLEADO.
	/// </summary>
	public class BFPREGUNTAEMPLEADO
	{
		private DLPREGUNTAEMPLEADO _objDAL;
		private DLPREGUNTAEMPLEADOList _objDALList;
		
		public BFPREGUNTAEMPLEADO()
		{
			_objDAL = new DLPREGUNTAEMPLEADO();
			_objDALList = new DLPREGUNTAEMPLEADOList();
		}

		public EPREGUNTAEMPLEADO GetPREGUNTAEMPLEADO()
		{
			return new EPREGUNTAEMPLEADO();
		}

		public EPREGUNTAEMPLEADO GetPREGUNTAEMPLEADO(long id)
		{
            return new EPREGUNTAEMPLEADO(id);
		}

		public bool Save(EPREGUNTAEMPLEADO objPREGUNTAEMPLEADO)
		{
			try
			{
				objPREGUNTAEMPLEADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EPREGUNTAEMPLEADO> GetPREGUNTAEMPLEADOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPREGUNTAEMPLEADO objPREGUNTAEMPLEADO)
		{
			try
			{
                _objDAL.Delete(objPREGUNTAEMPLEADO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPREGUNTAEMPLEADO objPREGUNTAEMPLEADO)
        {
            try
            {
                _objDAL.Update(objPREGUNTAEMPLEADO);
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

