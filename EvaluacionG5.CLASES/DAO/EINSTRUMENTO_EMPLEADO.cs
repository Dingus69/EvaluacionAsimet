
using System;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EINSTRUMENTOEMPLEADO.
	/// </summary>
    [Serializable()]
    public class EINSTRUMENTOEMPLEADO : DomainObject
    {
	    	
	    private System.Decimal  _COD_INSTRUMENTO_EMPLEADO = 0;
        	
	    private System.Decimal  _COD_INSTRUMENTO = 0;
        	
	    private System.String  _NOM_INSTRUMENTO_EMPLEADO = String.Empty;

        private System.String _DESCRIPCION = String.Empty;

        private System.String _OBSERVACION = String.Empty;

        private System.String _PLAN_DESARROLLO = String.Empty;

        private System.Int64  _RUT_EMPLEADO = 0;

        private System.Int64 _RUT_EMPRESA = 0;

        private System.Int64  _RUT_EVALUADOR = 0;
        	
	    private System.Int64  _RUT_VISADOR = 0;
        	
	    private System.Int16  _COD_TIPO_EVAL = 0;
        	
	    private System.Decimal  _CODESTADOEVAL = 0;
        	
	    private System.DateTime  _INICIO_EVALUACION = DateTime.Now;
        	
	    private System.DateTime  _FIN_EVALUACION = DateTime.Now;
        	
	    private System.DateTime  _FECHA_EVALUACION = DateTime.Now;
        	
	    private System.Double  _RESULTADO = 0.0;
        	
	    private System.Boolean  _FLAG_VISADO = false;

        private System.Boolean _FLAG_AGREGAR_PREGUNTA = false;

        private System.Boolean _FLAG_AUTOEVALUACION = false;

        private System.String _NOMBRE_EVALUADO = String.Empty;

        private System.String _NOMBRE_EVALUADOR = String.Empty;

        private System.String _NOMBRE_VISADOR = String.Empty;

        private System.Boolean _FLAG_VISACION = false;

        private System.String _DETALLE_APELACION = String.Empty;

        private System.String _DETALLE_VIZACION = String.Empty;

        private System.Boolean _FLAG_APELACION = false;

        private System.String _MOTIVO_APELACION = String.Empty;

        private System.Int16 _COD_TIPO_INTRUMENTO = 0;

        private System.Boolean _FLAG_ACUERDO = false;

        private System.String _COMENTARIO_FEEDBACK = String.Empty;

        private System.String _PLAN_ACCION = String.Empty;

        private System.String _COMPROMISO = String.Empty;

        private System.String _COMENTARIOS_CURSO = String.Empty;

        private System.Boolean _FLAG_ANULADA = false;

        private List<ESECCIONINSTRUMENTOEMPLEADO> _SECCIONES = new List<ESECCIONINSTRUMENTOEMPLEADO>();

        private List<ECURSO> _CURSOS = new List<ECURSO>();

        private List<EOBJETIVOPROXIMO> _OBJETIVOSPROXIMOS = new List<EOBJETIVOPROXIMO>();

        private List<EOBJETIVOPROXIMO> _OBJETIVOSACTUALES = new List<EOBJETIVOPROXIMO>();


        public EINSTRUMENTOEMPLEADO() : base()
	    {
	    }
	    
		public EINSTRUMENTOEMPLEADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODINSTRUMENTOEMPLEADO
	    {
		    get { return _COD_INSTRUMENTO_EMPLEADO; }
		    set { _COD_INSTRUMENTO_EMPLEADO = value; }
	    }
	    
	    	
	    public System.Decimal CODINSTRUMENTO
	    {
		    get { return _COD_INSTRUMENTO; }
		    set { _COD_INSTRUMENTO = value; }
	    }
	    
	    	
	    public System.String NOMINSTRUMENTOEMPLEADO
	    {
		    get { return _NOM_INSTRUMENTO_EMPLEADO; }
		    set { _NOM_INSTRUMENTO_EMPLEADO = value; }
	    }
	    
	    	
	    public System.Int64 RUTEMPLEADO
	    {
		    get { return _RUT_EMPLEADO; }
		    set { _RUT_EMPLEADO = value; }
        }


        public System.String RUTCOMPLETO
        {
            get { return Utiles.RutLngAUsr(_RUT_EMPLEADO); }
        }


        public System.Int64 RUTEVALUADOR
	    {
		    get { return _RUT_EVALUADOR; }
		    set { _RUT_EVALUADOR = value; }
	    }
	    
	    	
	    public System.Int64 RUTVISADOR
	    {
		    get { return _RUT_VISADOR; }
		    set { _RUT_VISADOR = value; }
	    }
	    
	    	
	    public System.Int16 CODTIPOEVAL
	    {
		    get { return _COD_TIPO_EVAL; }
		    set { _COD_TIPO_EVAL = value; }
	    }
	    
	    	
	    public System.Decimal CODESTADOEVAL
	    {
		    get { return _CODESTADOEVAL; }
		    set { _CODESTADOEVAL = value; }
	    }
	    
	    	
	    public System.DateTime INICIOEVALUACION
	    {
		    get { return _INICIO_EVALUACION; }
		    set { _INICIO_EVALUACION = value; }
	    }
	    
	    	
	    public System.DateTime FINEVALUACION
	    {
		    get { return _FIN_EVALUACION; }
		    set { _FIN_EVALUACION = value; }
	    }
	    
	    	
	    public System.DateTime FECHAEVALUACION
	    {
		    get { return _FECHA_EVALUACION; }
		    set { _FECHA_EVALUACION = value; }
	    }
	    
	    	
	    public System.Double RESULTADO
	    {
		    get { return _RESULTADO; }
		    set { _RESULTADO = value; }
	    }
	    
	    	
	    public System.Boolean FLAGVISADO
	    {
		    get { return _FLAG_VISADO; }
		    set { _FLAG_VISADO = value; }
	    }

        public List<ESECCIONINSTRUMENTOEMPLEADO> SECCIONES
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

        public string OBSERVACION
        {
            get
            {
                return _OBSERVACION;
            }

            set
            {
                _OBSERVACION = value;
            }
        }

        public string DESCRIPCION
        {
            get
            {
                return _DESCRIPCION;
            }

            set
            {
                _DESCRIPCION = value;
            }
        }

        public bool FLAG_AGREGAR_PREGUNTA
        {
            get
            {
                return _FLAG_AGREGAR_PREGUNTA;
            }

            set
            {
                _FLAG_AGREGAR_PREGUNTA = value;
            }
        }

        public bool FLAG_VISACION
        {
            get
            {
                return _FLAG_VISACION;
            }

            set
            {
                _FLAG_VISACION = value;
            }
        }

        public bool FLAG_APELACION
        {
            get
            {
                return _FLAG_APELACION;
            }

            set
            {
                _FLAG_APELACION = value;
            }
        }

        public bool FLAG_AUTOEVALUACION
        {
            get
            {
                return _FLAG_AUTOEVALUACION;
            }

            set
            {
                _FLAG_AUTOEVALUACION = value;
            }
        }

        public string NOMBRE_EVALUADO
        {
            get
            {
                return _NOMBRE_EVALUADO;
            }

            set
            {
                _NOMBRE_EVALUADO = value;
            }
        }

        public string NOMBRE_EVALUADOR
        {
            get
            {
                return _NOMBRE_EVALUADOR;
            }

            set
            {
                _NOMBRE_EVALUADOR = value;
            }
        }

        public string NOMBRE_VISADOR
        {
            get
            {
                return _NOMBRE_VISADOR;
            }

            set
            {
                _NOMBRE_VISADOR = value;
            }
        }

        public string MOTIVO_APELACION
        {
            get
            {
                return _MOTIVO_APELACION;
            }

            set
            {
                _MOTIVO_APELACION = value;
            }
        }

        public short COD_TIPO_INTRUMENTO
        {
            get
            {
                return _COD_TIPO_INTRUMENTO;
            }

            set
            {
                _COD_TIPO_INTRUMENTO = value;
            }
        }

        public string PLAN_DESARROLLO
        {
            get
            {
                return _PLAN_DESARROLLO;
            }

            set
            {
                _PLAN_DESARROLLO = value;
            }
        }

        public bool FLAG_ACUERDO
        {
            get
            {
                return _FLAG_ACUERDO;
            }

            set
            {
                _FLAG_ACUERDO = value;
            }
        }

        public string COMENTARIO_FEEDBACK
        {
            get
            {
                return _COMENTARIO_FEEDBACK;
            }

            set
            {
                _COMENTARIO_FEEDBACK = value;
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

        public string PLAN_ACCION
        {
            get
            {
                return _PLAN_ACCION;
            }

            set
            {
                _PLAN_ACCION = value;
            }
        }

        public string COMPROMISO
        {
            get
            {
                return _COMPROMISO;
            }

            set
            {
                _COMPROMISO = value;
            }
        }

        public string COMENTARIOS_CURSO
        {
            get
            {
                return _COMENTARIOS_CURSO;
            }

            set
            {
                _COMENTARIOS_CURSO = value;
            }
        }

        public string DETALLE_VIZACION
        {
            get
            {
                return _DETALLE_VIZACION;
            }

            set
            {
                _DETALLE_VIZACION = value;
            }
        }

        public bool FLAG_ANULADA
        {
            get
            {
                return _FLAG_ANULADA;
            }

            set
            {
                _FLAG_ANULADA = value;
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

        public List<EOBJETIVOPROXIMO> OBJETIVOSPROXIMOS
        {
            get
            {
                return _OBJETIVOSPROXIMOS;
            }

            set
            {
                _OBJETIVOSPROXIMOS = value;
            }
        }

        public List<EOBJETIVOPROXIMO> OBJETIVOSACTUALES
        {
            get
            {
                return _OBJETIVOSACTUALES;
            }

            set
            {
                _OBJETIVOSACTUALES = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLINSTRUMENTOEMPLEADO();
        }

        #endregion	    
    }
}