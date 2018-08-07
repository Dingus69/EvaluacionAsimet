
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
	/// BFOBJETIVOPROXIMO.
	/// </summary>
	public class BFOBJETIVOPROXIMO
	{
		private DLOBJETIVOPROXIMO _objDAL;
		private DLOBJETIVOPROXIMOList _objDALList;
		
		public BFOBJETIVOPROXIMO()
		{
			_objDAL = new DLOBJETIVOPROXIMO();
			_objDALList = new DLOBJETIVOPROXIMOList();
		}

		public EOBJETIVOPROXIMO GetOBJETIVOPROXIMO()
		{
			return new EOBJETIVOPROXIMO();
		}

		public EOBJETIVOPROXIMO GetOBJETIVOPROXIMO(long id)
		{
            return new EOBJETIVOPROXIMO(id);
		}

		public bool Save(EOBJETIVOPROXIMO objOBJETIVOPROXIMO)
		{
			try
			{
				objOBJETIVOPROXIMO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EOBJETIVOPROXIMO> GetOBJETIVOPROXIMOAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EOBJETIVOPROXIMO> GetObjetivosProximos(Decimal CodInstrumentoEmpleado)
        {
            return _objDALList.GetObjetivosProximos(CodInstrumentoEmpleado);
        }

        public List<EOBJETIVOPROXIMO> GetObjetivosActuales(Decimal CodInstrumentoEmpleado)
        {
            return _objDALList.GetObjetivosProximos(CodInstrumentoEmpleado);
        }

        public bool Delete(EOBJETIVOPROXIMO objOBJETIVOPROXIMO)
		{
			try
			{
                _objDAL.Delete(objOBJETIVOPROXIMO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EOBJETIVOPROXIMO objOBJETIVOPROXIMO)
        {
            try
            {
                _objDAL.Update(objOBJETIVOPROXIMO);
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

