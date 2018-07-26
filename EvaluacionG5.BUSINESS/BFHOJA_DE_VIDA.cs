
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
	/// BFHOJADEVIDA.
	/// </summary>
	public class BFHOJADEVIDA
	{
		private DLHOJADEVIDA _objDAL;
		private DLHOJADEVIDAList _objDALList;
		
		public BFHOJADEVIDA()
		{
			_objDAL = new DLHOJADEVIDA();
			_objDALList = new DLHOJADEVIDAList();
		}

		public EHOJADEVIDA GetHOJADEVIDA()
		{
			return new EHOJADEVIDA();
		}

		public EHOJADEVIDA GetHOJADEVIDA(long id)
		{
            return new EHOJADEVIDA(id);
		}

		public bool Save(EHOJADEVIDA objHOJADEVIDA)
		{
			try
			{
				objHOJADEVIDA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EHOJADEVIDA> GetHOJADEVIDAAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EHOJADEVIDA> GetHOJADEVIDABYRUTEMPLEADO(Int64 RutEmpleado)
        {
            return _objDALList.GetHOJADEVIDABYRUTEMPLEADO(RutEmpleado);
        }

        public bool Delete(EHOJADEVIDA objHOJADEVIDA)
		{
			try
			{
                _objDAL.Delete(objHOJADEVIDA);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EHOJADEVIDA objHOJADEVIDA)
        {
            try
            {
                _objDAL.Update(objHOJADEVIDA);
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

