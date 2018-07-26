using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
    public class DLGenericBaseList<T> where T : DomainObject, new()
    {
        /// <summary>
        /// Nombre procedimiento almacenado para seleccionar todos los registros
        /// </summary>
        protected string _proc_select_all = String.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        public DLGenericBaseList()
        {
        }

        protected List<T> GetCollection(IDataReader dr)
        {
            List<T> objCollection = new List<T>();
            T objItem;

            while (dr.Read())
            {
                objItem = new T();
                objItem.Load(dr);
                objItem.IsPersisted = true;
                objCollection.Add(objItem);
            }
            dr.Close();

            return objCollection;
        }
    }
}
