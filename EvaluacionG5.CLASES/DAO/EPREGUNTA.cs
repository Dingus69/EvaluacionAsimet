
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPREGUNTA.
	/// </summary>
    [Serializable()]
    public class EPREGUNTA : DomainObject
    {
	    	
	    private System.Decimal  _COD_PREGUNTA = 0;
        	
	    private System.String  _TEXTO = String.Empty;
        	
	    private System.String  _DESCRIPCION = String.Empty;
        	
	    private System.String  _ACCION = String.Empty;
        	
	    private System.String  _COMPROMISO = String.Empty;
        	
	    private System.String  _INDICADOR = String.Empty;

        private System.Double _PONDERACION = 0.0;


        public EPREGUNTA() : base()
	    {
	    }
	    
		public EPREGUNTA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODPREGUNTA
	    {
		    get { return _COD_PREGUNTA; }
		    set { _COD_PREGUNTA = value; }
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
            get { return _PONDERACION; }
            set { _PONDERACION = value; }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLPREGUNTA();
        }

        #endregion	    
    }
}