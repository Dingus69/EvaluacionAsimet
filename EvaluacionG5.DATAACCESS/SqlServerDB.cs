using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace EvaluacionG5.DATAACCESS
{
    /// <summary>
    /// Summary description for DatabaseFacade.
    /// </summary>
    public sealed class SqlServerDB : DB
    {
        private string _strConnection = String.Empty;

        public SqlServerDB()
        {
        }

        public SqlServerDB(string strConnection)
        {
            _strConnection = strConnection;
        }

        public override IDbConnection GetConnection(string strConn)
        {
            return Database.Connection(strConn);
        }

        public override string GetConnectionString()
        {
            if (_strConnection == String.Empty)
                return Database.CONN_STRING_ALTACOM;
            else
                return _strConnection;
        }

        public override IDbConnection GetConnection()
        {
            return GetConnection(GetConnectionString());
        }

        private SqlParameter[] GetSqlParameters(IDbDataParameter[] parameters)
        {
            if (parameters != null)
            {
                SqlParameter[] sqlParameters = new SqlParameter[parameters.Length];
                int i = 0;

                foreach (IDbDataParameter param in parameters)
                {
                    if (!(param == null))
                    {

                        sqlParameters[i] = new SqlParameter();
                        sqlParameters[i].ParameterName = param.ParameterName;

                        //Copiado de Application Block 
                        if (param.DbType.Equals(DbType.Object) && (param.Value is byte[]))
                        {
                            sqlParameters[i].SqlDbType = SqlDbType.Image;
                        }
                        else
                        {
                            sqlParameters[i].DbType = param.DbType;
                        }
                        sqlParameters[i].Value = param.Value;
                        i++;
                    }
                }
                return sqlParameters;
            }
            return null;
        }

        public override int ExecuteNonQuery(CommandType commandType, string commandText, params IDbDataParameter[] parameters)
        {
            return ExecuteNonQuery(GetConnectionString(), commandType, commandText, parameters);
        }

        public override int ExecuteNonQuery(string strConnection, CommandType commandType, string commandText, params IDbDataParameter[] parameters)
        {
            return Database.ExecuteNonQuery(strConnection, commandType, commandText, GetSqlParameters(parameters));
        }

        public override int ExecuteNonQuery(IDbTransaction transaction, CommandType commandType, string commandText, params IDbDataParameter[] parameters)
        {
            return Database.ExecuteNonQuery((SqlTransaction)transaction, commandType, commandText, GetSqlParameters(parameters));
        }

        public override int ExecuteNonQuery(IDbConnection connection, CommandType commandType, string commandText, params IDbDataParameter[] parameters)
        {
            return Database.ExecuteNonQuery((SqlConnection)connection, commandType, commandText, GetSqlParameters(parameters));
        }

        public override IDataReader ExecuteReader(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return Database.ExecuteReader(strConn, cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return ExecuteReader(GetConnectionString(), cmdType, cmdText, parameters);
        }

        public override DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return ExecuteDataTable(GetConnectionString(), cmdType, cmdText, parameters);
        }

        public override DataTable ExecuteDataTable(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return Database.dtExecuteReader(strConn, cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override DataTable ExecuteDataTable(IDbConnection connection, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return Database.dtExecuteReader((SqlConnection)connection, cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override DataSet ExecuteDataSet(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return Database.dsExecuteReader(strConn, cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override DataSet ExecuteDataSet(IDbTransaction transaction, string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return Database.dsExecuteReader((SqlTransaction)transaction, strConn, cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override object ExecuteScalar(string strConn, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return Database.ExecuteScalar(strConn, cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return Database.ExecuteScalar(GetConnectionString(), cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override object ExecuteScalar(IDbTransaction transaction, CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            return Database.ExecuteScalar((SqlTransaction)transaction, cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override IDbCommand GetCommand(IDbConnection connection, IDbTransaction transaction, CommandType cmdType, string cmdText, IDbDataParameter[] parameters)
        {
            return Database.GenerarComando((SqlConnection)connection, (SqlTransaction)transaction, cmdType, cmdText, GetSqlParameters(parameters));
        }

        public override IDbDataParameter GetParameter()
        {
            return new SqlParameter();
        }

        public override IDbDataParameter GetParameter(string parameterName, object value)
        {
            return new SqlParameter(parameterName, value);
        }

        public override DbDataAdapter GetDataAdapter()
        {
            return new SqlDataAdapter();
        }

        public override DbDataAdapter GetDataAdapter(IDbCommand cmd)
        {
            return new SqlDataAdapter(cmd as SqlCommand);
        }

        public override IDbDataParameter[] GetArrayParameter(int size)
        {
            return new SqlParameter[size];
        }
    }
}
