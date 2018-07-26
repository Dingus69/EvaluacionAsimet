
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
	/// BFBITACORA.
	/// </summary>
	public class BFBITACORA
	{
		private DLBITACORA _objDAL;
		private DLBITACORAList _objDALList;
		
		public BFBITACORA()
		{
			_objDAL = new DLBITACORA();
			_objDALList = new DLBITACORAList();
		}

		public EBITACORA GetBITACORA()
		{
			return new EBITACORA();
		}

		public EBITACORA GetBITACORA(long id)
		{
            return new EBITACORA(id);
		}

		public bool Save(EBITACORA objBITACORA)
		{
			try
			{
				objBITACORA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EBITACORA> GetBITACORAAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EBITACORA objBITACORA)
		{
			try
			{
                _objDAL.Delete(objBITACORA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EBITACORA objBITACORA)
        {
            try
            {
                _objDAL.Update(objBITACORA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }


        public DataTable GetBitacoraEmpleado(Int64 RutEmpleado)
        {
            return _objDALList.GetBitacoraEmpleado(RutEmpleado);
        }

        public DataTable GetBitacoraInstrumento(Decimal CodInstrumento)
        {
            return _objDALList.GetBitacoraInstrumento(CodInstrumento);
        }

        public DataTable GetBitacoraInstrumentoEmpleado(Decimal CodInstrumentoEmpleado)
        {
            return _objDALList.GetBitacoraInstrumentoEmpleado(CodInstrumentoEmpleado);
        }

    }
}

