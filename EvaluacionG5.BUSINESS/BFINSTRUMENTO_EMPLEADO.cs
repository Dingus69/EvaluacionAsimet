
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
	/// BFINSTRUMENTOEMPLEADO.
	/// </summary>
	public class BFINSTRUMENTOEMPLEADO
	{
		private DLINSTRUMENTOEMPLEADO _objDAL;
		private DLINSTRUMENTOEMPLEADOList _objDALList;
		
		public BFINSTRUMENTOEMPLEADO()
		{
			_objDAL = new DLINSTRUMENTOEMPLEADO();
			_objDALList = new DLINSTRUMENTOEMPLEADOList();
		}

		public EINSTRUMENTOEMPLEADO GetINSTRUMENTOEMPLEADO()
		{
			return new EINSTRUMENTOEMPLEADO();
		}

		public EINSTRUMENTOEMPLEADO GetINSTRUMENTOEMPLEADO(long id)
		{
            return new EINSTRUMENTOEMPLEADO(id);
		}

		public bool Save(EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO)
		{
			try
			{
				objINSTRUMENTOEMPLEADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
        }

        public bool Asignar(EINSTRUMENTO objINSTRUMENTO, List<EEMPLEADO> lstEM, string Nombre, DateTime Inicio, DateTime Fin, string Direccion)
        {
            try
            {
                EINSTRUMENTOEMPLEADO objIE = new EINSTRUMENTOEMPLEADO();
                objIE.CODINSTRUMENTO = objINSTRUMENTO.CODINSTRUMENTO;
                objIE.NOMINSTRUMENTOEMPLEADO = Nombre;
                objIE.DESCRIPCION = objINSTRUMENTO.DESCRIPCION;
                objIE.OBSERVACION = objINSTRUMENTO.OBSERVACION;
                objIE.INICIOEVALUACION = Inicio;
                objIE.FINEVALUACION = Fin;
                objIE.CODESTADOEVAL = 1;
                switch (Direccion)
                {
                    case "Ascendente":
                        objIE.CODTIPOEVAL = 1;
                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTJEFE;
                            objIE.RUTEVALUADOR = objEM.RUTEMPLEADO;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }
                        break;
                    case "Descendente":
                        objIE.CODTIPOEVAL = 2;
                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTEMPLEADO;
                            objIE.RUTEVALUADOR = objEM.RUTJEFE;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }
                        break;
                    case "Ambas":
                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTJEFE;
                            objIE.RUTEVALUADOR = objEM.RUTEMPLEADO;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.CODTIPOEVAL = 1;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }

                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTEMPLEADO;
                            objIE.RUTEVALUADOR = objEM.RUTJEFE;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.CODTIPOEVAL = 2;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }
                        break;

                    case "Par":
                        objIE.CODTIPOEVAL = 3;
                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTEMPLEADO;
                            objIE.RUTEVALUADOR = objEM.RUTJEFE;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }
                        break;
                }

                BFINSTRUMENTO objBFIN = new BFINSTRUMENTO();
                EINSTRUMENTO objIN = objBFIN.GetINSTRUMENTO(Utiles.ConvertToInt64(objIE.CODINSTRUMENTO));
                if ((objIN.FLAGAUTOEVALUACION) && (Direccion != "Par"))
                {
                    objIE.CODTIPOEVAL = 1;
                    foreach (EEMPLEADO objEM in lstEM)
                    {
                        objIE.RUTEMPLEADO = objEM.RUTEMPLEADO;
                        objIE.RUTEVALUADOR = objEM.RUTEMPLEADO;
                        objIE.RUTVISADOR = objEM.RUTVISADOR;
                        objIE.Save();

                        foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                        {
                            ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                            objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                            objSIE.NOMBRE = objSE.NOMBRE;
                            objSIE.DESCRIPCION = objSE.DESCRIPCION;
                            objSIE.ORDEN = objSE.ORDEN;
                            objSIE.PONDERACION = objSE.PONDERACION;
                            objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                            objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                            objSIE.Save();

                            foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                            {
                                EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                objPRE.TEXTO = objPR.TEXTO;
                                objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                objPRE.ACCION = objPR.ACCION;
                                objPRE.COMPROMISO = objPR.COMPROMISO;
                                objPRE.INDICADOR = objPR.INDICADOR;
                                objPRE.Save();

                                EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                objPSE.PONDERACION = objPR.PONDERACION;
                                objPSE.Save();
                            }
                        }
                        objIE.IsPersisted = false;
                    }
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



        public bool AsignarPorTipo(EINSTRUMENTO objINSTRUMENTO, List<EEMPLEADO> lstEM, string Nombre, DateTime Inicio, DateTime Fin, Int16 Tipo)
        {
            try
            {
                EINSTRUMENTOEMPLEADO objIE = new EINSTRUMENTOEMPLEADO();
                objIE.CODINSTRUMENTO = objINSTRUMENTO.CODINSTRUMENTO;
                objIE.NOMINSTRUMENTOEMPLEADO = Nombre;
                objIE.DESCRIPCION = objINSTRUMENTO.DESCRIPCION;
                objIE.OBSERVACION = objINSTRUMENTO.OBSERVACION;
                objIE.INICIOEVALUACION = Inicio;
                objIE.FINEVALUACION = Fin;
                objIE.CODESTADOEVAL = 1; 
                switch (Tipo)
                {
                    case 1:
                        objIE.CODTIPOEVAL = 1;
                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTEMPLEADO;
                            objIE.RUTEVALUADOR = objEM.RUTJEFE;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }
                        break;
                    case 2:
                        objIE.CODTIPOEVAL = 2;
                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTEMPLEADO;
                            objIE.RUTEVALUADOR = objEM.RUTJEFE;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }
                        break;
                    case 3:
                        objIE.CODTIPOEVAL = 3;
                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTEMPLEADO;
                            objIE.RUTEVALUADOR = objEM.RUTJEFE;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }
                        break;
                    case 4:
                        objIE.CODTIPOEVAL = 4;
                        foreach (EEMPLEADO objEM in lstEM)
                        {
                            objIE.RUTEMPLEADO = objEM.RUTEMPLEADO;
                            objIE.RUTEVALUADOR = objEM.RUTEMPLEADO;
                            objIE.RUTVISADOR = objEM.RUTVISADOR;
                            objIE.Save();

                            foreach (ESECCION objSE in objINSTRUMENTO.SECCIONES)
                            {
                                ESECCIONINSTRUMENTOEMPLEADO objSIE = new ESECCIONINSTRUMENTOEMPLEADO();
                                objSIE.CODINSTRUMENTOEMPLEADO = objIE.CODINSTRUMENTOEMPLEADO;
                                objSIE.NOMBRE = objSE.NOMBRE;
                                objSIE.DESCRIPCION = objSE.DESCRIPCION;
                                objSIE.ORDEN = objSE.ORDEN;
                                objSIE.PONDERACION = objSE.PONDERACION;
                                objSIE.COD_TIPO_SECCION = objSE.CODTIPOSECCION;
                                objSIE.FLAG_AGREGAR_PREGUNTAS = objSE.FLAG_AGREGAR_PREGUNTA;
                                objSIE.Save();

                                foreach (EPREGUNTA objPR in objSE.PREGUNTAS)
                                {
                                    EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                                    objPRE.TEXTO = objPR.TEXTO;
                                    objPRE.DESCRIPCION = objPR.DESCRIPCION;
                                    objPRE.ACCION = objPR.ACCION;
                                    objPRE.COMPROMISO = objPR.COMPROMISO;
                                    objPRE.INDICADOR = objPR.INDICADOR;
                                    objPRE.Save();

                                    EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                                    objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                                    objPSE.CODSECCIONINSTRUMENTO = objSIE.CODSECCIONINSTRUMENTO;
                                    objPSE.PONDERACION = objPR.PONDERACION;
                                    objPSE.Save();
                                }
                            }
                            objIE.IsPersisted = false;
                        }
                        break;
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

        public bool ActualizarPreguntas(EINSTRUMENTOEMPLEADO objIE)
        {
            try
            {
                foreach (ESECCIONINSTRUMENTOEMPLEADO objSE in objIE.SECCIONES)
                {
                    BFPREGUNTASECCIONEMPLEADO objBFPSE = new BFPREGUNTASECCIONEMPLEADO();
                    objBFPSE.LimpiarPreguntaSeccionEmp(objSE.CODSECCIONINSTRUMENTO);

                    foreach (EPREGUNTAEMPLEADO objPR in objSE.PREGUNTAS)
                    {
                        EPREGUNTAEMPLEADO objPRE = new EPREGUNTAEMPLEADO();
                        objPRE.TEXTO = objPR.TEXTO;
                        objPRE.DESCRIPCION = objPR.DESCRIPCION;
                        objPRE.ACCION = objPR.ACCION;
                        objPRE.COMPROMISO = objPR.COMPROMISO;
                        objPRE.INDICADOR = objPR.INDICADOR;
                        if (objPRE.CODPREGUNTAEMPLEADO == 0)
                        {
                            objPRE.IsPersisted = false;
                            objPRE.Save();

                            EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                            objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                            objPSE.CODSECCIONINSTRUMENTO = objSE.CODSECCIONINSTRUMENTO;
                            objPSE.PONDERACION = objPR.PONDERACION;
                            objPSE.IsPersisted = false;
                            objPSE.Save();
                        }
                        else
                        {
                            objPRE.IsPersisted = true;
                            objPRE.Save();

                            EPREGUNTASECCIONEMPLEADO objPSE = new EPREGUNTASECCIONEMPLEADO();
                            objPSE.CODPREGUNTAEMPLEADO = objPRE.CODPREGUNTAEMPLEADO;
                            objPSE.CODSECCIONINSTRUMENTO = objSE.CODSECCIONINSTRUMENTO;
                            objPSE.PONDERACION = objPR.PONDERACION;
                            objPSE.IsPersisted = true;
                            objPSE.Save();
                        }
                    }
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

        public List<EINSTRUMENTOEMPLEADO> GetINSTRUMENTOEMPLEADOAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EINSTRUMENTOEMPLEADO> GetAsignaciones(String NombreAsignacion)
        {
            return _objDALList.GetAsignaciones(NombreAsignacion);
        }

        public List<EINSTRUMENTOEMPLEADO> GetAsignaciones(String NombreAsignacion, DateTime Inicio, DateTime Fin)
        {
            return _objDALList.GetAsignaciones(NombreAsignacion, Inicio, Fin);
        }

        public List<EINSTRUMENTOEMPLEADO> GetAsignaciones(string CodInstrumento, String NombreAsignacion, DateTime Inicio, DateTime Fin)
        {
            return _objDALList.GetAsignaciones(CodInstrumento, NombreAsignacion, Inicio, Fin);
        }
        public List<EINSTRUMENTOEMPLEADO> GetAsignaciones(string CodInstrumento, String NombreAsignacion, DateTime Inicio, DateTime Fin, Int16 Tipo)
        {
            return _objDALList.GetAsignaciones(CodInstrumento, NombreAsignacion, Inicio, Fin, Tipo);
        }

        public DataTable GetInstrumentosPorEstado(Int64 Rut, string Nombre, Decimal CodEstado)
        {
            return _objDALList.GetInstrumentosPorEstado(Rut, Nombre, CodEstado);
        }

        public DataTable GetInstrumentosPorEstado(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador, Decimal CodEstado)
        {
            return _objDALList.GetInstrumentosPorEstado(NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2, Evaluador, Visador, CodEstado);
        }

        public DataTable GetInstrumentosPorEstado(Int64 Rut, string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2, Decimal CodEstado)
        {
            DataTable dt = _objDALList.GetInstrumentosPorEstado(Rut, NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2, CodEstado);
            return dt;
        }

        public DataTable GetInstrumentosPorTipo(Int64 Rut, string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2, Decimal CodTipo)
        {
            DataTable dt = _objDALList.GetInstrumentosPorTipo(Rut, NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2, CodTipo);
            return dt;
        }

        public DataTable BuscarAsignaciones(Decimal CodInstrumento, string Nombre, DateTime Inicio, DateTime Fin)
        {
            DataTable dt = _objDALList.BuscarAsignaciones(CodInstrumento, Nombre, Inicio, Fin);
            return dt;
        }

        public DataTable BuscarAsignacionesPartners(Decimal CodInstrumento, string Nombre, DateTime Inicio, DateTime Fin)
        {
            DataTable dt = _objDALList.BuscarAsignacionesPartners(CodInstrumento, Nombre, Inicio, Fin);
            return dt;
        }

        public DataTable BuscarAsignacionesPartners(Decimal CodInstrumento, string Nombre, DateTime Inicio, DateTime Fin, Int16 Tipo, Int64 RutEmpresa)
        {
            DataTable dt = _objDALList.BuscarAsignacionesPartners(CodInstrumento, Nombre, Inicio, Fin, Tipo, RutEmpresa);
            return dt;
        }

        public DataTable AsignacionesPorEvaluador(Int64 Rut)
        {
            DataTable dt = _objDALList.EvaluacionesPorEvaluador(Rut);
            return dt;
        }

        public DataTable Asignaciones()
        {
            DataTable dt = _objDALList.Evaluaciones();
            return dt;
        }

        public DataTable CantidadEvalPorEstado(Int64 Rut, string Nombre)
        {
            DataTable dt = _objDALList.CantidadEvalPorEstado(Rut, Nombre);
            return dt;
        }

        public DataTable CantidadEvalPorEstado(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador)
        {
            DataTable dt = _objDALList.CantidadEvalPorEstado(NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2, Evaluador, Visador);
            return dt;
        }

        public DataTable DistribucionPorCategorias(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador)
        {
            DataTable dt = _objDALList.DistribucionPorCategorias(NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2, Evaluador, Visador);
            return dt;
        }

        public DataTable CantidadEvalPorEstado(Int64 Rut, string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2)
        {
            DataTable dt = _objDALList.CantidadEvalPorEstado(Rut, NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2);
            return dt;
        }

        public DataTable CantidadEvalPorTipo(Int64 Rut, string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2)
        {
            DataTable dt = _objDALList.CantidadEvalPorTipo(Rut, NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2);
            return dt;
        }

        public DataTable GetMisEvaluaciones(Int64 Rut)
        {
            DataTable dt = _objDALList.GetMisEvaluaciones(Rut);
            return dt;
        }

        public DataTable GetMisKPI(Int64 Rut)
        {
            DataTable dt = _objDALList.GetMisKPI(Rut);
            return dt;
        }

        public DataTable GetMisKPIVigente(Int64 Rut)
        {
            DataTable dt = _objDALList.GetMisKPI(Rut);
            return dt;
        }

        public List<EINSTRUMENTOEMPLEADO> GetMiEvaluacionVigente(Int64 Rut)
        {
            List<EINSTRUMENTOEMPLEADO> dt = _objDALList.GetMiEvaluacionVigente(Rut);
            return dt;
        }

        public DataTable GetMisVisaciones(Int64 Rut)
        {
            DataTable dt = _objDALList.GetMisVisaciones(Rut);
            return dt;
        }

        public DataTable GetHistorial(Int64 Rut)
        {
            DataTable dt = _objDALList.GetHistorial(Rut);
            return dt;
        }

        public DataTable GetResumenGrafico01(Int64 Rut, string NombreEval, DateTime Inicio, DateTime Fin)
        {
            DataTable dt = _objDALList.GetResumenGrafico01(Rut, NombreEval, Inicio, Fin);
            return dt;
        }

        public DataTable GetResumenGrafico02Y03(Int64 Rut, string NombreEval, DateTime Inicio, DateTime Fin, int Tipo)
        {
            DataTable dt = _objDALList.GetResumenGrafico02Y03(Rut, NombreEval, Inicio, Fin, Tipo);
            return dt;
        }
        public DataTable GetResumenSeccionesGrafico02Y03(Int64 Rut, string NombreEval,  int Tipo)
        {
            DataTable dt = _objDALList.GetResumenSeccionesGrafico02Y03(Rut, NombreEval, Tipo);
            return dt;
        }

        public bool Delete(EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO)
		{
			try
			{
                _objDAL.Delete(objINSTRUMENTOEMPLEADO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO)
        {
            try
            {
                _objDAL.Update(objINSTRUMENTOEMPLEADO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public void Apelar(Decimal CodInstrumentoEmpleado, string Motivo)
        {
            try
            {
                _objDALList.Apelar(CodInstrumentoEmpleado, Motivo);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public void Visar(Decimal CodInstrumentoEmpleado, string Motivo)
        {
            try
            {
                _objDALList.Visar(CodInstrumentoEmpleado, Motivo);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public void AcuerdoyComentariosFeedback(Decimal CodInstrumentoEmpleado, Boolean Acuerdo, string ComentarioFeedback)
        {
            try
            {
                _objDALList.AcuerdoyComentariosFeedback(CodInstrumentoEmpleado, Acuerdo, ComentarioFeedback);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public void AgregarComentario(Decimal CodInstrumentoEmpleado, string Comentario, Int64 RutUsuario, string Modo)
        {
            try
            {
                _objDALList.AgregarComentario(CodInstrumentoEmpleado, Comentario, RutUsuario, Modo);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public void ActualizarPlanDesarrollo(Decimal CodInstrumentoEmpleado, string PlanDesarrollo)
        {
            try
            {
                _objDALList.ActualizarPlanDesarrollo(CodInstrumentoEmpleado, PlanDesarrollo);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public void Informar(Decimal CodInstrumentoEmpleado)
        {
            try
            {
                _objDALList.Informar(CodInstrumentoEmpleado);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
            }
        }

        public void GetReporteSabanaDetalle(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador)
        {
            DataTable dt = _objDALList.GetReporteSabanaDetalle(NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1, 
                                CodClasificador2, Evaluador, Visador);
            string Ruta = "ReporteDetalle_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Second.ToString().PadLeft(2, '0') + ".xls";
            Utiles.ExporttoExcel(ref dt, Ruta);
            //return dt;
        }

        public void GetReporteSabanaConsolidado(string NomInstrumentoEmpleado, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2,
                                Int64 Evaluador, Int64 Visador)
        {
            DataTable dt = _objDALList.GetReporteSabanaConsolidado(NomInstrumentoEmpleado, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2, Evaluador, Visador);
            string Ruta = "ReporteConsolidado_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + "_" + DateTime.Now.Second.ToString().PadLeft(2, '0') + ".xls";
            Utiles.ExporttoExcel(ref dt, Ruta);
            //return dt;
        }

        public List<EINSTRUMENTOEMPLEADO> GetInstrumentosEstado(string NomInstrumentoEmpleado, string NomEmpleado)
        {
            return _objDALList.GetInstrumentosEstado(NomInstrumentoEmpleado, NomEmpleado);

        }

        public DataSet AsignacionesPorExcel(string strRuta, Int64 RutEmpresa)
        {
            DataSet dsTmp = new DataSet();
            DataTable dtTmp = new DataTable();
            dtTmp.Columns.Add("RUTCOMPLETO");
            dtTmp.Columns.Add("NOMBREEMPLEADO");
            dtTmp.Columns.Add("APELLIDOPATERNO");
            dtTmp.Columns.Add("APELLIDOMATERNO");
            dtTmp.Columns.Add("NOMBRE_GERENCIA");
            dtTmp.Columns.Add("NOMBRE_CARGO");
            dtTmp.Columns.Add("RUTEVALUADOR");
            dtTmp.Columns.Add("EVALUADOR");

            DataTable dtError = new DataTable();
            dtError.Columns.Add("RUT");

            try
            {
                DataSet excelList = _objDALList.SelectAsignacionesByExcel(strRuta);
                DataSet dsResultado = new DataSet();
                if (excelList.Tables.Count > 0)
                {
                    DataTable dt = excelList.Tables[0];
                    DataRow drTmp;
                    DataRow drTmpError;
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        BFEMPLEADO objBFEM = new BFEMPLEADO();
                        EEMPLEADO objEM = objBFEM.GetEMPLEADO(Utiles.RutUsrALng(dr[0].ToString().Trim()));
                        EEMPLEADO objPAR = objBFEM.GetEMPLEADO(Utiles.RutUsrALng(dr[1].ToString().Trim()));
                        if ((objEM.RUTEMPLEADO != 0) && (objEM.RUTEMPRESA == RutEmpresa))
                        {
                            drTmp = dtTmp.NewRow();
                            drTmp["RUTCOMPLETO"] = dr[0].ToString();
                            drTmp["NOMBREEMPLEADO"] = objEM.NOMBREEMPLEADO;
                            drTmp["APELLIDOPATERNO"] = objEM.APELLIDOPATERNO;
                            drTmp["APELLIDOMATERNO"] = objEM.APELLIDOMATERNO;
                            drTmp["NOMBRE_GERENCIA"] = objEM.NOMBRE_GERENCIA;
                            drTmp["NOMBRE_CARGO"] = objEM.NOMBRE_CARGO;
                            drTmp["RUTEVALUADOR"] = objPAR.RUTCOMPLETO;
                            drTmp["EVALUADOR"] = objPAR.NOMBRECOMPLETO;
                            dtTmp.Rows.Add(drTmp);
                        }
                        else
                        {
                            drTmpError = dtError.NewRow();
                            drTmpError["RUT"] = dr[1].ToString();
                            dtError.Rows.Add(drTmpError);
                        }
                    }
                }
                dsResultado.Tables.Add(dtTmp);
                dsResultado.Tables.Add(dtError);
                return dsResultado;
                //return dtTmp;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return dsTmp;
            }
        }

        public DataTable GetDetalleHistorial(Int64 Rut, string NombreInstrumento, DateTime Inicio, DateTime Fin)
        {
            return _objDALList.GetDetalleHistorial(Rut, NombreInstrumento, Inicio, Fin);
        }

    }
}

