
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
	/// BFCURSOINSTRUMENTOEMPLEADO.
	/// </summary>
	public class BFCURSOINSTRUMENTOEMPLEADO
	{
		private DLCURSOINSTRUMENTOEMPLEADO _objDAL;
		private DLCURSOINSTRUMENTOEMPLEADOList _objDALList;
		
		public BFCURSOINSTRUMENTOEMPLEADO()
		{
			_objDAL = new DLCURSOINSTRUMENTOEMPLEADO();
			_objDALList = new DLCURSOINSTRUMENTOEMPLEADOList();
		}

		public ECURSOINSTRUMENTOEMPLEADO GetCURSOINSTRUMENTOEMPLEADO()
		{
			return new ECURSOINSTRUMENTOEMPLEADO();
		}

		public ECURSOINSTRUMENTOEMPLEADO GetCURSOINSTRUMENTOEMPLEADO(long id)
		{
            return new ECURSOINSTRUMENTOEMPLEADO(id);
		}

		public bool Save(ECURSOINSTRUMENTOEMPLEADO objCURSOINSTRUMENTOEMPLEADO)
		{
			try
			{
				objCURSOINSTRUMENTOEMPLEADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECURSOINSTRUMENTOEMPLEADO> GetCURSOINSTRUMENTOEMPLEADOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ECURSOINSTRUMENTOEMPLEADO objCURSOINSTRUMENTOEMPLEADO)
		{
			try
			{
                _objDAL.Delete(objCURSOINSTRUMENTOEMPLEADO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECURSOINSTRUMENTOEMPLEADO objCURSOINSTRUMENTOEMPLEADO)
        {
            try
            {
                _objDAL.Update(objCURSOINSTRUMENTOEMPLEADO);
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

