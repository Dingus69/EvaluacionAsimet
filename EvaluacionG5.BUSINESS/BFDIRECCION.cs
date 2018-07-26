
using System;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.BUSINESS
{
	/// <summary>
	/// BFDIRECCION.
	/// </summary>
	public class BFDIRECCION
	{
		private DLDIRECCION _objDAL;
		private DLDIRECCIONList _objDALList;
		
		public BFDIRECCION()
		{
			_objDAL = new DLDIRECCION();
			_objDALList = new DLDIRECCIONList();
		}

		public EDIRECCION GetDIRECCION()
		{
			return new EDIRECCION();
		}

		public EDIRECCION GetDIRECCION(long id)
		{
            return new EDIRECCION(id);
		}

		public bool Save(EDIRECCION objDIRECCION)
		{
			try
			{
				objDIRECCION.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EDIRECCION> GetDIRECCIONAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EDIRECCION> GetDIRECCIONAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(EDIRECCION objDIRECCION)
		{
			try
			{
                _objDAL.Delete(objDIRECCION);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EDIRECCION objDIRECCION)
        {
            try
            {
                _objDAL.Update(objDIRECCION);
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

