
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
    /// <summary>
    /// Summary description for ERANGO.
    /// </summary>
    [Serializable()]
    public class ERANGO : DomainObject
    {
	    	
	    private System.Decimal  _COD_RANGO = 0;
        	
	    private System.Decimal  _CODESCALA = 0;
        	
	    private System.String  _NOMBRE_RANGO = String.Empty;
        	
	    private System.String  _DESCRIPCION_RANGO = String.Empty;
        	
	    private System.Double  _VALOR_RANGO = 0.0;
        	
        
	    public ERANGO() : base()
	    {
	    }
	    
		public ERANGO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODRANGO
	    {
		    get { return _COD_RANGO; }
		    set { _COD_RANGO = value; }
	    }
	    
	    	
	    public System.Decimal CODESCALA
	    {
		    get { return _CODESCALA; }
		    set { _CODESCALA = value; }
	    }
	    
	    	
	    public System.String NOMBRERANGO
	    {
		    get { return _NOMBRE_RANGO; }
		    set { _NOMBRE_RANGO = value; }
	    }
	    
	    	
	    public System.String DESCRIPCIONRANGO
	    {
		    get { return _DESCRIPCION_RANGO; }
		    set { _DESCRIPCION_RANGO = value; }
	    }
	    
	    	
	    public System.Double VALORRANGO
	    {
		    get { return _VALOR_RANGO; }
		    set { _VALOR_RANGO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLRANGO();
        }

        #endregion	    
    }
}