
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
	/// BFCATEGORIAESCALA.
	/// </summary>
	public class BFCATEGORIAESCALA
	{
		private DLCATEGORIAESCALA _objDAL;
		private DLCATEGORIAESCALAList _objDALList;
		
		public BFCATEGORIAESCALA()
		{
			_objDAL = new DLCATEGORIAESCALA();
			_objDALList = new DLCATEGORIAESCALAList();
		}

		public ECATEGORIAESCALA GetCATEGORIAESCALA()
		{
			return new ECATEGORIAESCALA();
		}

		public ECATEGORIAESCALA GetCATEGORIAESCALA(long id)
		{
            return new ECATEGORIAESCALA(id);
		}

		public bool Save(ECATEGORIAESCALA objCATEGORIAESCALA)
		{
			try
			{
				objCATEGORIAESCALA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECATEGORIAESCALA> GetCATEGORIAESCALAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ECATEGORIAESCALA objCATEGORIAESCALA)
		{
			try
			{
                _objDAL.Delete(objCATEGORIAESCALA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECATEGORIAESCALA objCATEGORIAESCALA)
        {
            try
            {
                _objDAL.Update(objCATEGORIAESCALA);
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

