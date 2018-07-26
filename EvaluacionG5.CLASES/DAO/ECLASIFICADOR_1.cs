
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECLASIFICADOR1.
	/// </summary>
    [Serializable()]
    public class ECLASIFICADOR1 : DomainObject
    {
	    	
	    private System.String  _COD_CLASIFICADOR_1 = String.Empty;
        	
	    private System.String  _NOMBRE_CLASIFICADOR_1 = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;


        public ECLASIFICADOR1() : base()
	    {
	    }
	    
		public ECLASIFICADOR1(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODCLASIFICADOR1
	    {
		    get { return _COD_CLASIFICADOR_1; }
		    set { _COD_CLASIFICADOR_1 = value; }
	    }
	    
	    	
	    public System.String NOMBRECLASIFICADOR1
	    {
		    get { return _NOMBRE_CLASIFICADOR_1; }
		    set { _NOMBRE_CLASIFICADOR_1 = value; }
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
            return new DLCLASIFICADOR1();
        }

        #endregion	    
    }
}