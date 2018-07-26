
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
	/// BFACCION.
	/// </summary>
	public class BFACCION
	{
		private DLACCION _objDAL;
		private DLACCIONList _objDALList;
		
		public BFACCION()
		{
			_objDAL = new DLACCION();
			_objDALList = new DLACCIONList();
		}

		public EACCION GetACCION()
		{
			return new EACCION();
		}

		public EACCION GetACCION(long id)
		{
            return new EACCION(id);
		}

		public bool Save(EACCION objACCION)
		{
			try
			{
				objACCION.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EACCION> GetACCIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EACCION objACCION)
		{
			try
			{
                _objDAL.Delete(objACCION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EACCION objACCION)
        {
            try
            {
                _objDAL.Update(objACCION);
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

