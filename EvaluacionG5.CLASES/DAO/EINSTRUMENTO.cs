
using System;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EINSTRUMENTO.
	/// </summary>
    [Serializable()]
    public class EINSTRUMENTO : DomainObject
    {
	    	
	    private System.Decimal  _COD_INSTRUMENTO = 0;
        	
	    private System.Decimal  _CODESCALA = 0;
        	
	    private System.Int16  _COD_GRADO = 0;
        	
	    private System.String  _NOMBRE_INSTRUMENTO = String.Empty;
        	
	    private System.String  _DESCRIPCION = String.Empty;
        	
	    private System.String  _OBSERVACION = String.Empty;
        	
	    private System.Boolean  _FLAG_AUTOEVALUACION = false;

        private System.Boolean _FLAG_VISACION = false;

        private System.Boolean _FLAG_APELACION = false;

        private System.Int64 _RUT_EMPRESA = 0;

        private System.Boolean _FLAG_CALIBRACION = false;

        private System.Boolean _FLAG_INGRESO_OBJETIVOS = false;

        private System.Double _POND_AUTO_EVALUACION = 0.0;

        private System.Double _POND_JEFATURAS = 0.0;

        private System.Double _POND_COLABORADORES = 0.0;

        private System.Double _POND_PARES = 0.0;

        private List<ESECCION> _SECCIONES = new List<ESECCION>();

        private List<ECURSO> _CURSOS = new List<ECURSO>();


        public EINSTRUMENTO() : base()
	    {
	    }
	    
		public EINSTRUMENTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODINSTRUMENTO
	    {
		    get { return _COD_INSTRUMENTO; }
		    set { _COD_INSTRUMENTO = value; }
	    }
	    
	    	
	    public System.Decimal CODESCALA
	    {
		    get { return _CODESCALA; }
		    set { _CODESCALA = value; }
	    }
	    
	    	
	    public System.Int16 CODGRADO
	    {
		    get { return _COD_GRADO; }
		    set { _COD_GRADO = value; }
	    }
	    
	    	
	    public System.String NOMBREINSTRUMENTO
	    {
		    get { return _NOMBRE_INSTRUMENTO; }
		    set { _NOMBRE_INSTRUMENTO = value; }
	    }
	    
	    	
	    public System.String DESCRIPCION
	    {
		    get { return _DESCRIPCION; }
		    set { _DESCRIPCION = value; }
	    }
	    
	    	
	    public System.String OBSERVACION
	    {
		    get { return _OBSERVACION; }
		    set { _OBSERVACION = value; }
	    }
	    
	    	
	    public System.Boolean FLAGAUTOEVALUACION
	    {
		    get { return _FLAG_AUTOEVALUACION; }
		    set { _FLAG_AUTOEVALUACION = value; }
	    }

        public bool FLAG_VISACION
        {
            get { return _FLAG_VISACION; }
            set {  _FLAG_VISACION = value; }
        }

        public bool FLAG_APELACION
        {
            get { return _FLAG_APELACION; }
            set { _FLAG_APELACION = value; }
        }

        public List<ESECCION> SECCIONES
        {
            get
            {
                return _SECCIONES;
            }

            set
            {
                _SECCIONES = value;
            }
        }

        public long RUT_EMPRESA
        {
            get
            {
                return _RUT_EMPRESA;
            }

            set
            {
                _RUT_EMPRESA = value;
            }
        }

        public bool FLAGCALIBRACION
        {
            get
            {
                return _FLAG_CALIBRACION;
            }

            set
            {
                _FLAG_CALIBRACION = value;
            }
        }

        public bool FLAGINGRESOOBJETIVOS
        {
            get
            {
                return _FLAG_INGRESO_OBJETIVOS;
            }

            set
            {
                _FLAG_INGRESO_OBJETIVOS = value;
            }
        }

        public double PONDAUTOEVALUACION
        {
            get
            {
                return _POND_AUTO_EVALUACION;
            }

            set
            {
                _POND_AUTO_EVALUACION = value;
            }
        }

        public double PONDJEFATURAS
        {
            get
            {
                return _POND_JEFATURAS;
            }

            set
            {
                _POND_JEFATURAS = value;
            }
        }

        public double PONDCOLABORADORES
        {
            get
            {
                return _POND_COLABORADORES;
            }

            set
            {
                _POND_COLABORADORES = value;
            }
        }

        public double PONDPARES
        {
            get
            {
                return _POND_PARES;
            }

            set
            {
                _POND_PARES = value;
            }
        }

        public List<ECURSO> CURSOS
        {
            get
            {
                return _CURSOS;
            }

            set
            {
                _CURSOS = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLINSTRUMENTO();
        }

        #endregion	    
    }
}