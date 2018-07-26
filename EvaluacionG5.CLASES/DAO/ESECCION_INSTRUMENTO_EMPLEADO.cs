
using System;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ESECCIONINSTRUMENTOEMPLEADO.
	/// </summary>
    [Serializable()]
    public class ESECCIONINSTRUMENTOEMPLEADO : DomainObject
    {
	    	
	    private System.Decimal  _COD_SECCION_INSTRUMENTO = 0;
        	
	    private System.Decimal  _COD_INSTRUMENTO_EMPLEADO = 0;

        private System.Int16 _COD_TIPO_SECCION = 0;

        private System.String  _NOMBRE = String.Empty;
        	
	    private System.String  _DESCRIPCION = String.Empty;
        	
	    private System.Int16  _ORDEN = 0;
        	
	    private System.Double  _PONDERACION = 0.0;
        	
	    private System.Double  _RESULTADO = 0.0;

        private System.Boolean _FLAG_AGREGAR_PREGUNTAS = false;

        private List<EPREGUNTAEMPLEADO> _PREGUNTAS = new List<EPREGUNTAEMPLEADO>();
        	
        
	    public ESECCIONINSTRUMENTOEMPLEADO() : base()
	    {
	    }
	    
		public ESECCIONINSTRUMENTOEMPLEADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODSECCIONINSTRUMENTO
	    {
		    get { return _COD_SECCION_INSTRUMENTO; }
		    set { _COD_SECCION_INSTRUMENTO = value; }
	    }
	    
	    	
	    public System.Decimal CODINSTRUMENTOEMPLEADO
	    {
		    get { return _COD_INSTRUMENTO_EMPLEADO; }
		    set { _COD_INSTRUMENTO_EMPLEADO = value; }
	    }
	    
	    	
	    public System.String NOMBRE
	    {
		    get { return _NOMBRE; }
		    set { _NOMBRE = value; }
	    }
	    
	    	
	    public System.String DESCRIPCION
	    {
		    get { return _DESCRIPCION; }
		    set { _DESCRIPCION = value; }
	    }
	    
	    	
	    public System.Int16 ORDEN
	    {
		    get { return _ORDEN; }
		    set { _ORDEN = value; }
	    }
	    
	    	
	    public System.Double PONDERACION
	    {
		    get { return _PONDERACION; }
		    set { _PONDERACION = value; }
	    }
	    
	    	
	    public System.Double RESULTADO
	    {
		    get { return _RESULTADO; }
		    set { _RESULTADO = value; }
	    }

        public List<EPREGUNTAEMPLEADO> PREGUNTAS
        {
            get
            {
                return _PREGUNTAS;
            }

            set
            {
                _PREGUNTAS = value;
            }
        }

        public short COD_TIPO_SECCION
        {
            get
            {
                return _COD_TIPO_SECCION;
            }

            set
            {
                _COD_TIPO_SECCION = value;
            }
        }

        public bool FLAG_AGREGAR_PREGUNTAS
        {
            get
            {
                return _FLAG_AGREGAR_PREGUNTAS;
            }

            set
            {
                _FLAG_AGREGAR_PREGUNTAS = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLSECCIONINSTRUMENTOEMPLEADO();
        }

        #endregion	    
    }
}