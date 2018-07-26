
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
	/// BFSECCIONINSTRUMENTOEMPLEADO.
	/// </summary>
	public class BFSECCIONINSTRUMENTOEMPLEADO
	{
		private DLSECCIONINSTRUMENTOEMPLEADO _objDAL;
		private DLSECCIONINSTRUMENTOEMPLEADOList _objDALList;
		
		public BFSECCIONINSTRUMENTOEMPLEADO()
		{
			_objDAL = new DLSECCIONINSTRUMENTOEMPLEADO();
			_objDALList = new DLSECCIONINSTRUMENTOEMPLEADOList();
		}

		public ESECCIONINSTRUMENTOEMPLEADO GetSECCIONINSTRUMENTOEMPLEADO()
		{
			return new ESECCIONINSTRUMENTOEMPLEADO();
		}

		public ESECCIONINSTRUMENTOEMPLEADO GetSECCIONINSTRUMENTOEMPLEADO(long id)
		{
            return new ESECCIONINSTRUMENTOEMPLEADO(id);
		}

		public bool Save(ESECCIONINSTRUMENTOEMPLEADO objSECCIONINSTRUMENTOEMPLEADO)
		{
			try
			{
				objSECCIONINSTRUMENTOEMPLEADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ESECCIONINSTRUMENTOEMPLEADO> GetSECCIONINSTRUMENTOEMPLEADOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ESECCIONINSTRUMENTOEMPLEADO objSECCIONINSTRUMENTOEMPLEADO)
		{
			try
			{
                _objDAL.Delete(objSECCIONINSTRUMENTOEMPLEADO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ESECCIONINSTRUMENTOEMPLEADO objSECCIONINSTRUMENTOEMPLEADO)
        {
            try
            {
                _objDAL.Update(objSECCIONINSTRUMENTOEMPLEADO);
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

