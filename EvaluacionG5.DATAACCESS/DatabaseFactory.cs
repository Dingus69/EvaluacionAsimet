using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace EvaluacionG5.DATAACCESS
{
    /// <summary>
    /// Una fábrica de objetos de accesos a bases de datos.
    /// </summary>
    public class DatabaseFactory
    {
        private const string DEFAULTNAME = "EvaluacionG5.NET";

        private static readonly DatabaseFactory _instance = new DatabaseFactory();

        /// <summary>
        /// Constuctor estático
        /// </summary>
        static DatabaseFactory()
        {
        }

        /// <summary>
        /// Constructor privado
        /// </summary>
        private DatabaseFactory()
        {
        }

        /// <summary>
        /// La instancia única de la fábrica
        /// </summary>
        public static DatabaseFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Entrega un objeto de acceso a la base de datos principal
        /// </summary>
        /// <returns>Una fachada a la base principal</returns>
        public DB GetDatabase()
        {
            return GetDatabase(DEFAULTNAME);
        }

        /// <summary>
        /// Entrega un objeto de acceso a una base de datos determinada
        /// </summary>
        /// <param name="databaseName">Identificador de la base de datos</param>
        /// <returns>Una fachada de la base de datos solicitada</returns>
        public DB GetDatabase(string databaseName)
        {
            string strValues = ConfigurationManager.AppSettings[databaseName];
            string[] arrValues = strValues.Split(new Char[] { '|' });

            switch (arrValues[0].ToLower())
            {
                case "sqlserver":
                    return new SqlServerDB(arrValues[1]);
                case "oracle":
                    return null; // Pendiente
                default:
                    return null;
            }
        }

    }
}