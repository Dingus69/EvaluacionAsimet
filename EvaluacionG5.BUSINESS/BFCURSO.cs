
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
	/// BFCURSO.
	/// </summary>
	public class BFCURSO
	{
		private DLCURSO _objDAL;
		private DLCURSOList _objDALList;
		
		public BFCURSO()
		{
			_objDAL = new DLCURSO();
			_objDALList = new DLCURSOList();
		}

		public ECURSO GetCURSO()
		{
			return new ECURSO();
		}

		public ECURSO GetCURSO(long id)
		{
            return new ECURSO(id);
		}

		public bool Save(ECURSO objCURSO)
		{
			try
			{
				objCURSO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECURSO> GetCURSOAll()
		{
			return _objDALList.SelectAll();
        }

        public List<ECURSO> GetCursosByNombreAndArea(string NombreCurso, Decimal CodArea)
        {
            return _objDALList.GetCursosByNombreAndArea(NombreCurso, CodArea);
        }

        public DataTable GetCursosDisponiblesArea(Decimal CodInstrumento, Decimal CodArea)
        {
            return _objDALList.GetCursosDisponiblesArea(CodInstrumento, CodArea);
        }

        public DataTable GetCursosAsignadosArea(Decimal CodInstrumento, Decimal CodArea)
        {
            return _objDALList.GetCursosAsignadosArea(CodInstrumento, CodArea);
        }

        public bool Delete(ECURSO objCURSO)
		{
			try
			{
                _objDAL.Delete(objCURSO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECURSO objCURSO)
        {
            try
            {
                _objDAL.Update(objCURSO);
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

