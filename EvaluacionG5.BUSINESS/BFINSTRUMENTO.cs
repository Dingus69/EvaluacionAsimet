
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
	/// BFINSTRUMENTO.
	/// </summary>
	public class BFINSTRUMENTO
	{
		private DLINSTRUMENTO _objDAL;
		private DLINSTRUMENTOList _objDALList;
		
		public BFINSTRUMENTO()
		{
			_objDAL = new DLINSTRUMENTO();
			_objDALList = new DLINSTRUMENTOList();
		}

		public EINSTRUMENTO GetINSTRUMENTO()
		{
			return new EINSTRUMENTO();
		}

		public EINSTRUMENTO GetINSTRUMENTO(long id)
		{
            return new EINSTRUMENTO(id);
		}

		public bool Save(EINSTRUMENTO objINSTRUMENTO)
		{
			try
            {
                if (objINSTRUMENTO.CODINSTRUMENTO == 0)
                {
                    objINSTRUMENTO.IsPersisted = false;
                }
                else
                {
                    objINSTRUMENTO.IsPersisted = true;
                }
                objINSTRUMENTO.Save();
                _objDALList.LimpiarInstrumento(objINSTRUMENTO.CODINSTRUMENTO);
                foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                {
                    objSE.CODINSTRUMENTO = objINSTRUMENTO.CODINSTRUMENTO;
                    objSE.Save();
                    
                    foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                    {
                        objPR.Save();
                        EPREGUNTASECCION objPS = new EPREGUNTASECCION();
                        objPS.CODPREGUNTA = objPR.CODPREGUNTA;
                        objPS.CODSECCION = objSE.CODSECCION;
                        objPS.PONDERACION = objPR.PONDERACION;
                        objPS.IsPersisted = false;
                        objPS.Save();
                    }
                }
                BFINSTRUMENTOCURSO objBFIC = new BFINSTRUMENTOCURSO();
                foreach (ECURSO objCU in objINSTRUMENTO.CURSOS)
                {
                    EINSTRUMENTOCURSO objIE = new EINSTRUMENTOCURSO();
                    objIE.CODINSTRUMENTO = objINSTRUMENTO.CODINSTRUMENTO;
                    objIE.CODCURSO = objCU.CODCURSO;
                    objBFIC.Save(objIE); 
                }
                return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		//public List<EINSTRUMENTO> GetINSTRUMENTOAll()
		//{
		//	return _objDALList.SelectAll();
  //      }

        public List<EINSTRUMENTO> GetINSTRUMENTOAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public EINSTRUMENTO GetINSTRUMENTOEMPRESA(Int64 CodInstrumento, Int64 RutEmpresa)
        {
            return _objDALList.GetINSTRUMENTOEMPRESA(CodInstrumento, RutEmpresa);
        }

        public bool Delete(EINSTRUMENTO objINSTRUMENTO)
		{
			try
			{
                _objDAL.Delete(objINSTRUMENTO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EINSTRUMENTO objINSTRUMENTO)
        {
            try
            {
                _objDAL.Update(objINSTRUMENTO);
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

