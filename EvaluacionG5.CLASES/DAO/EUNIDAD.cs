
using System;
using EvaluacionG5.CLASES.DAL;
using System.Data;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EUNIDAD.
	/// </summary>
    public class EUNIDAD : DomainObject
    {
	    	
	    private System.Int64  _RUT_EMPRESA = 0;
        	
	    private System.String  _COD_UNIDAD = String.Empty;
        	
	    private System.String  _NOM_UNIDAD = String.Empty;
        	
        
	    public EUNIDAD() : base()
	    {
	    }
	    
		public EUNIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int64 RUTEMPRESA
	    {
		    get { return _RUT_EMPRESA; }
		    set { _RUT_EMPRESA = value; }
	    }
	    
	    	
	    public System.String CODUNIDAD
	    {
		    get { return _COD_UNIDAD; }
		    set { _COD_UNIDAD = value; }
	    }
	    
	    	
	    public System.String NOMUNIDAD
	    {
		    get { return _NOM_UNIDAD; }
		    set { _NOM_UNIDAD = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLUNIDAD();
        }

        #endregion	    
    }
}