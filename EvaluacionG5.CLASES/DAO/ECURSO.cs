
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECURSO.
	/// </summary>
    public class ECURSO : DomainObject
    {
	    	
	    private System.String  _COD_CURSO = String.Empty;
        	
	    private System.Int16  _COD_MODALIDAD = 0;

        private System.String _NOM_MODALIDAD = String.Empty;

        private System.Decimal  _COD_AREA_CURSO = 0;

        private System.String _NOM_AREA_CURSO = String.Empty;

        private System.String  _NOMBRE_CURSO = String.Empty;
        	
	    private System.String  _PROVEEDOR = String.Empty;
        	
	    private System.Int32  _DURACION = 0;
        	
	    private System.String  _CODIGO_SENCE = String.Empty;
        	
	    private System.String  _LUGAR_EJECUCION = String.Empty;
        	
	    private System.Int64  _COSTO_PARTICIPANTE = 0;
        	
	    private System.Int32  _MAX_PARTICIPANTES = 0;

        private System.Boolean _ASIGNADO = false;


        public ECURSO() : base()
	    {
	    }
	    
		public ECURSO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODCURSO
	    {
		    get { return _COD_CURSO; }
		    set { _COD_CURSO = value; }
	    }
	    
	    	
	    public System.Int16 CODMODALIDAD
	    {
		    get { return _COD_MODALIDAD; }
		    set { _COD_MODALIDAD = value; }
	    }
	    
	    	
	    public System.Decimal CODAREACURSO
	    {
		    get { return _COD_AREA_CURSO; }
		    set { _COD_AREA_CURSO = value; }
	    }
	    
	    	
	    public System.String NOMBRECURSO
	    {
		    get { return _NOMBRE_CURSO; }
		    set { _NOMBRE_CURSO = value; }
	    }
	    
	    	
	    public System.String PROVEEDOR
	    {
		    get { return _PROVEEDOR; }
		    set { _PROVEEDOR = value; }
	    }
	    
	    	
	    public System.Int32 DURACION
	    {
		    get { return _DURACION; }
		    set { _DURACION = value; }
	    }
	    
	    	
	    public System.String CODIGOSENCE
	    {
		    get { return _CODIGO_SENCE; }
		    set { _CODIGO_SENCE = value; }
	    }
	    
	    	
	    public System.String LUGAREJECUCION
	    {
		    get { return _LUGAR_EJECUCION; }
		    set { _LUGAR_EJECUCION = value; }
	    }
	    
	    	
	    public System.Int64 COSTOPARTICIPANTE
	    {
		    get { return _COSTO_PARTICIPANTE; }
		    set { _COSTO_PARTICIPANTE = value; }
	    }
	    
	    	
	    public System.Int32 MAXPARTICIPANTES
	    {
		    get { return _MAX_PARTICIPANTES; }
		    set { _MAX_PARTICIPANTES = value; }
	    }

        public string NOMMODALIDAD
        {
            get
            {
                return _NOM_MODALIDAD;
            }

            set
            {
                _NOM_MODALIDAD = value;
            }
        }

        public string NOMAREACURSO
        {
            get
            {
                return _NOM_AREA_CURSO;
            }

            set
            {
                _NOM_AREA_CURSO = value;
            }
        }

        public bool ASIGNADO
        {
            get
            {
                return _ASIGNADO;
            }

            set
            {
                _ASIGNADO = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLCURSO();
        }

        #endregion	    
    }
}