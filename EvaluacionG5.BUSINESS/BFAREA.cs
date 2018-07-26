
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
	/// BFAREA.
	/// </summary>
	public class BFAREA
	{
		private DLAREA _objDAL;
		private DLAREAList _objDALList;
		
		public BFAREA()
		{
			_objDAL = new DLAREA();
			_objDALList = new DLAREAList();
		}

		public EAREA GetAREA()
		{
			return new EAREA();
		}

		public EAREA GetAREA(long id)
		{
            return new EAREA(id);
		}

		public bool Save(EAREA objAREA)
		{
			try
			{
				objAREA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EAREA> GetAREAAll(Int64 RutEmpresa)
		{
			return _objDALList.SelectAll(RutEmpresa);
		}

        public bool Delete(EAREA objAREA)
		{
			try
			{
                _objDAL.Delete(objAREA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EAREA objAREA)
        {
            try
            {
                _objDAL.Update(objAREA);
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

