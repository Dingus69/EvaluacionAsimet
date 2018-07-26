
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPERFILUSUARIO.
	/// </summary>
    [Serializable()]
    public class EPERFILUSUARIO : DomainObject
    {
	    	
	    private System.Int16  _COD_PERFIL = 0;
        	
	    private System.Int64  _RUT_USUARIO = 0;
        	
        
	    public EPERFILUSUARIO() : base()
	    {
	    }
	    
		public EPERFILUSUARIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODPERFIL
	    {
		    get { return _COD_PERFIL; }
		    set { _COD_PERFIL = value; }
	    }
	    
	    	
	    public System.Int64 RUTUSUARIO
	    {
		    get { return _RUT_USUARIO; }
		    set { _RUT_USUARIO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPERFILUSUARIO();
        }

        #endregion	    
    }
}