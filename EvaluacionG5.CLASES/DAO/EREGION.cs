
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EREGION.
	/// </summary>
    public class EREGION : DomainObject
    {
	    	
	    private System.String  _COD_REGION = String.Empty;
        	
	    private System.String  _NOM_REGION = String.Empty;
        	
        
	    public EREGION() : base()
	    {
	    }
	    
		public EREGION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODREGION
	    {
		    get { return _COD_REGION; }
		    set { _COD_REGION = value; }
	    }
	    
	    	
	    public System.String NOMREGION
	    {
		    get { return _NOM_REGION; }
		    set { _NOM_REGION = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLREGION();
        }

        #endregion	    
    }
}