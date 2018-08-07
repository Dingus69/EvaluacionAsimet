
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
	/// BFOBJETIVOINSTRUMENTOEMPLEADO.
	/// </summary>
	public class BFOBJETIVOINSTRUMENTOEMPLEADO
	{
		private DLOBJETIVOINSTRUMENTOEMPLEADO _objDAL;
		private DLOBJETIVOINSTRUMENTOEMPLEADOList _objDALList;
		
		public BFOBJETIVOINSTRUMENTOEMPLEADO()
		{
			_objDAL = new DLOBJETIVOINSTRUMENTOEMPLEADO();
			_objDALList = new DLOBJETIVOINSTRUMENTOEMPLEADOList();
		}

		public EOBJETIVOINSTRUMENTOEMPLEADO GetOBJETIVOINSTRUMENTOEMPLEADO()
		{
			return new EOBJETIVOINSTRUMENTOEMPLEADO();
		}

		public EOBJETIVOINSTRUMENTOEMPLEADO GetOBJETIVOINSTRUMENTOEMPLEADO(long id)
		{
            return new EOBJETIVOINSTRUMENTOEMPLEADO(id);
		}

		public bool Save(EOBJETIVOINSTRUMENTOEMPLEADO objOBJETIVOINSTRUMENTOEMPLEADO)
		{
			try
			{
				objOBJETIVOINSTRUMENTOEMPLEADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EOBJETIVOINSTRUMENTOEMPLEADO> GetOBJETIVOINSTRUMENTOEMPLEADOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EOBJETIVOINSTRUMENTOEMPLEADO objOBJETIVOINSTRUMENTOEMPLEADO)
		{
			try
			{
                _objDAL.Delete(objOBJETIVOINSTRUMENTOEMPLEADO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EOBJETIVOINSTRUMENTOEMPLEADO objOBJETIVOINSTRUMENTOEMPLEADO)
        {
            try
            {
                _objDAL.Update(objOBJETIVOINSTRUMENTOEMPLEADO);
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

