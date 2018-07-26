
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
	/// BFPERFILUSUARIO.
	/// </summary>
	public class BFPERFILUSUARIO
	{
		private DLPERFILUSUARIO _objDAL;
		private DLPERFILUSUARIOList _objDALList;
		
		public BFPERFILUSUARIO()
		{
			_objDAL = new DLPERFILUSUARIO();
			_objDALList = new DLPERFILUSUARIOList();
		}

		public EPERFILUSUARIO GetPERFILUSUARIO()
		{
			return new EPERFILUSUARIO();
		}

		public EPERFILUSUARIO GetPERFILUSUARIO(long id)
		{
            return new EPERFILUSUARIO(id);
		}

		public bool Save(EPERFILUSUARIO objPERFILUSUARIO)
		{
			try
			{
				objPERFILUSUARIO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EPERFILUSUARIO> GetPERFILUSUARIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPERFILUSUARIO objPERFILUSUARIO)
		{
			try
			{
                _objDAL.Delete(objPERFILUSUARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPERFILUSUARIO objPERFILUSUARIO)
        {
            try
            {
                _objDAL.Update(objPERFILUSUARIO);
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

