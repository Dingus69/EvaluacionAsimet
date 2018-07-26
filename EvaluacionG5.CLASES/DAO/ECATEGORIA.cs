
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECATEGORIA.
	/// </summary>
    [Serializable()]
    public class ECATEGORIA : DomainObject
    {
	    	
	    private System.Decimal  _CODCATEGORIA = 0;
        	
	    private System.String  _NOMBRECATEGORIA = String.Empty;
        	
	    private System.Double  _VALORMENOR = 0.0;
        	
	    private System.Double  _VALORMAYOR = 0.0;
        	
        
	    public ECATEGORIA() : base()
	    {
	    }
	    
		public ECATEGORIA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODCATEGORIA
	    {
		    get { return _CODCATEGORIA; }
		    set { _CODCATEGORIA = value; }
	    }
	    
	    	
	    public System.String NOMBRECATEGORIA
	    {
		    get { return _NOMBRECATEGORIA; }
		    set { _NOMBRECATEGORIA = value; }
	    }
	    
	    	
	    public System.Double VALORMENOR
	    {
		    get { return _VALORMENOR; }
		    set { _VALORMENOR = value; }
	    }
	    
	    	
	    public System.Double VALORMAYOR
	    {
		    get { return _VALORMAYOR; }
		    set { _VALORMAYOR = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCATEGORIA();
        }

        #endregion	    
    }
}