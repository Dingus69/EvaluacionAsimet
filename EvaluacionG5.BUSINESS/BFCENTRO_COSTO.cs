
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
	/// BFCENTROCOSTO.
	/// </summary>
	public class BFCENTROCOSTO
	{
		private DLCENTROCOSTO _objDAL;
		private DLCENTROCOSTOList _objDALList;
		
		public BFCENTROCOSTO()
		{
			_objDAL = new DLCENTROCOSTO();
			_objDALList = new DLCENTROCOSTOList();
		}

		public ECENTROCOSTO GetCENTROCOSTO()
		{
			return new ECENTROCOSTO();
		}

		public ECENTROCOSTO GetCENTROCOSTO(long id)
		{
            return new ECENTROCOSTO(id);
		}

		public bool Save(ECENTROCOSTO objCENTROCOSTO)
		{
			try
			{
				objCENTROCOSTO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECENTROCOSTO> GetCENTROCOSTOAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(ECENTROCOSTO objCENTROCOSTO)
		{
			try
			{
                _objDAL.Delete(objCENTROCOSTO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECENTROCOSTO objCENTROCOSTO)
        {
            try
            {
                _objDAL.Update(objCENTROCOSTO);
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

