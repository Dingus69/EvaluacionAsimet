
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
	/// BFGERENCIA.
	/// </summary>
	public class BFGERENCIA
	{
		private DLGERENCIA _objDAL;
		private DLGERENCIAList _objDALList;
		
		public BFGERENCIA()
		{
			_objDAL = new DLGERENCIA();
			_objDALList = new DLGERENCIAList();
		}

		public EGERENCIA GetGERENCIA()
		{
			return new EGERENCIA();
		}

		public EGERENCIA GetGERENCIA(long id)
		{
            return new EGERENCIA(id);
        }

        public bool Save(EGERENCIA objGERENCIA)
		{
			try
			{
				objGERENCIA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EGERENCIA> GetGERENCIAAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(EGERENCIA objGERENCIA)
		{
			try
			{
                _objDAL.Delete(objGERENCIA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EGERENCIA objGERENCIA)
        {
            try
            {
                _objDAL.Update(objGERENCIA);
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

