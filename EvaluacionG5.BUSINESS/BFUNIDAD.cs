
using System;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.BUSINESS
{
	/// <summary>
	/// BFUNIDAD.
	/// </summary>
	public class BFUNIDAD
	{
		private DLUNIDAD _objDAL;
		private DLUNIDADList _objDALList;
		
		public BFUNIDAD()
		{
			_objDAL = new DLUNIDAD();
			_objDALList = new DLUNIDADList();
		}

		public EUNIDAD GetUNIDAD()
		{
			return new EUNIDAD();
		}

		public EUNIDAD GetUNIDAD(long id)
		{
            return new EUNIDAD(id);
		}

		public bool Save(EUNIDAD objUNIDAD)
		{
			try
			{
				objUNIDAD.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EUNIDAD> GetUNIDADAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EUNIDAD> GetUNIDADAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(EUNIDAD objUNIDAD)
		{
			try
			{
                _objDAL.Delete(objUNIDAD);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EUNIDAD objUNIDAD)
        {
            try
            {
                _objDAL.Update(objUNIDAD);
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

