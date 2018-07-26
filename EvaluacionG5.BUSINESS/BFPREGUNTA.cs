
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
	/// BFPREGUNTA.
	/// </summary>
	public class BFPREGUNTA
	{
		private DLPREGUNTA _objDAL;
		private DLPREGUNTAList _objDALList;
		
		public BFPREGUNTA()
		{
			_objDAL = new DLPREGUNTA();
			_objDALList = new DLPREGUNTAList();
		}

		public EPREGUNTA GetPREGUNTA()
		{
			return new EPREGUNTA();
		}

		public EPREGUNTA GetPREGUNTA(long id)
		{
            return new EPREGUNTA(id);
		}

		public bool Save(EPREGUNTA objPREGUNTA)
		{
			try
			{
				objPREGUNTA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EPREGUNTA> GetPREGUNTAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPREGUNTA objPREGUNTA)
		{
			try
			{
                _objDAL.Delete(objPREGUNTA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPREGUNTA objPREGUNTA)
        {
            try
            {
                _objDAL.Update(objPREGUNTA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }
        public List<EPREGUNTA> GetPreguntasSeccion(Decimal CodSeccion)
        {
            return _objDALList.GetPreguntasSeccion(CodSeccion);
        }

    }
}

