
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EAREACURSO.
	/// </summary>
    public class EAREACURSO : DomainObject
    {
	    	
	    private System.Decimal  _COD_AREA_CURSO = 0;
        	
	    private System.String  _NOM_AREA_CURSO = String.Empty;
        	
        
	    public EAREACURSO() : base()
	    {
	    }
	    
		public EAREACURSO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODAREACURSO
	    {
		    get { return _COD_AREA_CURSO; }
		    set { _COD_AREA_CURSO = value; }
	    }
	    
	    	
	    public System.String NOMAREACURSO
	    {
		    get { return _NOM_AREA_CURSO; }
		    set { _NOM_AREA_CURSO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLAREACURSO();
        }

        #endregion	    
    }
}