
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
	/// BFPREGUNTASECCION.
	/// </summary>
	public class BFPREGUNTASECCION
	{
		private DLPREGUNTASECCION _objDAL;
		private DLPREGUNTASECCIONList _objDALList;
		
		public BFPREGUNTASECCION()
		{
			_objDAL = new DLPREGUNTASECCION();
			_objDALList = new DLPREGUNTASECCIONList();
		}

		public EPREGUNTASECCION GetPREGUNTASECCION()
		{
			return new EPREGUNTASECCION();
		}

		public EPREGUNTASECCION GetPREGUNTASECCION(long id)
		{
            return new EPREGUNTASECCION(id);
		}

		public bool Save(EPREGUNTASECCION objPREGUNTASECCION)
		{
			try
			{
				objPREGUNTASECCION.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EPREGUNTASECCION> GetPREGUNTASECCIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPREGUNTASECCION objPREGUNTASECCION)
		{
			try
			{
                _objDAL.Delete(objPREGUNTASECCION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPREGUNTASECCION objPREGUNTASECCION)
        {
            try
            {
                _objDAL.Update(objPREGUNTASECCION);
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

