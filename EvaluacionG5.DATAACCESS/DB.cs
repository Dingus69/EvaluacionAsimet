using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace EvaluacionG5.DATAACCESS
{
    /// <summary>
    /// Summary description for DB.
    /// </summary>
    public abstract class DB
    {
        /// <summary>
        /// Obtiene el string de conexión a la base de datos
        /// </summary>
        /// <returns>Un string de conexión</returns>
        public abstract string GetConnectionString();

        /// <summary>
        /// Obtiene una conexión a la base de datos
        /// </summary>
        /// <param name="strConn">El string de conexión</param>
        /// <returns>Una objeto de conexión a base de datos</returns>
        public abstract IDbConnection GetConnection(string strConn);

        /// <summary>
        /// Obtiene una conexión a la base de datos default
        /// </summary>
        /// <returns>Una objeto de conexión a base de datos</returns>
        public abstract IDbConnection GetConnection();

        /// <summary>
        /// Ejecuta una consulta con parámetros y retorna las filas afectadas
        /// </summary>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un entero representando el número de filas afectadas</returns>
        public abstract int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta una consulta con parámetros y retorna las filas afectadas
        /// </summary>
        /// <param name="strConn">El string de conexión</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un entero representando el número de filas afectadas</returns>
        public abstract int ExecuteNonQuery(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta una consulta con parámetros y retorna las filas afectadas
        /// </summary>
        /// <param name="connection">La conexión a la base de datos</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un entero representando el número de filas afectadas</returns>
        public abstract int ExecuteNonQuery(IDbConnection connection, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta una consulta transaccional con parámetros y retorna las filas afectadas
        /// </summary>
        /// <param name="transaction">El contexto transaccional</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un entero representando el número de filas afectadas</returns>
        public abstract int ExecuteNonQuery(IDbTransaction transaction, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta un consulta y retorna un DataReader con los resultados
        /// </summary>
        /// <param name="strConn">El string de conexión</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un DataReader con las filas resultantes</returns>
        public abstract IDataReader ExecuteReader(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta un consulta y retorna un DataReader con los resultados
        /// </summary>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un DataReader con las filas resultantes</returns>
        public abstract IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta un consulta y retorna un DataTable con los resultados
        /// </summary>
        /// <param name="strConn">El string de conexión</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un DataTable con las filas resultantes</returns>
        public abstract DataTable ExecuteDataTable(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta un consulta y retorna un DataTable con los resultados
        /// </summary>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un DataTable con las filas resultantes</returns>
        public abstract DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta un consulta y retorna un DataTable con los resultados
        /// </summary>
        /// <param name="connection">La conexión a la base de datos</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un DataTable con las filas resultantes</returns>
        public abstract DataTable ExecuteDataTable(IDbConnection connection, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta un consulta y retorna un Dataset con los resultados
        /// </summary>
        /// <param name="strConn">El string de conexión a la base de datos</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un <seealso cref="DataSet">DataSet</seealso> con los resultados de la consulta</returns>
        public abstract DataSet ExecuteDataSet(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta un consulta y retorna un Dataset con los resultados acepta transacciones
        /// </summary>
        /// <param name="transaction">El contexto transaccional</param>
        /// <param name="strConn">El string de conexión a la base de datos</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un <seealso cref="DataSet">DataSet</seealso> con los resultados de la consulta</returns>
        public abstract DataSet ExecuteDataSet(IDbTransaction transaction, string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta una consulta con parámetros y retorn un valor de resultado
        /// </summary>
        /// <param name="strConn">El string de conexión a la base de datos</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un objeto con el valor retornado</returns>
        public abstract object ExecuteScalar(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta una consulta con parámetros y retorn un valor de resultado
        /// </summary>
        /// <param name="transaction">El contexto transaccional</param>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un objeto con el valor retornado</returns>
        public abstract object ExecuteScalar(IDbTransaction transaction, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Ejecuta una consulta con parámetros y retorn un valor de resultado
        /// </summary>
        /// <param name="cmdType">El tipo de consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un objeto con el valor retornado</returns>
        public abstract object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters);

        /// <summary>
        /// Obtiene el objeto Command de una consulta a base de datos
        /// </summary>
        /// <param name="connection">La conexión a la base de datos</param>
        /// <param name="transaction">El contexto transaccional</param>
        /// <param name="cmdType">El tipo de la consulta</param>
        /// <param name="cmdText">El texto de la consulta</param>
        /// <param name="parameters">Los parámetros de la consulta</param>
        /// <returns>Un objeto Command con la consulta armada</returns>
        public abstract IDbCommand GetCommand(IDbConnection connection, IDbTransaction transaction, CommandType cmdType, string cmdText, IDbDataParameter[] parameters);

        /// <summary>
        /// Obtiene un objeto Parameter en blanco
        /// </summary>
        /// <returns>El objeto Parameter en blanco</returns>
        public abstract IDbDataParameter GetParameter();

        /// <summary>
        /// Obtiene un objeto Parameter en blanco
        /// </summary>
        /// <returns>El objeto Parameter en blanco</returns>
        public abstract IDbDataParameter GetParameter(string parameterName, object value);

        /// <summary>
        /// Obtiene un arreglo de parametros
        /// </summary>
        /// <param name="size">El tamaño del arreglo</param>
        /// <returns>Un arreglo de IDbDataParameter</returns>
        public abstract IDbDataParameter[] GetArrayParameter(int size);

        /// <summary>
        /// Obtiene un objeto dataadapter en blanco
        /// </summary>
        /// <returns>El objeto DataAdapter</returns>
        public abstract DbDataAdapter GetDataAdapter();

        /// <summary>
        /// Obtiene un objeto dataadapter para un commando dado
        /// </summary>
        /// <param name="cmd">el comando</param>
        /// <returns>El objeto DataAdapter</returns>
        public abstract DbDataAdapter GetDataAdapter(IDbCommand cmd);

    }
}
