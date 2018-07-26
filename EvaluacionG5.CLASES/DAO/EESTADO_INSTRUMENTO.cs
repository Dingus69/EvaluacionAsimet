
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EESTADOINSTRUMENTO.
	/// </summary>
    [Serializable()]
    public class EESTADOINSTRUMENTO : DomainObject
    {
	    	
	    private System.Decimal  _CODESTADOEVAL = 0;
        	
	    private System.String  _NOMESTADOEVAL = String.Empty;
        	
        
	    public EESTADOINSTRUMENTO() : base()
	    {
	    }
	    
		public EESTADOINSTRUMENTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODESTADOEVAL
	    {
		    get { return _CODESTADOEVAL; }
		    set { _CODESTADOEVAL = value; }
	    }
	    
	    	
	    public System.String NOMESTADOEVAL
	    {
		    get { return _NOMESTADOEVAL; }
		    set { _NOMESTADOEVAL = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLESTADOINSTRUMENTO();
        }

        #endregion	    
    }
}