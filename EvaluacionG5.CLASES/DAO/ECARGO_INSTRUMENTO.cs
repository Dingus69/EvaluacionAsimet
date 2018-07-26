
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECARGOINSTRUMENTO.
	/// </summary>
    [Serializable()]
    public class ECARGOINSTRUMENTO : DomainObject
    {
	    	
	    private System.Decimal  _COD_CARGO = 0;
        	
	    private System.Decimal  _COD_INSTRUMENTO = 0;
        	
        
	    public ECARGOINSTRUMENTO() : base()
	    {
	    }
	    
		public ECARGOINSTRUMENTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODCARGO
	    {
		    get { return _COD_CARGO; }
		    set { _COD_CARGO = value; }
	    }
	    
	    	
	    public System.Decimal CODINSTRUMENTO
	    {
		    get { return _COD_INSTRUMENTO; }
		    set { _COD_INSTRUMENTO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCARGOINSTRUMENTO();
        }

        #endregion	    
    }
}