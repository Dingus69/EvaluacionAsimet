
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPREGUNTAEMPLEADO.
	/// </summary>
    [Serializable()]
    public class EPREGUNTAEMPLEADO : DomainObject
    {
	    	
	    private System.Decimal  _COD_PREGUNTA_EMPLEADO = 0;
        	
	    private System.String  _TEXTO = String.Empty;
        	
	    private System.String  _DESCRIPCION = String.Empty;
        	
	    private System.String  _ACCION = String.Empty;
        	
	    private System.String  _COMPROMISO = String.Empty;
        	
	    private System.String  _INDICADOR = String.Empty;

        private System.Double _PONDERACION = 0.0;

        private System.Double _RESULTADO = 0.0;

        private System.String _COMENTARIO = String.Empty;


        public EPREGUNTAEMPLEADO() : base()
	    {
	    }
	    
		public EPREGUNTAEMPLEADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODPREGUNTAEMPLEADO
	    {
		    get { return _COD_PREGUNTA_EMPLEADO; }
		    set { _COD_PREGUNTA_EMPLEADO = value; }
	    }
	    
	    	
	    public System.String TEXTO
	    {
		    get { return _TEXTO; }
		    set { _TEXTO = value; }
	    }
	    
	    	
	    public System.String DESCRIPCION
	    {
		    get { return _DESCRIPCION; }
		    set { _DESCRIPCION = value; }
	    }
	    
	    	
	    public System.String ACCION
	    {
		    get { return _ACCION; }
		    set { _ACCION = value; }
	    }
	    
	    	
	    public System.String COMPROMISO
	    {
		    get { return _COMPROMISO; }
		    set { _COMPROMISO = value; }
	    }
	    
	    	
	    public System.String INDICADOR
	    {
		    get { return _INDICADOR; }
		    set { _INDICADOR = value; }
	    }

        public double PONDERACION
        {
            get
            {
                return _PONDERACION;
            }

            set
            {
                _PONDERACION = value;
            }
        }

        public double RESULTADO
        {
            get
            {
                return _RESULTADO;
            }

            set
            {
                _RESULTADO = value;
            }
        }

        public string COMENTARIO
        {
            get
            {
                return _COMENTARIO;
            }

            set
            {
                _COMENTARIO = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLPREGUNTAEMPLEADO();
        }

        #endregion	    
    }
}