
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
	/// BFTIPOEVALUACION.
	/// </summary>
	public class BFTIPOEVALUACION
	{
		private DLTIPOEVALUACION _objDAL;
		private DLTIPOEVALUACIONList _objDALList;
		
		public BFTIPOEVALUACION()
		{
			_objDAL = new DLTIPOEVALUACION();
			_objDALList = new DLTIPOEVALUACIONList();
		}

		public ETIPOEVALUACION GetTIPOEVALUACION()
		{
			return new ETIPOEVALUACION();
		}

		public ETIPOEVALUACION GetTIPOEVALUACION(long id)
		{
            return new ETIPOEVALUACION(id);
		}

		public bool Save(ETIPOEVALUACION objTIPOEVALUACION)
		{
			try
			{
				objTIPOEVALUACION.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ETIPOEVALUACION> GetTIPOEVALUACIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETIPOEVALUACION objTIPOEVALUACION)
		{
			try
			{
                _objDAL.Delete(objTIPOEVALUACION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ETIPOEVALUACION objTIPOEVALUACION)
        {
            try
            {
                _objDAL.Update(objTIPOEVALUACION);
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

