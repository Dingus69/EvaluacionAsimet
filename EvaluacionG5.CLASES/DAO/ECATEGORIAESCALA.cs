
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECATEGORIAESCALA.
	/// </summary>
    [Serializable()]
    public class ECATEGORIAESCALA : DomainObject
    {
	    	
	    private System.Decimal  _CODCATEGORIA = 0;
        	
	    private System.Decimal  _CODESCALA = 0;
        	
        
	    public ECATEGORIAESCALA() : base()
	    {
	    }
	    
		public ECATEGORIAESCALA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODCATEGORIA
	    {
		    get { return _CODCATEGORIA; }
		    set { _CODCATEGORIA = value; }
	    }
	    
	    	
	    public System.Decimal CODESCALA
	    {
		    get { return _CODESCALA; }
		    set { _CODESCALA = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCATEGORIAESCALA();
        }

        #endregion	    
    }
}