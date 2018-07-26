
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
	/// BFRANGO.
	/// </summary>
	public class BFRANGO
	{
		private DLRANGO _objDAL;
		private DLRANGOList _objDALList;
		
		public BFRANGO()
		{
			_objDAL = new DLRANGO();
			_objDALList = new DLRANGOList();
		}

		public ERANGO GetRANGO()
		{
			return new ERANGO();
		}

		public ERANGO GetRANGO(long id)
		{
            return new ERANGO(id);
		}

		public bool Save(ERANGO objRANGO)
		{
			try
			{
				objRANGO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

		public List<ERANGO> GetRANGOAll()
		{
			return _objDALList.SelectAll();
        }

        public List<ERANGO> GetRangosPorEscala(Decimal CodEscala)
        {
            return _objDALList.GetRangosPorEscala(CodEscala);
        }

        public bool Delete(ERANGO objRANGO)
		{
			try
			{
                _objDAL.Delete(objRANGO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ERANGO objRANGO)
        {
            try
            {
                _objDAL.Update(objRANGO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public bool DeletePorEscala(Decimal CodEscala)
        {
            try
            {
                _objDALList.DeletePorEscala(CodEscala);
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

