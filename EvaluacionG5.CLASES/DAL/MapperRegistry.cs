using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluacionG5.CLASES.DAL
{
    /// <summary>
    /// Summary description for MapperRegistry.
    /// </summary>
    public class MapperRegistry
    {
        private const string DAL_NAMESPACE = "EvaluacionG5.CLASES.DAL.";

        private static readonly MapperRegistry _instance = new MapperRegistry();

        /// <summary>
        /// Constuctor estático
        /// </summary>
        static MapperRegistry()
        {
        }

        MapperRegistry()
        {
        }

        /// <summary>
        /// La instancia única de la fábrica
        /// </summary>
        public static MapperRegistry Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Entrega un objeto de acceso a datos dado su nombre
        /// </summary>
        /// <param name="className">Nombre de la clase</param>
        /// <returns>Un objeto de acceso datos</returns>
        public DLBase GetMapper(string className)
        {
            Type type = Type.GetType(DAL_NAMESPACE + className);

            return Activator.CreateInstance(type) as DLBase;
        }
    }
}