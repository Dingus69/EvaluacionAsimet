
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EFAMILIACARGO.
	/// </summary>
    public class EFAMILIACARGO : DomainObject
    {
	    	
	    private System.Int64  _RUT_EMPRESA = 0;
        	
	    private System.String  _COD_FAMILIA_CARGO = String.Empty;
        	
	    private System.String  _NOM_FAMILIA_CARGO = String.Empty;
        	
        
	    public EFAMILIACARGO() : base()
	    {
	    }
	    
		public EFAMILIACARGO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int64 RUTEMPRESA
	    {
		    get { return _RUT_EMPRESA; }
		    set { _RUT_EMPRESA = value; }
	    }
	    
	    	
	    public System.String CODFAMILIACARGO
	    {
		    get { return _COD_FAMILIA_CARGO; }
		    set { _COD_FAMILIA_CARGO = value; }
	    }
	    
	    	
	    public System.String NOMFAMILIACARGO
	    {
		    get { return _NOM_FAMILIA_CARGO; }
		    set { _NOM_FAMILIA_CARGO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLFAMILIACARGO();
        }

        #endregion	    
    }
}