
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ENIVELEDUCACIONAL.
	/// </summary>
    public class ENIVELEDUCACIONAL : DomainObject
    {
	    	
	    private System.Int16  _COD_NIVEL_EDUCACIONAL = 0;
        	
	    private System.String  _NOM_NIVEL_EDUCACIONAL = String.Empty;
        	
        
	    public ENIVELEDUCACIONAL() : base()
	    {
	    }
	    
		public ENIVELEDUCACIONAL(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODNIVELEDUCACIONAL
	    {
		    get { return _COD_NIVEL_EDUCACIONAL; }
		    set { _COD_NIVEL_EDUCACIONAL = value; }
	    }
	    
	    	
	    public System.String NOMNIVELEDUCACIONAL
	    {
		    get { return _NOM_NIVEL_EDUCACIONAL; }
		    set { _NOM_NIVEL_EDUCACIONAL = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLNIVELEDUCACIONAL();
        }

        #endregion	    
    }
}