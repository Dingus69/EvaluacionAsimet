
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ENIVELOCUPACIONAL.
	/// </summary>
    public class ENIVELOCUPACIONAL : DomainObject
    {
	    	
	    private System.Int16  _COD_NIVEL_OCUPACIONAL = 0;
        	
	    private System.String  _NOMNIVEL_OCUPACIONAL = String.Empty;
        	
        
	    public ENIVELOCUPACIONAL() : base()
	    {
	    }
	    
		public ENIVELOCUPACIONAL(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODNIVELOCUPACIONAL
	    {
		    get { return _COD_NIVEL_OCUPACIONAL; }
		    set { _COD_NIVEL_OCUPACIONAL = value; }
	    }
	    
	    	
	    public System.String NOMNIVELOCUPACIONAL
	    {
		    get { return _NOMNIVEL_OCUPACIONAL; }
		    set { _NOMNIVEL_OCUPACIONAL = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLNIVELOCUPACIONAL();
        }

        #endregion	    
    }
}