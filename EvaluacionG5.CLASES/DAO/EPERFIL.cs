
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPERFIL.
	/// </summary>
    [Serializable()]
    public class EPERFIL : DomainObject
    {
	    	
	    private System.Int16  _COD_PERFIL = 0;
        	
	    private System.String  _NOMBRE_PERFIL = String.Empty;
        	
        
	    public EPERFIL() : base()
	    {
	    }
	    
		public EPERFIL(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODPERFIL
	    {
		    get { return _COD_PERFIL; }
		    set { _COD_PERFIL = value; }
	    }
	    
	    	
	    public System.String NOMBREPERFIL
	    {
		    get { return _NOMBRE_PERFIL; }
		    set { _NOMBRE_PERFIL = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPERFIL();
        }

        #endregion	    
    }
}