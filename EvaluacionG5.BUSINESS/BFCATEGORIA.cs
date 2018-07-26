
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
	/// BFCATEGORIA.
	/// </summary>
	public class BFCATEGORIA
	{
		private DLCATEGORIA _objDAL;
		private DLCATEGORIAList _objDALList;
		
		public BFCATEGORIA()
		{
			_objDAL = new DLCATEGORIA();
			_objDALList = new DLCATEGORIAList();
		}

		public ECATEGORIA GetCATEGORIA()
		{
			return new ECATEGORIA();
		}

		public ECATEGORIA GetCATEGORIA(long id)
		{
            return new ECATEGORIA(id);
		}

		public bool Save(ECATEGORIA objCATEGORIA)
		{
			try
			{
				objCATEGORIA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECATEGORIA> GetCATEGORIAAll()
		{
			return _objDALList.SelectAll();
        }

        public List<ECATEGORIA> GetCategoriasPorEscala(Decimal CodEscala)
        {
            return _objDALList.GetCategoriasPorEscala(CodEscala);
        }

        public bool Delete(ECATEGORIA objCATEGORIA)
		{
			try
			{
                _objDAL.Delete(objCATEGORIA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECATEGORIA objCATEGORIA)
        {
            try
            {
                _objDAL.Update(objCATEGORIA);
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

