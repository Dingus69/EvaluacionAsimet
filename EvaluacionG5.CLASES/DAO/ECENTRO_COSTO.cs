
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECENTROCOSTO.
	/// </summary>
    [Serializable()]
    public class ECENTROCOSTO : DomainObject
    {
	    	
	    private System.String  _COD_CENTRO_COSTO = String.Empty;
        	
	    private System.String  _NOMBRE_CENTRO_COSTO = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;


        public ECENTROCOSTO() : base()
	    {
	    }
	    
		public ECENTROCOSTO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODCENTROCOSTO
	    {
		    get { return _COD_CENTRO_COSTO; }
		    set { _COD_CENTRO_COSTO = value; }
	    }
	    
	    	
	    public System.String NOMBRECENTROCOSTO
	    {
		    get { return _NOMBRE_CENTRO_COSTO; }
		    set { _NOMBRE_CENTRO_COSTO = value; }
	    }

        public long RUT_EMPRESA
        {
            get
            {
                return _RUT_EMPRESA;
            }

            set
            {
                _RUT_EMPRESA = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLCENTROCOSTO();
        }

        #endregion	    
    }
}