
using System;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EEMPLEADO.
	/// </summary>
    [Serializable()]
    public class EEMPLEADO : DomainObject
    {
	    	
	    private System.Int64  _RUT_EMPLEADO = 0;
        	
	    private System.String  _NOMBRE_EMPLEADO = String.Empty;
        	
	    private System.String  _APELLIDO_PATERNO = String.Empty;
        	
	    private System.String  _APELLIDO_MATERNO = String.Empty;
        	
	    private System.String  _EMAIL = String.Empty;

        private System.DateTime _FECHA_NACIMIENTO = DateTime.Now;

        private System.String _COD_SEXO = String.Empty;

        private System.String _COD_COMUNA = String.Empty;

        private System.String _NOM_COMUNA = String.Empty;

        private System.String _COMUNA = String.Empty;

        private System.Int16 _COD_NIVEL_EDUCACIONAL = 0;

        private System.String _NIVEL_EDUCACIONAL = String.Empty;

        private System.Int16 _COD_NIVEL_OCUPACIONAL = 0;

        private System.String _NIVEL_OCUPACIONAL = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;

        private System.String _NOMBRE_FANTASIA = String.Empty;

        private System.String _COD_GERENCIA = String.Empty;

        private System.String _NOMBRE_GERENCIA = String.Empty;

        private System.String _COD_SUCURSAL = String.Empty;

        private System.String _NOMBRE_SUCURSAL = String.Empty;

        private System.String _COD_CENTRO_COSTO = String.Empty;

        private System.String _NOMBRE_CENTRO_COSTO = String.Empty;

        private System.String _COD_AREA = String.Empty;

        private System.String _NOMBRE_AREA = String.Empty;

        private System.String _COD_UNIDAD = String.Empty;

        private System.String _NOMBRE_UNIDAD = String.Empty;

        private System.String _COD_DIRECCION = String.Empty;

        private System.String _NOMBRE_DIRECCION = String.Empty;

        private System.String _COD_FAMILIA_CARGO = String.Empty;

        private System.String _NOMBRE_FAMILIA_CARGO = String.Empty;

        private System.String _COD_CARGO = String.Empty;

        private System.String _NOMBRE_CARGO = String.Empty;

        private System.String _COD_ROL = String.Empty;

        private System.String _NOMBRE_ROL = String.Empty;

        private System.String _COD_CLASIFICADOR_1 = String.Empty;

        private System.String _NOMBRE_CLASIFICADOR_1 = String.Empty;

        private System.String _COD_CLASIFICADOR_2 = String.Empty;

        private System.String _NOMBRE_CLASIFICADOR_2 = String.Empty;

        private System.DateTime  _FECHA_INGRESO = DateTime.Now;

        private System.Int64 _RUT_JEFE = 0;

        private System.String _JEFE = String.Empty;

        private System.Int64 _RUT_VISADOR = 0;

        private System.String _VISADOR = String.Empty;

        private System.Boolean _FLAG_ACTIVO = false;


        public EEMPLEADO() : base()
	    {
	    }
	    
		public EEMPLEADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int64 RUTEMPLEADO
	    {
		    get { return _RUT_EMPLEADO; }
		    set { _RUT_EMPLEADO = value; }
        }

        public System.String RUTCOMPLETO
        {
            get { return Utiles.ConvertToString(_RUT_EMPLEADO) + '-' + Utiles.digito_verificador(_RUT_EMPLEADO); }
        }

        public System.String NOMBREEMPLEADO
	    {
		    get { return _NOMBRE_EMPLEADO; }
		    set { _NOMBRE_EMPLEADO = value; }
	    }	    
	    	
	    public System.String APELLIDOPATERNO
	    {
		    get { return _APELLIDO_PATERNO; }
		    set { _APELLIDO_PATERNO = value; }
	    }	    
	    	
	    public System.String APELLIDOMATERNO
	    {
		    get { return _APELLIDO_MATERNO; }
		    set { _APELLIDO_MATERNO = value; }
        }

        public System.String NOMBRECOMPLETO
        {
            get { return _NOMBRE_EMPLEADO + ' ' + _APELLIDO_PATERNO + ' ' + _APELLIDO_MATERNO; }
        }

        public System.String EMAIL
	    {
		    get { return _EMAIL; }
		    set { _EMAIL = value; }
	    }	    
	    	
	    public System.DateTime FECHAINGRESO
	    {
		    get { return _FECHA_INGRESO; }
		    set { _FECHA_INGRESO = value; }
	    }	    
	    	
	    public System.Int64 RUTEMPRESA
	    {
		    get { return _RUT_EMPRESA; }
		    set { _RUT_EMPRESA = value; }
	    }	    
	    	
	    public System.String CODSUCURSAL
	    {
		    get { return _COD_SUCURSAL; }
		    set { _COD_SUCURSAL = value; }
	    }	    
	    	
	    public System.String CODAREA
	    {
		    get { return _COD_AREA; }
		    set { _COD_AREA = value; }
	    }	    
	    	
	    public System.String CODCARGO
	    {
		    get { return _COD_CARGO; }
		    set { _COD_CARGO = value; }
	    }	    
	    	
	    public System.String CODROL
	    {
		    get { return _COD_ROL; }
		    set { _COD_ROL = value; }
	    }	    
	    	
	    public System.Int64 RUTJEFE
	    {
		    get { return _RUT_JEFE; }
		    set { _RUT_JEFE = value; }
	    }	    
	    	
	    public System.Int64 RUTVISADOR
	    {
		    get { return _RUT_VISADOR; }
		    set { _RUT_VISADOR = value; }
	    }

        public string COD_GERENCIA
        {
            get { return _COD_GERENCIA; }
            set { _COD_GERENCIA = value; }
        }

        public string COD_CENTRO_COSTO
        {
            get { return _COD_CENTRO_COSTO; }
            set { _COD_CENTRO_COSTO = value; }
        }

        public string COD_CLASIFICADOR_1
        {
            get { return _COD_CLASIFICADOR_1; }
            set { _COD_CLASIFICADOR_1 = value; }
        }

        public string COD_CLASIFICADOR_2
        {
            get { return _COD_CLASIFICADOR_2; }
            set { _COD_CLASIFICADOR_2 = value; }
        }

        public string NOMBRE_FANTASIA
        {
            get
            {
                return _NOMBRE_FANTASIA;
            }

            set
            {
                _NOMBRE_FANTASIA = value;
            }
        }

        public string NOMBRE_GERENCIA
        {
            get
            {
                return _NOMBRE_GERENCIA;
            }

            set
            {
                _NOMBRE_GERENCIA = value;
            }
        }

        public string NOMBRE_CENTRO_COSTO
        {
            get
            {
                return _NOMBRE_CENTRO_COSTO;
            }

            set
            {
                _NOMBRE_CENTRO_COSTO = value;
            }
        }

        public string NOMBRE_SUCURSAL
        {
            get
            {
                return _NOMBRE_SUCURSAL;
            }

            set
            {
                _NOMBRE_SUCURSAL = value;
            }
        }

        public string NOMBRE_AREA
        {
            get
            {
                return _NOMBRE_AREA;
            }

            set
            {
                _NOMBRE_AREA = value;
            }
        }

        public string NOMBRE_CARGO
        {
            get
            {
                return _NOMBRE_CARGO;
            }

            set
            {
                _NOMBRE_CARGO = value;
            }
        }

        public string NOMBRE_ROL
        {
            get
            {
                return _NOMBRE_ROL;
            }

            set
            {
                _NOMBRE_ROL = value;
            }
        }

        public string NOMBRE_CLASIFICADOR_1
        {
            get
            {
                return _NOMBRE_CLASIFICADOR_1;
            }

            set
            {
                _NOMBRE_CLASIFICADOR_1 = value;
            }
        }

        public string NOMBRE_CLASIFICADOR_2
        {
            get
            {
                return _NOMBRE_CLASIFICADOR_2;
            }

            set
            {
                _NOMBRE_CLASIFICADOR_2 = value;
            }
        }

        public string JEFE
        {
            get
            {
                return _JEFE;
            }

            set
            {
                _JEFE = value;
            }
        }

        public string VISADOR
        {
            get
            {
                return _VISADOR;
            }

            set
            {
                _VISADOR = value;
            }
        }

        public DateTime FECHA_NACIMIENTO
        {
            get
            {
                return _FECHA_NACIMIENTO;
            }

            set
            {
                _FECHA_NACIMIENTO = value;
            }
        }

        public string COD_SEXO
        {
            get
            {
                return _COD_SEXO;
            }

            set
            {
                _COD_SEXO = value;
            }
        }

        public short COD_NIVEL_EDUCACIONAL
        {
            get
            {
                return _COD_NIVEL_EDUCACIONAL;
            }

            set
            {
                _COD_NIVEL_EDUCACIONAL = value;
            }
        }

        public string NIVEL_EDUCACIONAL
        {
            get
            {
                return _NIVEL_EDUCACIONAL;
            }

            set
            {
                _NIVEL_EDUCACIONAL = value;
            }
        }

        public short COD_NIVEL_OCUPACIONAL
        {
            get
            {
                return _COD_NIVEL_OCUPACIONAL;
            }

            set
            {
                _COD_NIVEL_OCUPACIONAL = value;
            }
        }

        public string NIVEL_OCUPACIONAL
        {
            get
            {
                return _NIVEL_OCUPACIONAL;
            }

            set
            {
                _NIVEL_OCUPACIONAL = value;
            }
        }

        public string COD_UNIDAD
        {
            get
            {
                return _COD_UNIDAD;
            }

            set
            {
                _COD_UNIDAD = value;
            }
        }

        public string NOMBRE_UNIDAD
        {
            get
            {
                return _NOMBRE_UNIDAD;
            }

            set
            {
                _NOMBRE_UNIDAD = value;
            }
        }

        public string COD_DIRECCION
        {
            get
            {
                return _COD_DIRECCION;
            }

            set
            {
                _COD_DIRECCION = value;
            }
        }

        public string NOMBRE_DIRECCION
        {
            get
            {
                return _NOMBRE_DIRECCION;
            }

            set
            {
                _NOMBRE_DIRECCION = value;
            }
        }

        public string COMUNA
        {
            get
            {
                return COMUNA1;
            }

            set
            {
                COMUNA1 = value;
            }
        }

        public string COD_COMUNA
        {
            get
            {
                return _COD_COMUNA;
            }

            set
            {
                _COD_COMUNA = value;
            }
        }

        public string COMUNA1
        {
            get
            {
                return _COMUNA;
            }

            set
            {
                _COMUNA = value;
            }
        }

        public string NOM_COMUNA
        {
            get
            {
                return _NOM_COMUNA;
            }

            set
            {
                _NOM_COMUNA = value;
            }
        }

        public bool FLAG_ACTIVO
        {
            get
            {
                return _FLAG_ACTIVO;
            }

            set
            {
                _FLAG_ACTIVO = value;
            }
        }

        public string COD_FAMILIA_CARGO
        {
            get
            {
                return _COD_FAMILIA_CARGO;
            }

            set
            {
                _COD_FAMILIA_CARGO = value;
            }
        }

        public string NOMBRE_FAMILIA_CARGO
        {
            get
            {
                return _NOMBRE_FAMILIA_CARGO;
            }

            set
            {
                _NOMBRE_FAMILIA_CARGO = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLEMPLEADO();
        }

        #endregion	    
    }
}