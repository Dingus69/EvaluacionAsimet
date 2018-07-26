
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECLASIFICADOR2.
	/// </summary>
    [Serializable()]
    public class ECLASIFICADOR2 : DomainObject
    {
	    	
	    private System.String  _COD_CLASIFICADOR_2 = String.Empty;
        	
	    private System.String  _NOMBRE_CLASIFICADOR_2 = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;


        public ECLASIFICADOR2() : base()
	    {
	    }
	    
		public ECLASIFICADOR2(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODCLASIFICADOR2
	    {
		    get { return _COD_CLASIFICADOR_2; }
		    set { _COD_CLASIFICADOR_2 = value; }
	    }
	    
	    	
	    public System.String NOMBRECLASIFICADOR2
	    {
		    get { return _NOMBRE_CLASIFICADOR_2; }
		    set { _NOMBRE_CLASIFICADOR_2 = value; }
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
            return new DLCLASIFICADOR2();
        }

        #endregion	    
    }
}