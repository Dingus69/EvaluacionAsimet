
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECARGO.
	/// </summary>
    [Serializable()]
    public class ECARGO : DomainObject
    {
	    	
	    private System.String _COD_CARGO = String.Empty;
        	
	    private System.String  _NOMBRE_CARGO = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;


        public ECARGO() : base()
	    {
	    }
	    
		public ECARGO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODCARGO
	    {
		    get { return _COD_CARGO; }
		    set { _COD_CARGO = value; }
	    }
	    
	    	
	    public System.String NOMBRECARGO
	    {
		    get { return _NOMBRE_CARGO; }
		    set { _NOMBRE_CARGO = value; }
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
            return new DLCARGO();
        }

        #endregion	    
    }
}