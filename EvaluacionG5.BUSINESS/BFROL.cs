
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
	/// BFROL.
	/// </summary>
	public class BFROL
	{
		private DLROL _objDAL;
		private DLROLList _objDALList;
		
		public BFROL()
		{
			_objDAL = new DLROL();
			_objDALList = new DLROLList();
		}

		public EROL GetROL()
		{
			return new EROL();
		}

		public EROL GetROL(long id)
		{
            return new EROL(id);
		}

		public bool Save(EROL objROL)
		{
			try
			{
				objROL.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EROL> GetROLAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(EROL objROL)
		{
			try
			{
                _objDAL.Delete(objROL);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EROL objROL)
        {
            try
            {
                _objDAL.Update(objROL);
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

