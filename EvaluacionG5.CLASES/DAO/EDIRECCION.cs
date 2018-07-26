
using System;
using EvaluacionG5.CLASES.DAL;
using System.Data;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EDIRECCION.
	/// </summary>
    public class EDIRECCION : DomainObject
    {
	    	
	    private System.Int64  _RUT_EMPRESA = 0;
        	
	    private System.String  _COD_DIRECCION = String.Empty;
        	
	    private System.String  _NOM_DIRECCION = String.Empty;
        	
        
	    public EDIRECCION() : base()
	    {
	    }
	    
		public EDIRECCION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int64 RUTEMPRESA
	    {
		    get { return _RUT_EMPRESA; }
		    set { _RUT_EMPRESA = value; }
	    }
	    
	    	
	    public System.String CODDIRECCION
	    {
		    get { return _COD_DIRECCION; }
		    set { _COD_DIRECCION = value; }
	    }
	    
	    	
	    public System.String NOMDIRECCION
	    {
		    get { return _NOM_DIRECCION; }
		    set { _NOM_DIRECCION = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLDIRECCION();
        }

        #endregion	    
    }
}