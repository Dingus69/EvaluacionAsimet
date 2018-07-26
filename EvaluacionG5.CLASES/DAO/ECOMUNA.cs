
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECOMUNA.
	/// </summary>
    public class ECOMUNA : DomainObject
    {
	    	
	    private System.String  _COD_COMUNA = String.Empty;
        	
	    private System.String  _COD_REGION = String.Empty;
        	
	    private System.String  _NOM_COMUNA = String.Empty;
        	
        
	    public ECOMUNA() : base()
	    {
	    }
	    
		public ECOMUNA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODCOMUNA
	    {
		    get { return _COD_COMUNA; }
		    set { _COD_COMUNA = value; }
	    }
	    
	    	
	    public System.String CODREGION
	    {
		    get { return _COD_REGION; }
		    set { _COD_REGION = value; }
	    }
	    
	    	
	    public System.String NOMCOMUNA
	    {
		    get { return _NOM_COMUNA; }
		    set { _NOM_COMUNA = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCOMUNA();
        }

        #endregion	    
    }
}